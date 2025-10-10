using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    //public interface IProductService
    //{
    //    Task<SyncResultDto> SyncAsync(IEnumerable<ProductDto> items, string tenantId, string deviceId, CancellationToken ct = default);
    //}

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repo, ILogger<ProductService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<SyncResultDto> SyncAsync(IEnumerable<ProductDto> items, string tenantId, string deviceId, CancellationToken ct = default)
        {
            var result = new SyncResultDto();
            if (!Guid.TryParse(tenantId, out var tenantGuid))
                return result;

            foreach (var dto in items)
            {
                // کلید اصلی برای محصول: CmFullCode
                var normalized = dto.CmFullCode?.Trim();
                if (string.IsNullOrEmpty(normalized)) continue;

                var existing = await _repo.GetByNormalizedIdAsync(normalized, tenantGuid, ct);

                if (existing == null)
                {
                    var entity = new Product
                    {
                        Id = dto.LocalId,
                        NormalizedLegacyId = normalized,
                        TenantId = tenantGuid,
                        Name = dto.Name ?? "",
                        Unit = dto.Unit ?? "",
                        LastModified = DateTime.UtcNow
                    };

                    await _repo.AddAsync(entity, ct);
                    result.Inserted++;
                }
                else
                {
                    existing.Name = dto.Name ?? existing.Name;
                    existing.Unit = dto.Unit ?? existing.Unit;
                    existing.LastModified = DateTime.UtcNow;
                    await _repo.UpdateAsync(existing, ct);
                    result.Updated++;
                }
            }

            await _repo.SaveChangesAsync(ct);
            return result;
        }
    }
}
