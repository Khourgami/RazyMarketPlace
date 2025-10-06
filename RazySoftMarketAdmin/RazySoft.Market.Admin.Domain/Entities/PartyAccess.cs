using System;
using RazySoft.Market.Admin.Domain.Common;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// Defines which parties are visible to which clients (permissions).
    /// A seller can decide which accounts (parties) can see their sales data.
    /// </summary>
    public class PartyAccess : BaseEntity
    {
        public Guid SellerTenantId { get; set; }

        public Guid PartyId { get; set; }

        public bool CanSeeSales { get; set; } = true;

        public DateTimeOffset GrantedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
