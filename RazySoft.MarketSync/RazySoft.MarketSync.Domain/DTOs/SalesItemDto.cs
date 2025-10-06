using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class SaleItemDto : BaseEntity
    {

        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
