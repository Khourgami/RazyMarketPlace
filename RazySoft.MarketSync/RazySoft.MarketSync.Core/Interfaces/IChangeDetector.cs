using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Core.Interfaces
{
    /// <summary>
    /// Detect new or changed items from the source against the local sync-store.
    /// </summary>
    public interface IChangeDetector<T>
    {
        Task<IEnumerable<T>> DetectChangesAsync(IEnumerable<T> source, CancellationToken cancellationToken = default);
    }
}
