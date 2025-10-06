using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceService(IInvoiceRepository repository) => _repository = repository;

        public async Task<List<Invoice>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Invoice?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            await _repository.AddAsync(invoice);
            await _repository.SaveChangesAsync();
            return invoice;
        }
    }
}
