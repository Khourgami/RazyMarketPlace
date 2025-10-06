using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class SaleItemService : ISaleItemService
    {
        private readonly ISaleItemRepository _repository;
        public SaleItemService(ISaleItemRepository repository) => _repository = repository;

        public async Task<List<SaleItem>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<SaleItem?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<SaleItem> CreateAsync(SaleItem saleItem)
        {
            await _repository.AddAsync(saleItem);
            await _repository.SaveChangesAsync();
            return saleItem;
        }
    }
}
