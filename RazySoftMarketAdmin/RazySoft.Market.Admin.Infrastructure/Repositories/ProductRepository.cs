using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Domain.Entities;
using RazySoft.Market.Admin.Infrastructure.Data;

namespace RazySoft.Market.Admin.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdminDbContext _db;

        public ProductRepository(AdminDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
            => await _db.Products.AsNoTracking().ToListAsync(ct);

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<IEnumerable<Product>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default)
            => await _db.Products.AsNoTracking()
                .Where(x => x.PartyId == partyId)
                .ToListAsync(ct);

        public async Task<Product?> GetByNormalizedLegacyIdAsync(string normalizedLegacyId, CancellationToken ct = default)
            => await _db.Products.AsNoTracking()
                .FirstOrDefaultAsync(x => x.NormalizedLegacyId == normalizedLegacyId, ct);
    }
}
