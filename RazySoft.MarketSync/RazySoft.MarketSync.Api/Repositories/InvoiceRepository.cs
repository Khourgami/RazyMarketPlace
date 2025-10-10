using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default);
        Task AddAsync(Invoice entity, CancellationToken ct = default);
        Task UpdateAsync(Invoice entity, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MarketSyncDbContext _db;

        public InvoiceRepository(MarketSyncDbContext db) => _db = db;

        public Task<Invoice?> GetByNormalizedIdAsync(string normalizedId, Guid tenantId, CancellationToken ct = default)
            => _db.Invoices.FirstOrDefaultAsync(i => i.TenantId == tenantId, ct);

        public async Task AddAsync(Invoice entity, CancellationToken ct = default)
            => await _db.Invoices.AddAsync(entity, ct);

        public Task UpdateAsync(Invoice entity, CancellationToken ct = default)
        {
            _db.Invoices.Update(entity);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
