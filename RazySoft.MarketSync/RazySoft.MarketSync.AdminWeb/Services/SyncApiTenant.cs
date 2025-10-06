using System.Net.Http.Json;
using RazySoft.MarketSync.AdminWeb.Services.Models;
using Microsoft.Extensions.Logging;

namespace RazySoft.MarketSync.AdminWeb.Services
{
    public class SyncApiTenant : ISyncApiTenant
    {
        private readonly HttpClient _http;
        private readonly ILogger<SyncApiTenant> _logger;

        public SyncApiTenant(HttpClient http, ILogger<SyncApiTenant> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task<SyncStatus?> GetStatusAsync(CancellationToken ct = default)
        {
            try
            {
                var resp = await _http.GetAsync("sync/status", ct);
                if (!resp.IsSuccessStatusCode) return null;
                var model = await resp.Content.ReadFromJsonAsync<SyncStatus>(cancellationToken: ct);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "GetStatusAsync failed");
                return null;
            }
        }

        public async Task<List<string>?> GetLogsAsync(CancellationToken ct = default)
        {
            try
            {
                var resp = await _http.GetAsync("logs", ct);
                if (!resp.IsSuccessStatusCode) return null;
                var lines = await resp.Content.ReadFromJsonAsync<List<string>>(cancellationToken: ct);
                return lines;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "GetLogsAsync failed");
                return null;
            }
        }

        public async Task<bool> RunSyncAsync(CancellationToken ct = default)
        {
            try
            {
                var resp = await _http.PostAsync("sync/run", null, ct);
                return resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "RunSyncAsync failed");
                return false;
            }
        }
    }
}
