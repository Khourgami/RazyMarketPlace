using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _repo;
        private readonly ILogger<PartyService> _logger;

        public PartyService(IPartyRepository repo, ILogger<PartyService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<SyncResultDto> SyncAsync(IEnumerable<PartyDto> items, string tenantId, string deviceId, CancellationToken ct = default)
        {
            var result = new SyncResultDto();
            if (!Guid.TryParse(tenantId, out var tenantGuid))
                return result;

            foreach (var dto in items)
            {
                var normalized = dto.NormalizedLegacyId ?? $"{dto.FkColCode}-{dto.MoeinCode}";
                var existing = await _repo.GetByNormalizedIdAsync(normalized, tenantGuid, ct);

                if (existing == null)
                {
                    var entity = new Party
                    {
                        Id = dto.LocalId,
                        NormalizedLegacyId = normalized,
                        TenantId = tenantGuid,
                        Name = dto.Name ?? "",
                        LastModified = DateTime.UtcNow
                    };

                    await _repo.AddAsync(entity, ct);
                    result.Inserted++;
                }
                else
                {
                    existing.Name = dto.Name ?? existing.Name;
                    existing.LastModified = DateTime.UtcNow;
                    await _repo.UpdateAsync(existing, ct);
                    result.Updated++;
                }
            }

            await _repo.SaveChangesAsync(ct);
            return result;
        }
    }
}
