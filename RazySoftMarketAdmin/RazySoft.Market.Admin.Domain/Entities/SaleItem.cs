using RazySoft.Market.Admin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// آیتم فروش مربوط به فاکتور — شامل شناسه محصول و مقدار
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// شناسه فاکتور والد
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// مقدار فروخته‌شده
        /// </summary>
        public decimal Quantity { get; set; }


    }
}
