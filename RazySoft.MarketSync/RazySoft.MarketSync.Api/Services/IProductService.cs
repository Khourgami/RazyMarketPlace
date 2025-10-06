using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
    }
}
