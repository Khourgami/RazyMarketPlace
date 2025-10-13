// RazySoft.Market.Admin.Web/Services/UiContracts/AllUiServices.cs

using RazySoft.Market.Admin.Application.DTOs;
using RazySoft.Market.Admin.Web.Services;

namespace RazySoft.Market.Admin.Web.Services.UiContracts
{
    // Re-defining Party UI service for completeness
    public interface IPartyUiService
    {
        Task<ApiResponse<IEnumerable<PartyDto>>> GetPartiesAsync(string? search, int pageIndex, int pageSize);
        Task<ApiResponse<PartyDto>> GetPartyByIdAsync(Guid id);
    }

    public interface IProductUiService
    {
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsAsync(string? search, int pageIndex, int pageSize);
        Task<ApiResponse<ProductDto>> GetProductByIdAsync(Guid id);
    }

    public interface IInvoiceUiService
    {
        Task<ApiResponse<IEnumerable<InvoiceDto>>> GetInvoicesAsync(DateTimeOffset? startDate, DateTimeOffset? endDate, int pageIndex, int pageSize);
        Task<ApiResponse<InvoiceDto>> GetInvoiceByIdAsync(Guid id);
        Task<ApiResponse<IEnumerable<InvoiceDto>>> GetInvoicesByPartyIdAsync(Guid partyId);
    }

    public interface ITenantUiService
    {
        Task<ApiResponse<IEnumerable<TenantDto>>> GetTenantsAsync(int pageIndex, int pageSize);
        Task<ApiResponse<TenantDto>> GetTenantByIdAsync(Guid id);
        Task<ApiResponse<IEnumerable<DeviceDto>>> GetTenantDevicesAsync(Guid tenantId);
    }
}
