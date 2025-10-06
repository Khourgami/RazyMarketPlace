using System.Collections.Generic;

namespace RazySoft.MarketSync.Domain.DTOs
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
