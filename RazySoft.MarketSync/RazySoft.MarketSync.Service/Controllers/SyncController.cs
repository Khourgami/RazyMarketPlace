using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Service.Api;

namespace RazySoft.MarketSync.Service.Controllers
{
    [ApiController]
    [Route("sync")]
    public class SyncController : ControllerBase
    {
        private readonly SyncStatus _status;
        private readonly ILogger<SyncController> _logger;

        public SyncController(SyncStatus status, ILogger<SyncController> logger)
        {
            _status = status;
            _logger = logger;
        }

        /// <summary>
        /// اجرای دستی سینک
        /// </summary>
        [HttpPost("run")]
        public async Task<IActionResult> RunSync()
        {
            if (_status.IsRunning)
                return Conflict("Sync already running.");

            _status.IsRunning = true;
            _logger.LogInformation("Manual sync started at {Time}", DateTime.Now);

            try
            {
                // شبیه‌سازی عملیات سینک
                await Task.Delay(2000);
                _status.LastRun = DateTime.Now;
                _status.LastRunSuccess = true;
                _logger.LogInformation("Manual sync finished at {Time}", DateTime.Now);
            }
            catch (Exception ex)
            {
                _status.LastRun = DateTime.Now;
                _status.LastRunSuccess = false;
                _logger.LogError(ex, "Manual sync failed");
                return StatusCode(500, "Sync failed: " + ex.Message);
            }
            finally
            {
                _status.IsRunning = false;
            }

            return Ok(_status);
        }

        /// <summary>
        /// وضعیت جاری سینک
        /// </summary>
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(_status);
        }
    }
}
