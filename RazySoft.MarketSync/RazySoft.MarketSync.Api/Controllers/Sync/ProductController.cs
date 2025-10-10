using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Api.Controllers.Sync
{
    [ApiController]
    [Route("api/sync/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ILogger<PartyController> logger)
            : base(logger)
        {
            _productService = productService;
        }

        /// <summary>
        /// دریافت لیست محصولات جدید یا تغییر یافته از ویندوز سرویس
        /// </summary>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadProducts([FromBody] IEnumerable<ProductDto> products, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (products == null || !products.Any())
                return BadRequest("لیست محصولات خالی است.");

            // TenantId از BaseController خوانده می‌شود
            var tenantId = TenantId;
            var deviceId = DeviceId;

            var result = await _productService.SyncAsync(products, tenantId, deviceId, ct);
            return Ok(result);
        }

    }
}
