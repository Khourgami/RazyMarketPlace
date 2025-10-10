using System;

namespace RazySoft.MarketSync.Domain.Entities
{
    /// <summary>
    /// کلاس پایه برای تمام Entityها — دارای Id از نوع Guid و اطلاعات سینک.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TenantId { get; set; }
        /// <summary>
        /// مشخص می‌کند آیا این رکورد از سمت ویندوز سرویس به سرور سینک شده یا نه.
        /// </summary>
        public bool IsSynced { get; set; } = false;

        /// <summary>
        /// زمان آخرین تغییر یا بروزرسانی رکورد
        /// </summary>
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}
