using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public interface IMapperService
    {
        PartyDto ToDto(Party party);
        Party ToEntity(PartyDto dto);

        ProductDto ToDto(Product product);
        Product ToEntity(ProductDto dto);

        InvoiceDto ToDto(Invoice invoice);
        Invoice ToEntity(InvoiceDto dto);

        SaleItemDto ToDto(SaleItem saleItem);
        SaleItem ToEntity(SaleItemDto dto);

        // Collection mappings
        IEnumerable<PartyDto> ToDto(IEnumerable<Party> entities);
        IEnumerable<Party> ToEntity(IEnumerable<PartyDto> dtos);

        IEnumerable<ProductDto> ToDto(IEnumerable<Product> entities);
        IEnumerable<Product> ToEntity(IEnumerable<ProductDto> dtos);

        IEnumerable<InvoiceDto> ToDto(IEnumerable<Invoice> entities);
        IEnumerable<Invoice> ToEntity(IEnumerable<InvoiceDto> dtos);

        IEnumerable<SaleItemDto> ToDto(IEnumerable<SaleItem> entities);
        IEnumerable<SaleItem> ToEntity(IEnumerable<SaleItemDto> dtos);
    }
}
