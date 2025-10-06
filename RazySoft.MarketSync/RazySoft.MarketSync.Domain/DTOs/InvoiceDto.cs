using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public Guid PartyId { get; set; }

        // در DTO فقط داده‌های لازم نگه می‌داریم
        public List<SaleItemDto> SaleItems { get; set; } = new();
    }
}
