using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Domain.Entities;
using RazySoft.Market.Admin.Infrastructure.Data;

namespace RazySoft.Market.Admin.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AdminDbContext _db;

        public TenantRepository(AdminDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync(CancellationToken ct = default)
            => await _db.Tenants.AsNoTracking().ToListAsync(ct);

        public async Task<Tenant?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _db.Tenants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
    }
}
