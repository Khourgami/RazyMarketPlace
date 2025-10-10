using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// DTO برای فاکتورها — شامل لیست SaleItemDto.
    /// برای شناسایی Party از PartyNormalizedId استفاده می‌کنیم و Tenant از Party به‌دست می‌آید.
    /// </summary>
    public record InvoiceDto : SyncDtoBase
    {

        /// <summary>
        /// تاریخ فاکتور (اگر موجود نباشد، سمت سرور میتواند تاریخ پردازش را قرار دهد)
        /// </summary>
        [JsonPropertyName("date")]
        public DateTimeOffset? Date { get; init; }

        /// <summary>
        /// جمع مقدار (تعداد/کیلو/متر) — چون قیمت در این بازارچه مهم نیست.
        /// این فیلد اختیاری است؛ همچنین میتوان از مجموع SaleItems محاسبه شود.
        /// </summary>
        [JsonPropertyName("totalQuantity")]
        public decimal? TotalQuantity { get; init; }

        /// <summary>
        /// آیتم‌های فاکتور که در همان payload ارسال می‌شوند.
        /// </summary>
        [JsonPropertyName("items")]
        public IEnumerable<SaleItemDto> SaleItems { get; init; } = Array.Empty<SaleItemDto>();
        public Guid PartyId { get; set; }
    }
}
