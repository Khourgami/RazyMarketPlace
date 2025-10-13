using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Domain.Entities;
using RazySoft.Market.Admin.Infrastructure.Data;

namespace RazySoft.Market.Admin.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AdminDbContext _db;

        public InvoiceRepository(AdminDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken ct = default)
            => await _db.Invoices
                .Include(i => i.SaleItems)
                .AsNoTracking()
                .ToListAsync(ct);

        public async Task<Invoice?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _db.Invoices
                .Include(i => i.SaleItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<IEnumerable<Invoice>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default)
            => await _db.Invoices
                .Include(i => i.SaleItems)
                .AsNoTracking()
                .Where(x => x.PartyId == partyId)
                .ToListAsync(ct);

        public async Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default)
            => await _db.Invoices
                .Include(i => i.SaleItems)
                .AsNoTracking()
                .Where(x => x.Date >= from && x.Date <= to)
                .ToListAsync(ct);
    }
}
