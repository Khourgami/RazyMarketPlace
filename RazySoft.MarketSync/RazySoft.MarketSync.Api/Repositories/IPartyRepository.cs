using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface IPartyRepository
    {
        Task<Party?> GetByNormalizedIdAsync(int FkColCode , int MoinCode, Guid tenantId, CancellationToken ct = default);
        Task AddAsync(Party party, CancellationToken ct = default);
        Task UpdateAsync(Party party, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
