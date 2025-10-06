using RazySoft.MarketSync.AdminWeb.Services.Models;

namespace RazySoft.MarketSync.AdminWeb.Services
{
    public interface ISyncApiTenant
    {
        Task<SyncStatus?> GetStatusAsync(CancellationToken ct = default);
        Task<List<string>?> GetLogsAsync(CancellationToken ct = default);
        Task<bool> RunSyncAsync(CancellationToken ct = default);
    }
}
