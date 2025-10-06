using System;
using System.Collections.Generic;
using RazySoft.Market.Admin.Domain.Common;
using RazySoft.Market.Admin.Domain.Enums;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// Represents a tenant / client (banker / wholesaler / company).
    /// This is the central "Tenant" entity in the admin domain.
    /// </summary>
    public class Tenant : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;

        public string? Identifier { get; set; }

        public string? Contact { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Device> Devices { get; set; } = new List<Device>();

        // Navigation collections for domain entities can be added as needed (Parties, Products...)
    }
}
