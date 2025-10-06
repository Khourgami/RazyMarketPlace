using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceRepository(AppDbContext context) => _context = context;

        public async Task<List<Invoice>> GetAllAsync() =>
            await _context.Invoices.Include(i => i.SaleItems).ToListAsync();

        public async Task<Invoice?> GetByIdAsync(int id) =>
            await _context.Invoices.Include(i => i.SaleItems).FirstOrDefaultAsync(i => i.Id == id);

        public async Task AddAsync(Invoice invoice) => await _context.Invoices.AddAsync(invoice);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
