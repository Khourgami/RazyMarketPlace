using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Core.Services;

namespace RazySoft.MarketSync.Service
{
    public class SyncWorker : BackgroundService
    {
        private readonly ILogger<SyncWorker> _logger;
        private readonly ISyncService _syncService;

        public SyncWorker(ILogger<SyncWorker> logger, ISyncService syncService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _syncService = syncService ?? throw new ArgumentNullException(nameof(syncService));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SyncWorker started at: {Time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _syncService.RunSyncAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during sync cycle.");
                }

                // Delay between sync cycles (configurable later)
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }

            _logger.LogInformation("SyncWorker stopped at: {Time}", DateTimeOffset.Now);
        }

        public async Task StartSyncProcess()
        {
            _logger.LogInformation("شروع فرایند همگام‌سازی از طریق API");
            await Task.Delay(100); // یک مثال ساده از عملیات
            _logger.LogInformation("فرایند همگام‌سازی به پایان رسید.");
        }
    }
}
