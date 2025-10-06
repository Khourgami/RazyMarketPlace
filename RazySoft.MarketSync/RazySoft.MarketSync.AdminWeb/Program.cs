using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazySoft.MarketSync.AdminWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// bind settings
builder.Services.Configure<SyncServiceOptions>(builder.Configuration.GetSection("SyncService"));

// HttpClient for Sync API
builder.Services.AddHttpClient<ISyncApiTenant, SyncApiTenant>((sp, client) =>
{
    var opts = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<SyncServiceOptions>>().Value;
    client.BaseAddress = new Uri(opts.BaseUrl.TrimEnd('/') + "/");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Razor pages (بدون runtime compilation)
builder.Services.AddRazorPages();

// optional: اگر می‌خواهی RuntimeCompilation در محیط توسعه فعال باشد
// 1) نصب پکیج: dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
// 2) سپس این خط را (در حالت Development) به صورت زیر استفاده کن:
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// }

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
