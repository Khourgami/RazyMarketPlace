using System;
using RazySoft.Market.Admin.Domain.Common;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// Represents an account (company or person) from MoinAcc table.
    /// We don’t distinguish between individual and organization here.
    /// </summary>
    public class Party : BaseEntity
    {
        /// <summary>
        /// Composite key from legacy DB (fk_ColCode + MoeinCode).
        /// </summary>
        public int FkColCode { get; set; }       // fk_ColCode
        public int MoeinCode { get; set; }       // MoeinCode

        /// <summary>
        /// Name of the account holder (company or person).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// NationalId or Company RegisterCode.
        /// </summary>
        public string? NationalId { get; set; }

        //public string? Phone { get; set; }

        //public string? Address { get; set; }

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; } = null!;

        /// <summary>
        /// Total quantity sold (aggregated, not per invoice).
        /// </summary>
        //public decimal TotalQuantitySold { get; set; }
    }
}
