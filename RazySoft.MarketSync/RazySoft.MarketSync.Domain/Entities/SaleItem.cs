using System;

namespace RazySoft.MarketSync.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Quantity { get; set; }

    }
}
