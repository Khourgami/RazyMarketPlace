using Microsoft.Extensions.DependencyInjection;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Application.Interfaces.Services;
using RazySoft.Market.Admin.Application.Services;

namespace RazySoft.Market.Admin.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminApplication(this IServiceCollection services)
        {
            // Register Application services (repositories registered in Infrastructure)
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IPartyService, PartyService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ITenantService, TenantService>();
            return services;
        }
    }
}
