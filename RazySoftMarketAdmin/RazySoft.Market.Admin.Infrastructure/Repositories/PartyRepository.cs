using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Domain.Entities;
using RazySoft.Market.Admin.Infrastructure.Data;

namespace RazySoft.Market.Admin.Infrastructure.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly AdminDbContext _db;

        public PartyRepository(AdminDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Party>> GetAllAsync(CancellationToken ct = default)
            => await _db.Parties.AsNoTracking().ToListAsync(ct);

        public async Task<Party?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _db.Parties.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<Party?> GetByNormalizedLegacyIdAsync(string normalizedLegacyId, CancellationToken ct = default)
            => await _db.Parties.AsNoTracking()
                .FirstOrDefaultAsync(x => x.NormalizedLegacyId == normalizedLegacyId, ct);

        public async Task<IEnumerable<Party>> GetByNameAsync(string namePart, CancellationToken ct = default)
            => await _db.Parties.AsNoTracking()
                .Where(x => x.Name.Contains(namePart))
                .ToListAsync(ct);
    }
}
