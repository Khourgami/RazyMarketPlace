using RazySoft.Market.Admin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// فاکتور فروش یا خرید — شامل لیستی از SaleItemها
    /// </summary>
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// شناسه Party مرتبط (خریدار یا فروشنده)
        /// </summary>
        public Guid PartyId { get; set; }


        /// <summary>
        /// تاریخ فاکتور
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// مجموع مقدار فروخته‌شده (اختیاری)
        /// </summary>
        public decimal? TotalQuantity { get; set; }

        /// <summary>
        /// آیتم‌های این فاکتور
        /// </summary>
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
