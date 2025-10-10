using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    //public interface IInvoiceService
    //{
    //    Task<SyncResultDto> SyncAsync(IEnumerable<InvoiceDto> items, string tenantId, string deviceId, CancellationToken ct = default);
    //}

    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly ISaleItemRepository _saleItemRepo;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(
            IInvoiceRepository invoiceRepo,
            ISaleItemRepository saleItemRepo,
            ILogger<InvoiceService> logger)
        {
            _invoiceRepo = invoiceRepo;
            _saleItemRepo = saleItemRepo;
            _logger = logger;
        }

        public async Task<SyncResultDto> SyncAsync(IEnumerable<InvoiceDto> items, string tenantId, string deviceId, CancellationToken ct = default)
        {
            var result = new SyncResultDto();
            if (!Guid.TryParse(tenantId, out var tenantGuid))
                return result;

            foreach (var dto in items)
            {
                var normalized = dto.NormalizedLegacyId;
                if (string.IsNullOrWhiteSpace(normalized)) continue;

                var existing = await _invoiceRepo.GetByNormalizedIdAsync(normalized, tenantGuid, ct);

                if (existing == null)
                {
                    var invoice = new Invoice
                    {
                        Id = dto.LocalId,
                        TenantId = tenantGuid,
                        PartyId = dto.PartyId,
                        Date = dto.Date ?? DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        SaleItems = dto.SaleItems?.Select(si => new SaleItem
                        {
                            Id = si.LocalId,
                            Quantity = si.Quantity,
                            ProductId = si.ProductId,
                            InvoiceId = dto.LocalId,
                            LastModified = DateTime.UtcNow
                        }).ToList()
                    };

                    await _invoiceRepo.AddAsync(invoice, ct);
                    result.Inserted++;
                }
                else
                {
                    existing.TotalQuantity = dto.TotalQuantity;
                    existing.LastModified = DateTime.UtcNow;
                    await _invoiceRepo.UpdateAsync(existing, ct);
                    result.Updated++;
                }
            }

            await _invoiceRepo.SaveChangesAsync(ct);
            return result;
        }
    }
}
