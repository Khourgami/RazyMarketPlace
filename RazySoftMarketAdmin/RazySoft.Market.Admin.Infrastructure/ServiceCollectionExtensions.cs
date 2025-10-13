using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Infrastructure.Data;
using RazySoft.Market.Admin.Infrastructure.Repositories;

namespace RazySoft.Market.Admin.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // ✅ Add DbContext
            var connectionString = configuration.GetConnectionString("AdminDb");
            services.AddDbContext<AdminDbContext>(options =>
                options.UseSqlServer(connectionString));

            // ✅ Register repositories
            services.AddScoped<IPartyRepository, PartyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();

            return services;
        }
    }
}
