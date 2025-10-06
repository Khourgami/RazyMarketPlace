using System.Collections.Generic;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class ImportResult
    {
        public List<Invoice> ChangedInvoices { get; set; } = new List<Invoice>();
        public List<Party> ChangedParties { get; set; } = new List<Party>();
        public List<Product> ChangedProducts { get; set; } = new List<Product>();
    }
}
