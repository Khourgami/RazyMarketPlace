using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Simpl;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Core.Services;
using RazySoft.MarketSync.Infrastructure;
using RazySoft.MarketSync.Service.Jobs;
using RazySoft.MarketSync.Service.Settings;

namespace RazySoft.MarketSync.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // تنظیمات اصلی برنامه
        builder.Host
            .UseWindowsService() // یا UseSystemd برای لینوکس
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
            });

        // افزودن سرویس‌ها به DI Container
        builder.Services.AddControllers();

        // سرویس‌های Core
        builder.Services.AddSingleton<IMapperService, MapperService>();
        builder.Services.AddSingleton<IValidationService, ValidationService>();
        builder.Services.AddSingleton<ISyncService, SyncService>(); // ISyncService فقط یکبار تزریق شود

        // افزودن Quartz
        builder.Services.AddQuartz(q =>
        {
            q.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

            var jobKey = new JobKey("NightlySyncJob");
            q.AddJob<SyncJob>(opts => opts.WithIdentity(jobKey));

            var cronExpression = builder.Configuration["SyncJobSettings:CronExpression"] ?? "0 0 2 * * ?";
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("NightlySyncJob-trigger")
                .WithCronSchedule(cronExpression));
        });

        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        // سرویس‌های Infrastructure و Hosted Service
        builder.Services.AddMarketSyncInfrastructure(builder.Configuration);

        // **مهم‌ترین تغییر**: SyncWorker به عنوان یک Singleton و یک HostedService
        builder.Services.AddSingleton<SyncWorker>();
        builder.Services.AddHostedService<SyncWorker>(provider => provider.GetRequiredService<SyncWorker>());

        var app = builder.Build();

        // تنظیمات HTTP
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}