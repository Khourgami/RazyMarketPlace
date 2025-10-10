using System;
using System.Text.Json.Serialization;

namespace RazySoft.MarketSync.Domain.DTOs
{
    /// <summary>
    /// آیتم فاکتور — به عنوان child داخل InvoiceDto منتقل می‌شود.
    /// توجه: قیمت برای بازارچه مهم نیست، فقط مقدار و واحد اهمیت دارد.
    /// </summary>
    public record SaleItemDto : SyncDtoBase
    {
        /// <summary>
        /// شناسه نرمال‌شده محصول (معمولاً cmFullCode یا NormalizedLegacyId محصول)
        /// </summary>
        [JsonPropertyName("ProductId")]
        public Guid ProductId { get; init; } = Guid.NewGuid();

        /// <summary>
        /// مقدار فروخته‌شده (تعداد/متر/کیلو)
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; init; }

    }
}
