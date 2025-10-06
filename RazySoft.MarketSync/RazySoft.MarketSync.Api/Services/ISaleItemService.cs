using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public interface ISaleItemService
    {
        Task<List<SaleItem>> GetAllAsync();
        Task<SaleItem?> GetByIdAsync(int id);
        Task<SaleItem> CreateAsync(SaleItem saleItem);
    }
}
