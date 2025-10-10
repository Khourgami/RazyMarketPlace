using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// نتیجهٔ خلاصهٔ عملیات سینک — برگشتی از سرویس‌ها به کنترلر.
    /// </summary>
    public record SyncResultDto
    {
        [JsonPropertyName("inserted")]
        public int Inserted { get; set; }

        [JsonPropertyName("updated")]
        public int Updated { get; set; }

        [JsonPropertyName("unchanged")]
        public int Unchanged { get; set; }

        [JsonPropertyName("skipped")]
        public int Skipped { get; set; }

        public SyncResultDto(int inserted = 0, int updated = 0, int unchanged = 0, int skipped = 0)
        {
            Inserted = inserted;
            Updated = updated;
            Unchanged = unchanged;
            Skipped = skipped;
        }
    }
}
