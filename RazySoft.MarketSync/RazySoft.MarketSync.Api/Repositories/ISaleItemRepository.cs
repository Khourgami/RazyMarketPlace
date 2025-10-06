using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface ISaleItemRepository
    {
        Task<List<SaleItem>> GetAllAsync();
        Task<SaleItem?> GetByIdAsync(int id);
        Task AddAsync(SaleItem saleItem);
        Task SaveChangesAsync();
    }
}
