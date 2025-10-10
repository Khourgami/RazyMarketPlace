using System;
using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// پایهٔ DTO برای عملیات سینک — شامل فیلدهای مشترک بین همهٔ payloadها.
    /// </summary>
    public record SyncDtoBase
    {
        /// <summary>
        /// شناسه‌ای که کلاینت محلی ممکن است برای رکورد خود تولید کند (اختیاری).
        /// این مقدار صرفاً برای trace/log و debug در client-server استفاده میشود.
        /// </summary>
        [JsonPropertyName("localId")]
        public Guid LocalId { get; init; }

        /// <summary>
        /// شناسه legacy خام (مثلاً composite key یا شماره فاکتور در دیتابیس قدیمی).
        /// </summary>
        [JsonPropertyName("legacyId")]
        public string? LegacyId { get; init; }

        /// <summary>
        /// شناسه نرمال‌شده که برای lookup سریع و یکتا شدن بین tenant+entity استفاده می‌شود.
        /// (مثلاً "fk-moein" برای Party یا cmFullCode برای Product)
        /// </summary>
        [JsonPropertyName("normalizedLegacyId")]
        public string NormalizedLegacyId { get; init; } = string.Empty;

        /// <summary>
        /// زمان آخرین تغییر در منبع (در صورت وجود)
        /// </summary>
        [JsonPropertyName("sourceLastModified")]
        public DateTimeOffset? SourceLastModified { get; init; }

        /// <summary>
        /// هش دادهٔ محتوا (مثلاً SHA256) که اگر کلاینت تولید می‌کند می‌تواند برای تشخیص تغییر استفاده شود.
        /// </summary>
        [JsonPropertyName("dataHash")]
        public byte[]? DataHash { get; init; }
    }
}
