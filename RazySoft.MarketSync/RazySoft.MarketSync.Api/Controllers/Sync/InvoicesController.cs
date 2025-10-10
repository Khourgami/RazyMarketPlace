using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.DTOs;

namespace RazySoft.MarketSync.Api.Controllers.Sync
{
    [ApiController]
    [Route("api/sync/[controller]")]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger):base(logger)
        {
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// دریافت فاکتورها و آیتم‌های فروش از کلاینت
        /// </summary>
        [HttpPost("push")]
        public async Task<IActionResult> PushInvoicesAsync([FromBody] IEnumerable<InvoiceDto> invoices, CancellationToken ct)
        {
            var validation = ValidateHeaders();
            if (validation is BadRequestObjectResult)
                return validation;

            await _invoiceService.SyncAsync(invoices!, TenantId!, DeviceId!, ct);
            return Ok(new { Message = "Parties synced successfully", Count = invoices?.Count() ?? 0 });
        }
    }
}
