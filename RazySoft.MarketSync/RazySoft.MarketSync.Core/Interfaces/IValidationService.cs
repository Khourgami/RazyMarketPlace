using System.Collections.Generic;
using RazySoft.MarketSync.Domain.DTOs;

namespace RazySoft.MarketSync.Core.Interfaces
{
    public interface IValidationService
    {
        bool ValidateParties(IEnumerable<PartyDto> parties);
        bool ValidateProducts(IEnumerable<ProductDto> products);
        bool ValidateInvoices(IEnumerable<InvoiceDto> invoices);
    }
}
