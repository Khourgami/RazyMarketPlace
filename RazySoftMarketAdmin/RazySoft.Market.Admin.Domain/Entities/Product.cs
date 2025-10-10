using System;
using RazySoft.Market.Admin.Domain.Common;

namespace RazySoft.Market.Admin.Domain.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// شناسه نرمال‌شده (معمولاً cmFullCode)
        /// </summary>
        public string NormalizedLegacyId { get; set; } = string.Empty;

        /// <summary>
        /// کد محصول در سیستم قدیمی
        /// </summary>
        public string CmFullCode { get; set; } = string.Empty;

        /// <summary>
        /// نام محصول
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// واحد اندازه‌گیری
        /// </summary>
        public string Unit { get; set; } = string.Empty;

        /// <summary>
        /// PartyId برای اتصال داده‌ها به کلاینت خاص
        /// </summary>
        public Guid PartyId { get; set; }
    }
}
