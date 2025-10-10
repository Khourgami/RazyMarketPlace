using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Core.Interfaces;

namespace RazySoft.MarketSync.Core.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncStore _store;
        private readonly IApiTenant _api;
        private readonly IMapperService _mapper;
        private readonly IValidationService _validator;
        private readonly ILogger<SyncService> _logger;

        public SyncService(
            ISyncStore store,
            IApiTenant api,
            IMapperService mapper,
            IValidationService validator,
            ILogger<SyncService> logger)
        {
            _store = store;
            _api = api;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task RunSyncAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Starting sync cycle...");

            // Parties
            var parties = await _store.GetPendingPartiesAsync(ct);
            var partyDtos = _mapper.ToDto(parties);
            if (_validator.ValidateParties(partyDtos))
            {
                if (await _api.SendPartiesAsync(partyDtos, ct))
                {
                    foreach (var b in partyDtos)
                        await _store.MarkPartyAsSyncedAsync(b.LocalId.ToString(), true, ct);
                }
            }

            // Products
            var products = await _store.GetPendingProductsAsync(ct);
            var productDtos = _mapper.ToDto(products);
            if (_validator.ValidateProducts(productDtos))
            {
                if (await _api.SendProductsAsync(productDtos, ct))
                {
                    foreach (var p in productDtos)
                        await _store.MarkProductAsSyncedAsync(p.LocalId.ToString(), true, ct);
                }
            }

            // Invoices
            var invoices = await _store.GetPendingInvoicesAsync(ct);
            var invoiceDtos = _mapper.ToDto(invoices);
            if (_validator.ValidateInvoices(invoiceDtos))
            {
                if (await _api.SendInvoicesAsync(invoiceDtos, ct))
                {
                    foreach (var inv in invoiceDtos)
                        await _store.MarkInvoiceAsSyncedAsync(inv.LocalId.ToString(), true, ct);
                }
            }

            _logger.LogInformation("Sync cycle completed.");
        }
    }
}
