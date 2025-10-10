using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default);
        Task AddAsync(Product entity, CancellationToken ct = default);
        Task UpdateAsync(Product entity, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly MarketSyncDbContext _db;

        public ProductRepository(MarketSyncDbContext db) => _db = db;

        public Task<Product?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default)
            => _db.Products.FirstOrDefaultAsync(p => p.NormalizedLegacyId == normalizedId && p.TenantId == tenantId, ct);

        public async Task AddAsync(Product entity, CancellationToken ct = default)
            => await _db.Products.AddAsync(entity, ct);

        public Task UpdateAsync(Product entity, CancellationToken ct = default)
        {
            _db.Products.Update(entity);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
