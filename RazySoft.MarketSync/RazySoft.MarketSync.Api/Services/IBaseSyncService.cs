using RazySoft.MarketSync.Domain.DTOs;

namespace RazySoft.MarketSync.Api.Services
{
    public interface IBaseSyncService<TDto>
    {
        Task<SyncResultDto> SyncAsync(IEnumerable<TDto> items, string tenantId, string deviceId, CancellationToken ct = default);
    }
    public interface IPartyService : IBaseSyncService<PartyDto> { }
    public interface IProductService : IBaseSyncService<ProductDto> { }
    public interface IInvoiceService : IBaseSyncService<InvoiceDto> { }
    public interface ISaleItemService : IBaseSyncService<SaleItemDto> { }

}
