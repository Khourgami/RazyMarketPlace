using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<Invoice> CreateAsync(Invoice invoice);
    }
}
