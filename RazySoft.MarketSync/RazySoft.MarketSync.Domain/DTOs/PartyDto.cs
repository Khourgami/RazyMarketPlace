using System;
using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// DTO برای طرف‌های تجاری (MoeinAcc).
    /// این DTO شامل فیلدهای کلیدی fkColCode و moeinCode است.
    /// </summary>
    public record PartyDto : SyncDtoBase
    {
        /// <summary>
        /// fk_ColCode از جدول MoeinAcc (بخش اول کلید ترکیبی)
        /// </summary>
        [JsonPropertyName("fkColCode")]
        public int FkColCode { get; init; }

        /// <summary>
        /// MoeinCode از جدول MoeinAcc (بخش دوم کلید ترکیبی)
        /// </summary>
        [JsonPropertyName("moeinCode")]
        public int MoeinCode { get; init; }

        /// <summary>
        /// کد ملی یا شناسه شرکت (ممکن است برای بعضی رکوردها null باشد)
        /// </summary>
        [JsonPropertyName("NationalId")]
        public string? NationalId { get; init; }

        /// <summary>
        /// نام (MoeinName)
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// موبایل یا تلفن
        /// </summary>
        [JsonPropertyName("mobile")]
        public string? Mobile { get; init; }

        /// <summary>
        /// آدرس
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; init; }
    }
}
