using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class MapperService : IMapperService
    {
        public PartyDto ToDto(Party party) =>
            new PartyDto
            {
                Id = party.Id,
                NationalId = party.NationalId,
                Name = party.Name
            };

        public Party ToEntity(PartyDto dto) =>
            new Party
            {
                Id = dto.Id,
                NationalId = dto.NationalId,
                Name = dto.Name
            };

        public IEnumerable<PartyDto> ToDto(IEnumerable<Party> entities) =>
     entities.Select(ToDto);

        public IEnumerable<Party> ToEntity(IEnumerable<PartyDto> dtos) =>
            dtos.Select(ToEntity);

        public ProductDto ToDto(Product product) =>
            new ProductDto
            {
                Id = product.Id,
                cmFullCode = product.cmFullCode,
                Name = product.Name,
                Unit = product.Unit
            };

        public Product ToEntity(ProductDto dto) =>
            new Product
            {
                Id = dto.Id,
                cmFullCode = dto.cmFullCode,
                Name = dto.Name,
                Unit = dto.Unit
            };

        public IEnumerable<ProductDto> ToDto(IEnumerable<Product> entities) =>
    entities.Select(ToDto);

        public IEnumerable<Product> ToEntity(IEnumerable<ProductDto> dtos) =>
            dtos.Select(ToEntity);

        public InvoiceDto ToDto(Invoice invoice) =>
            new InvoiceDto
            {
                Id = invoice.Id,
                Date = invoice.Date,
                PartyId = invoice.PartyId,
                SaleItems = invoice.SaleItems.Select(ToDto).ToList()
            };

        public Invoice ToEntity(InvoiceDto dto) =>
            new Invoice
            {
                Id = dto.Id,
                Date = dto.Date,
                PartyId = dto.PartyId,
                SaleItems = dto.SaleItems.Select(ToEntity).ToList()
            };

        public IEnumerable<InvoiceDto> ToDto(IEnumerable<Invoice> entities) =>
    entities.Select(ToDto);

        public IEnumerable<Invoice> ToEntity(IEnumerable<InvoiceDto> dtos) =>
            dtos.Select(ToEntity);

        public SaleItemDto ToDto(SaleItem saleItem) =>
            new SaleItemDto
            {
                Id = saleItem.Id,
                InvoiceId = saleItem.InvoiceId,
                ProductId = saleItem.ProductId,
                Quantity = saleItem.Quantity
            };

        public SaleItem ToEntity(SaleItemDto dto) =>
            new SaleItem
            {
                Id = dto.Id,
                InvoiceId = dto.InvoiceId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

        public IEnumerable<SaleItemDto> ToDto(IEnumerable<SaleItem> entities) =>
    entities.Select(ToDto);

        public IEnumerable<SaleItem> ToEntity(IEnumerable<SaleItemDto> dtos) =>
            dtos.Select(ToEntity);
    }
}
