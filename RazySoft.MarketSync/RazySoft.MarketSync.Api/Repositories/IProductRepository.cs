using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task SaveChangesAsync();
    }
}
