using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Core.Interfaces;

namespace RazySoft.MarketSync.Core.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ILogger<ValidationService> _logger;

        public ValidationService(ILogger<ValidationService> logger)
        {
            _logger = logger;
        }

        public bool ValidateParties(IEnumerable<PartyDto> parties)
        {
            var invalid = parties.Where(b => string.IsNullOrWhiteSpace(b.Name) || string.IsNullOrWhiteSpace(b.NationalId)).ToList();
            if (invalid.Any())
            {
                _logger.LogWarning("Found {Count} invalid parties.", invalid.Count);
                return false;
            }
            return true;
        }

        public bool ValidateProducts(IEnumerable<ProductDto> products)
        {
            var invalid = products.Where(p => string.IsNullOrWhiteSpace(p.Name) || string.IsNullOrWhiteSpace(p.Unit)).ToList();
            if (invalid.Any())
            {
                _logger.LogWarning("Found {Count} invalid products.", invalid.Count);
                return false;
            }
            return true;
        }

        public bool ValidateInvoices(IEnumerable<InvoiceDto> invoices)
        {
            var invalid = invoices.Where(i => i.SaleItems == null || !i.SaleItems.Any()).ToList();
            if (invalid.Any())
            {
                _logger.LogWarning("Found {Count} invalid invoices.", invalid.Count);
                return false;
            }
            return true;
        }
    }
}
