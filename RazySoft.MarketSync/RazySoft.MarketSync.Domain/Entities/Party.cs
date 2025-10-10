using System;

namespace RazySoft.MarketSync.Domain.Entities
{
    /// <summary>
    /// موجودیت مربوط به طرف‌های تجاری (MoeinAcc)
    /// </summary>
    public class Party : BaseEntity
    {
        /// <summary>
        /// کلید ترکیبی از سیستم قدیمی — برای ارتباط با داده‌های Legacy
        /// </summary>
        public int FkColCode { get; set; }
        public int MoeinCode { get; set; }

        /// <summary>
        /// کد شناسایی ملی یا کد ثبت شرکت (ممکن است null باشد)
        /// </summary>
        public string? NationalId { get; set; }

        /// <summary>
        /// نام فرد یا شرکت
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// شماره تلفن یا موبایل
        /// </summary>
        public string? Mobile { get; set; }

        /// <summary>
        /// آدرس
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// شناسه نرمال‌شده برای ارتباط با داده‌های legacy (مثلاً "fk-moein")
        /// </summary>
        public string NormalizedLegacyId { get; set; } = string.Empty;
    }
}
