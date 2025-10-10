using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public class MapperService : IMapperService
    {
        public PartyDto ToDto(Party entity) =>
            new PartyDto
            {                
                LocalId = entity.Id,
                LegacyId = $"{entity.FkColCode}-{entity.MoeinCode}",
                NormalizedLegacyId = entity.NormalizedLegacyId,
                FkColCode = entity.FkColCode,
                MoeinCode = entity.MoeinCode,
                NationalId = entity.NationalId,
                Name = entity.Name,
                Address = entity.Address,
                Mobile = entity.Mobile
            };

        public Party ToEntity(PartyDto dto) =>
            new Party
            {
                Id = dto.LocalId,
                NormalizedLegacyId = dto.NormalizedLegacyId,
                FkColCode = dto.FkColCode,
                MoeinCode = dto.MoeinCode,
                NationalId = dto.NationalId,
                Name = dto.Name,
                Address = dto.Address,
                Mobile = dto.Mobile,
                IsSynced = false,
                LastModified = DateTime.UtcNow
            };

        public IEnumerable<PartyDto> ToDto(IEnumerable<Party> entities) =>
         entities.Select(ToDto);

        public IEnumerable<Party> ToEntity(IEnumerable<PartyDto> dtos) =>
            dtos.Select(ToEntity);

        public ProductDto ToDto(Product entity) =>
            new ProductDto
            {
                LocalId = entity.Id,                
                LegacyId = entity.CmFullCode,
                NormalizedLegacyId = entity.NormalizedLegacyId,
                PartyId = entity.PartyId,
                CmFullCode = entity.CmFullCode,
                Name = entity.Name,
                Unit = entity.Unit
            };

        public Product ToEntity(ProductDto dto) =>
            new Product
            {
                Id = Guid.NewGuid(),
                NormalizedLegacyId = dto.NormalizedLegacyId,
                PartyId = dto.PartyId,
                CmFullCode = dto.CmFullCode,
                Name = dto.Name,
                Unit = dto.Unit,
                IsSynced = false,
                LastModified = DateTime.UtcNow
            };

        public IEnumerable<ProductDto> ToDto(IEnumerable<Product> entities) =>
    entities.Select(ToDto);

        public IEnumerable<Product> ToEntity(IEnumerable<ProductDto> dtos) =>
            dtos.Select(ToEntity);

        public InvoiceDto ToDto(Invoice entity) =>
            new InvoiceDto
            {
                PartyId = entity.PartyId,
                Date = entity.Date,
                TotalQuantity = entity.TotalQuantity,
                SaleItems = entity.SaleItems?.Select(ToDto).ToList() ?? new List<SaleItemDto>()
            };

        public Invoice ToEntity(InvoiceDto dto) =>
            new Invoice
            {   PartyId = dto.PartyId,
                Date = dto.Date,
                TotalQuantity = dto.TotalQuantity,
                IsSynced = false,
                LastModified = DateTime.UtcNow,
                SaleItems = dto.SaleItems?.Select(ToEntity).ToList() ?? new List<SaleItem>()
            };

        public IEnumerable<InvoiceDto> ToDto(IEnumerable<Invoice> entities) =>
    entities.Select(ToDto);

        public IEnumerable<Invoice> ToEntity(IEnumerable<InvoiceDto> dtos) =>
            dtos.Select(ToEntity);

        public SaleItemDto ToDto(SaleItem entity) =>
            new SaleItemDto
            { 
                ProductId = entity.ProductId,
                Quantity = entity.Quantity
            };

        public SaleItem ToEntity(SaleItemDto dto) =>
            new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                IsSynced = false,
                LastModified = DateTime.UtcNow
            };

        public IEnumerable<SaleItemDto> ToDto(IEnumerable<SaleItem> entities) =>
    entities.Select(ToDto);

        public IEnumerable<SaleItem> ToEntity(IEnumerable<SaleItemDto> dtos) =>
            dtos.Select(ToEntity);
    }
}
