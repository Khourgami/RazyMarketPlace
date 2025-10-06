using RazySoft.MarketSync.Domain.DTOs;
using System;

namespace RazySoft.MarketSync.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string cmFullCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty; // Kg, Meter, Count
        public Guid PartyId { get; set; }
        public Party Party { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
