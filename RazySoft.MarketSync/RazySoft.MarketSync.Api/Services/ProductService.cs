using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) => _repository = repository;

        public async Task<List<Product>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Product?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Product> CreateAsync(Product product)
        {
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return product;
        }
    }
}
