using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Core.Interfaces
{
    /// <summary>
    /// Access to Sync DB (local staging DB).
    /// Sync DB already filled by SQL SP from Legacy DB.
    /// We only read pending/changed records and update their status.
    /// </summary>
    public interface ISyncStore
    {
        Task<IEnumerable<Party>> GetPendingPartiesAsync(CancellationToken ct = default);
        Task<IEnumerable<Product>> GetPendingProductsAsync(CancellationToken ct = default);
        Task<IEnumerable<Invoice>> GetPendingInvoicesAsync(CancellationToken ct = default);

        Task MarkPartyAsSyncedAsync(string partyId, bool success, CancellationToken ct = default);
        Task MarkProductAsSyncedAsync(string productId, bool success, CancellationToken ct = default);
        Task MarkInvoiceAsSyncedAsync(string invoiceId, bool success, CancellationToken ct = default);
    }
}
