using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace RazySoft.MarketSync.Api.Controllers.Sync
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// شناسه کلاینت (TenantId) که از هدر درخواست خوانده می‌شود.
        /// </summary>
        protected string? TenantId
        {
            get
            {
                if (Request?.Headers?.TryGetValue("TenantId", out var tenantId) == true)
                    return tenantId.ToString();
                _logger.LogWarning("Missing TenantId header in request.");
                return null;
            }
        }

        /// <summary>
        /// شناسه دستگاه (DeviceId) که از هدر درخواست خوانده می‌شود.
        /// </summary>
        protected string? DeviceId
        {
            get
            {
                if (Request?.Headers?.TryGetValue("DeviceId", out var deviceId) == true)
                    return deviceId.ToString();
                _logger.LogWarning("Missing DeviceId header in request.");
                return null;
            }
        }

        /// <summary>
        /// بررسی می‌کند که TenantId و DeviceId هر دو در درخواست موجود هستند.
        /// </summary>
        protected bool HasRequiredHeaders =>
            !string.IsNullOrWhiteSpace(TenantId) &&
            !string.IsNullOrWhiteSpace(DeviceId);

        /// <summary>
        /// برمی‌گرداند BadRequest اگر هدرها موجود نباشند.
        /// </summary>
        protected IActionResult ValidateHeaders()
        {
            if (!HasRequiredHeaders)
            {
                return BadRequest(new
                {
                    Error = "Missing required headers",
                    RequiredHeaders = new[] { "TenantId", "DeviceId" }
                });
            }

            return Ok();
        }
    }
}
