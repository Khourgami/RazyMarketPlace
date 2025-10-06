using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Infrastructure.Api;
using RazySoft.MarketSync.Infrastructure.Configuration;
using RazySoft.MarketSync.Infrastructure.Data;

namespace RazySoft.MarketSync.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds infrastructure services: SqlSyncStore and HttpApiClient (with HttpClient).
        /// Expects configuration section "Infrastructure" to contain ConnectionString and ApiBaseUrl.
        /// </summary>
        public static IServiceCollection AddMarketSyncInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var infraSection = configuration.GetSection("Infrastructure");
            var options = infraSection.Get<InfrastructureOptions>() ?? new InfrastructureOptions();

            // Register options as singleton
            services.AddSingleton(options);

            // Register SqlSyncStore as ISyncStore
            services.AddSingleton<ISyncStore, SqlSyncStore>();

            // Register HttpApiClient with named HttpClient (or default)
            services.AddHttpClient<IApiTenant, HttpApiClient>(client =>
            {
                if (!string.IsNullOrWhiteSpace(options.ApiBaseUrl))
                {
                    client.BaseAddress = new Uri(options.ApiBaseUrl.TrimEnd('/') + "/");
                }
                // further client defaults could be set here (timeouts, headers)
            });

            return services;
        }
    }
}
