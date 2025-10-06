using System;
using System.Collections.Generic;

namespace RazySoft.MarketSync.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime Date { get; set; }

        public Guid PartyId { get; set; }
        public Party Party { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();


    }
}
