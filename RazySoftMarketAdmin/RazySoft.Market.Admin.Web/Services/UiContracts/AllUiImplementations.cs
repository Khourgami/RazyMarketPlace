// RazySoft.Market.Admin.Web/Services/AllUiImplementations.cs

using RazySoft.Market.Admin.Application.DTOs;
using RazySoft.Market.Admin.Application.Interfaces.Services;
using RazySoft.Market.Admin.Application.Services;
using RazySoft.Market.Admin.Web.Services.UiContracts;

namespace RazySoft.Market.Admin.Web.Services
{
    // Implementation for services previously generated (Mocked in the same file)
    public class PartyUiService : IPartyUiService
    {
        private readonly IPartyService _partyService;
        public PartyUiService(IPartyService partyService) => _partyService = partyService;
        public async Task<ApiResponse<IEnumerable<PartyDto>>> GetPartiesAsync(string? search, int pageIndex, int pageSize)
        {
            try
            {
                IEnumerable<PartyDto> data = await _partyService.GetAllAsync();// GetPartiesAsync(search, pageIndex, pageSize);
                return ApiResponse<IEnumerable<PartyDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<PartyDto>>.Error($"Failed to fetch parties: {ex.Message}"); }
        }
        public async Task<ApiResponse<PartyDto>> GetPartyByIdAsync(Guid id)
        {
            try
            {
                var data = await _partyService.GetByIdAsync(id);
                return data != null ? ApiResponse<PartyDto>.Success(data) : ApiResponse<PartyDto>.Error("Party not found.");
            }
            catch (Exception ex) { return ApiResponse<PartyDto>.Error($"Failed to fetch party: {ex.Message}"); }
        }
    }

    // New: Product UI Service
    public class ProductUiService : IProductUiService
    {
        private readonly IProductService _productService;
        public ProductUiService(IProductService productService) => _productService = productService;
        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsAsync(string? search, int pageIndex, int pageSize)
        {
            try
            {
                var data = await _productService.GetAllAsync();// SearchProductsAsync(search, pageIndex, pageSize);
                return ApiResponse<IEnumerable<ProductDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<ProductDto>>.Error($"Failed to fetch products: {ex.Message}"); }
        }
        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(Guid id)
        {
            try
            {
                var data = await _productService.GetByIdAsync(id);
                return data != null ? ApiResponse<ProductDto>.Success(data) : ApiResponse<ProductDto>.Error("Product not found.");
            }
            catch (Exception ex) { return ApiResponse<ProductDto>.Error($"Failed to fetch product: {ex.Message}"); }
        }
    }

    // New: Invoice UI Service
    public class InvoiceUiService : IInvoiceUiService
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceUiService(IInvoiceService invoiceService) => _invoiceService = invoiceService;
        public async Task<ApiResponse<IEnumerable<InvoiceDto>>> GetInvoicesAsync(DateTimeOffset? startDate, DateTimeOffset? endDate, int pageIndex, int pageSize)
        {
            try
            {
                var data = await _invoiceService.GetAllAsync();// (startDate, endDate, pageIndex, pageSize);
                return ApiResponse<IEnumerable<InvoiceDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<InvoiceDto>>.Error($"Failed to fetch invoices: {ex.Message}"); }
        }
        public async Task<ApiResponse<InvoiceDto>> GetInvoiceByIdAsync(Guid id)
        {
            try
            {
                var data = await _invoiceService.GetByIdAsync(id);
                return data != null ? ApiResponse<InvoiceDto>.Success(data) : ApiResponse<InvoiceDto>.Error("Invoice not found.");
            }
            catch (Exception ex) { return ApiResponse<InvoiceDto>.Error($"Failed to fetch invoice: {ex.Message}"); }
        }
        public async Task<ApiResponse<IEnumerable<InvoiceDto>>> GetInvoicesByPartyIdAsync(Guid partyId)
        {
            try
            {
                var data = await _invoiceService.GetByPartyIdAsync(partyId);
                return ApiResponse<IEnumerable<InvoiceDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<InvoiceDto>>.Error($"Failed to fetch party invoices: {ex.Message}"); }
        }
    }

    // New: Tenant UI Service
    public class TenantUiService : ITenantUiService
    {
        private readonly ITenantService _tenantService;
        private readonly IDeviceService _deviceService;
        public TenantUiService(ITenantService tenantService, IDeviceService deviceService)
        {
            _tenantService = tenantService;
            _deviceService = deviceService;
        }
        public async Task<ApiResponse<IEnumerable<TenantDto>>> GetTenantsAsync(int pageIndex, int pageSize)
        {
            try
            {
                var data = await _tenantService.GetAllAsync();// (pageIndex, pageSize);
                return ApiResponse<IEnumerable<TenantDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<TenantDto>>.Error($"Failed to fetch tenants: {ex.Message}"); }
        }
        public async Task<ApiResponse<TenantDto>> GetTenantByIdAsync(Guid id)
        {
            try
            {
                var data = await _tenantService.GetByIdAsync(id);
                return data != null ? ApiResponse<TenantDto>.Success(data) : ApiResponse<TenantDto>.Error("Tenant not found.");
            }
            catch (Exception ex) { return ApiResponse<TenantDto>.Error($"Failed to fetch tenant: {ex.Message}"); }
        }
        public async Task<ApiResponse<IEnumerable<DeviceDto>>> GetTenantDevicesAsync(Guid tenantId)
        {
            try
            {
                var data = await _deviceService.GetDevicesByTenantAsync(tenantId);
                return ApiResponse<IEnumerable<DeviceDto>>.Success(data);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<DeviceDto>>.Error($"Failed to fetch devices: {ex.Message}"); }
        }
    }
}
