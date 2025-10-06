using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task AddAsync(Invoice invoice);
        Task SaveChangesAsync();
    }
}
