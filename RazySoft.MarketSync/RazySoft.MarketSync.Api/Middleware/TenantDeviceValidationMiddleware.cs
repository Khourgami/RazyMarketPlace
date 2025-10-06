using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Api.Middleware
{
    public class TenantDeviceValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantDeviceValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Client-Id", out var tenantId) ||
                !context.Request.Headers.TryGetValue("X-Device-Id", out var deviceId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing TenantId or DeviceId in headers.");
                return;
            }

            // اینجا میشه اعتبارسنجی اولیه انجام داد (مثلا فرمت یا چک کردن در دیتابیس)
            context.Items["TenantId"] = tenantId.ToString();
            context.Items["DeviceId"] = deviceId.ToString();

            await _next(context);
        }
    }
    // Extension برای اضافه کردن به pipeline
    public static class TenantDeviceValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantDevicetValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TenantDeviceValidationMiddleware>();
        }
    }
}
