using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

public interface IPartyRepository
{
    Task<Party?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default);
    Task AddAsync(Party entity, CancellationToken ct = default);
    Task UpdateAsync(Party entity, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}

public class PartyRepository : IPartyRepository
{
    private readonly MarketSyncDbContext _db;

    public PartyRepository(MarketSyncDbContext db) => _db = db;

    public Task<Party?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default)
        => _db.Parties.FirstOrDefaultAsync(p => p.NormalizedLegacyId == normalizedId && p.TenantId == tenantId, ct);

    public async Task AddAsync(Party entity, CancellationToken ct = default)
        => await _db.Parties.AddAsync(entity, ct);

    public Task UpdateAsync(Party entity, CancellationToken ct = default)
    {
        _db.Parties.Update(entity);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);
}