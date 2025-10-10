using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface ISaleItemRepository
    {
        Task<SaleItem?> GetByNormalizedIdAsync(Guid normalizedId, Guid tenantId, CancellationToken ct = default);
        Task AddAsync(SaleItem entity, CancellationToken ct = default);
        Task UpdateAsync(SaleItem entity, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }

    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly MarketSyncDbContext _db;

        public SaleItemRepository(MarketSyncDbContext db) => _db = db;

        public Task<SaleItem?> GetByNormalizedIdAsync(Guid Id, Guid tenantId, CancellationToken ct = default)
            => _db.SaleItems.FirstOrDefaultAsync(i => i.Id == Id && i.TenantId == tenantId, ct);

        public async Task AddAsync(SaleItem entity, CancellationToken ct = default)
            => await _db.SaleItems.AddAsync(entity, ct);

        public Task UpdateAsync(SaleItem entity, CancellationToken ct = default)
        {
            _db.SaleItems.Update(entity);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
