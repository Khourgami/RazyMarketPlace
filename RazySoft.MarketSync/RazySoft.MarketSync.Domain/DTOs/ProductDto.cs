using System;
using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// DTO برای محصولات.
    /// کلید شناسایی در سیستم قدیمی: cmFullCode
    /// </summary>
    public record ProductDto : SyncDtoBase
    {
        /// <summary>
        /// cmFullCode (کلید شناسایی محصول در سیستم قدیمی).
        /// این فیلد پایهٔ NormalizedLegacyId هم میتواند باشد.
        /// </summary>
        [JsonPropertyName("cmFullCode")]
        public string CmFullCode { get; init; } = string.Empty;

        /// <summary>
        /// نام محصول
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// واحد (مثل "kg", "pcs", "m")
        /// </summary>
        [JsonPropertyName("unit")]
        public string Unit { get; init; } = string.Empty;
        public Guid PartyId { get; set; }
    }
}
