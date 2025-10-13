using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken ct = default);
        Task<Invoice?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Invoice>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default);
        Task<IEnumerable<Invoice>> GetByDateRangeAsync(DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default);
    }
}
