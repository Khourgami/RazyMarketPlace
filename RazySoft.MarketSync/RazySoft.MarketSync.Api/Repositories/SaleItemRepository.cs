using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly AppDbContext _context;
        public SaleItemRepository(AppDbContext context) => _context = context;

        public async Task<List<SaleItem>> GetAllAsync() =>
            await _context.SaleItems.Include(s => s.Product).ToListAsync();

        public async Task<SaleItem?> GetByIdAsync(int id) =>
            await _context.SaleItems.Include(s => s.Product).FirstOrDefaultAsync(s => s.Id == id);

        public async Task AddAsync(SaleItem saleItem) => await _context.SaleItems.AddAsync(saleItem);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
