using Quartz;
using Polly;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Service.Settings;

namespace RazySoft.MarketSync.Service.Jobs
{
    public class SyncJob : IJob
    {
        private readonly ISyncService _syncService;
        private readonly ILogger<SyncJob> _logger;
        private readonly SyncJobSettings _settings;

        public SyncJob(ISyncService syncService,
                       ILogger<SyncJob> logger,
                       IOptions<SyncJobSettings> settings)
        {
            _syncService = syncService;
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Starting nightly sync job at {Time}", DateTime.UtcNow);

            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: _settings.RetryCount,
                    sleepDurationProvider: attempt => TimeSpan.FromMinutes(_settings.RetryIntervalMinutes),
                    onRetry: (exception, timeSpan, retryCount, ctx) =>
                    {
                        _logger.LogWarning("Sync attempt {Retry} failed. Retrying in {Delay}. Error: {Error}",
                            retryCount, timeSpan, exception.Message);
                    });

            await retryPolicy.ExecuteAsync(async () =>
            {
                await _syncService.RunSyncAsync(context.CancellationToken);
                _logger.LogInformation("Sync job completed successfully at {Time}", DateTime.UtcNow);
            });
        }
    }
}
