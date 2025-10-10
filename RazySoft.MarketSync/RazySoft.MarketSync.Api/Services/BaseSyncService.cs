using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public abstract class BaseSyncService<TEntity, TDto, TRepo>
        where TEntity : BaseEntity, new()
    {
        protected readonly TRepo _repository;
        protected readonly ILogger _logger;

        protected BaseSyncService(TRepo repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public abstract Task<SyncResultDto> SyncAsync(IEnumerable<TDto> items, string tenantId, string deviceId, CancellationToken ct = default);
    }
}
