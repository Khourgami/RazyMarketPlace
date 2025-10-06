using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly AppDbContext _dbContext;

        public PartyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Party?> GetByNormalizedIdAsync(int FkColCode, int MoinCode, Guid tenantId, CancellationToken ct = default)
        {
            return await _dbContext.Parties
                .FirstOrDefaultAsync(p => p.FkColCode == FkColCode && p.MoeinCode == MoinCode && p.TenantId == tenantId, ct);
        }

        public async Task AddAsync(Party party, CancellationToken ct = default)
        {
            await _dbContext.Parties.AddAsync(party, ct);
        }

        public Task UpdateAsync(Party party, CancellationToken ct = default)
        {
            _dbContext.Parties.Update(party);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
