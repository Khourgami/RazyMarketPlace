using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Api.Services; 
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Api.Controllers.Sync
{
    [ApiController]
    [Route("api/sync/[controller]")]
    public class PartyController : BaseController
    {
        private readonly IPartyService _partyService;

        public PartyController(IPartyService partyService, ILogger<PartyController> logger)
            : base(logger)
        {
            _partyService = partyService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncParties([FromBody] IEnumerable<PartyDto> parties, CancellationToken ct)
        {
            var validation = ValidateHeaders();
            if (validation is BadRequestObjectResult)
                return validation;

            await _partyService.SyncAsync(parties!, TenantId!, DeviceId!, ct);
            return Ok(new { Message = "Parties synced successfully", Count = parties?.Count() ?? 0 });
        }
    }
}
