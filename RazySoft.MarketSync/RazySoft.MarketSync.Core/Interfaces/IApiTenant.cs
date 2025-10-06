using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.MarketSync.Domain.DTOs;

namespace RazySoft.MarketSync.Core.Interfaces
{
    /// <summary>
    /// Responsible for sending DTO batches to central server.
    /// Implementation belongs to Infrastructure (HTTP client).
    /// Return true when server acknowledges success.
    /// </summary>
    public interface IApiTenant
    {
        Task<bool> SendInvoicesAsync(IEnumerable<InvoiceDto> invoices, CancellationToken ct = default);
        Task<bool> SendPartiesAsync(IEnumerable<PartyDto> parties, CancellationToken ct = default);
        Task<bool> SendProductsAsync(IEnumerable<ProductDto> products, CancellationToken ct = default);
    }
}
