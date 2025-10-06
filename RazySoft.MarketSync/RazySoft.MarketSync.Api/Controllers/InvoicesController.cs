using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetById(int id)
        {
            var invoice = await _service.GetByIdAsync(id);
            return invoice == null ? NotFound() : Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> Create(Invoice invoice)
        {
            var created = await _service.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
