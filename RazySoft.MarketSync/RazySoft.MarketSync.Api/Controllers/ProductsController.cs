using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var created = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
