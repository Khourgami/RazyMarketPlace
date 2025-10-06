using Microsoft.AspNetCore.Mvc;

namespace RazySoft.MarketSync.Service.Controllers
{
    [ApiController]
    [Route("logs")]
    public class LogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogs()
        {
            if (!System.IO.File.Exists("logs/marketsync.log"))
                return NotFound("Log file not found.");

            var lines = System.IO.File.ReadAllLines("logs/marketsync.log")
                                      .TakeLast(100)
                                      .ToArray();

            return Ok(lines);
        }
    }
}
