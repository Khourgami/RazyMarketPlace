using Microsoft.AspNetCore.Builder;

namespace RazySoft.MarketSync.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantDeviceValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantDeviceValidationMiddleware>();
        }
    }
}
