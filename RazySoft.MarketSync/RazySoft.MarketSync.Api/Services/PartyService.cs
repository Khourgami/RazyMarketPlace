using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;
        private readonly ILogger<PartyService> _logger;

        public PartyService(IPartyRepository partyRepository, ILogger<PartyService> logger)
        {
            _partyRepository = partyRepository;
            _logger = logger;
        }

        public async Task SaveReceivedPartiesAsync(IEnumerable<Party> parties, string tenantId, string deviceId, CancellationToken ct = default)
        {
            if (parties == null || !parties.Any())
                return;

            _logger.LogInformation("Receiving {Count} parties from Tenant={TenantId}, Device={DeviceId}",
                parties.Count(), tenantId, deviceId);

            Guid tenantGuid = Guid.Parse(tenantId);

            foreach (var incoming in parties)
            {
                var existing = await _partyRepository.GetByNormalizedIdAsync(incoming.FkColCode , incoming.MoeinCode, tenantGuid, ct);

                if (existing == null)
                {
                    incoming.TenantId = tenantGuid;
                    incoming.IsSynced = true;
                    incoming.LastModified = DateTime.UtcNow;
                    await _partyRepository.AddAsync(incoming, ct);
                }
                else
                {
                    existing.Name = incoming.Name;
                    existing.NationalId = incoming.NationalId;
                    //existing.Address = incoming.Address;
                    //existing.Mobile = incoming.Mobile;
                    existing.LastModified = DateTime.UtcNow;
                    existing.IsSynced = true;
                    await _partyRepository.UpdateAsync(existing, ct);
                }
            }

            await _partyRepository.SaveChangesAsync(ct);
        }
    }
}
