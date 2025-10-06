using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Controllers
{
    [ApiController]
    [Route("api/sync/[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _service;

        public PartyController(IPartyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Party>>> GetAll()
        {
            var parties = await _service.GetAllAsync();
            return Ok(parties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Party>> GetById(int id)
        {
            var party = await _service.GetByIdAsync(id);
            if (party == null) return NotFound();
            return Ok(party);
        }

        [HttpPost]
        public async Task<ActionResult<Party>> Create(Party party)
        {
            var created = await _service.CreateAsync(party);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
