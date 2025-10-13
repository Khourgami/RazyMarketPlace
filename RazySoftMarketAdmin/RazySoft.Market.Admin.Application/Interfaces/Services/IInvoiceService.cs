using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Application.DTOs;

namespace RazySoft.Market.Admin.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync(CancellationToken ct = default);
        Task<InvoiceDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<InvoiceDto>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default);
        Task<IEnumerable<InvoiceDto>> GetByDateRangeAsync(DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default);
    }
}
