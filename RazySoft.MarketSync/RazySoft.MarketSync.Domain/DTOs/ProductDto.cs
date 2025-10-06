using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class ProductDto
    {
        // Legacy Id
        public Guid Id { get; set; }
        public string cmFullCode {  get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        
    }
}
