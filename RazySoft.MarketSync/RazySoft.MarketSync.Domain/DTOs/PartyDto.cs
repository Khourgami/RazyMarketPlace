using System;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class PartyDto
    {
        public Guid Id { get; set; }
        // System Legacy Id
        public int FkColCode { get; set; }
        
        // System Legacy Id
        public int MoeinCode { get; set; }
        public string? NationalId { get; set; }
        public string? Name { get; set; }
    }
}
