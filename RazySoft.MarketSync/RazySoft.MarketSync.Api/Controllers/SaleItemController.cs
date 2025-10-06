using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleItemController : ControllerBase
    {
        private readonly ISaleItemService _service;
        public SaleItemController(ISaleItemService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<SaleItem>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItem>> GetById(int id)
        {
            var saleItem = await _service.GetByIdAsync(id);
            return saleItem == null ? NotFound() : Ok(saleItem);
        }

        [HttpPost]
        public async Task<ActionResult<SaleItem>> Create(SaleItem saleItem)
        {
            var created = await _service.CreateAsync(saleItem);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
