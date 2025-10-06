using System.Threading;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Core.Interfaces
{
    public interface ISyncService
    {
        //Task ExecuteOnceAsync(CancellationToken ct = default);
        Task RunSyncAsync(CancellationToken ct = default);

    }
}
