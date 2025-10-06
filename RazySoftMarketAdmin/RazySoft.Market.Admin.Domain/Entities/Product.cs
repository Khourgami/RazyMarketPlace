using System;
using RazySoft.Market.Admin.Domain.Common;

namespace RazySoft.Market.Admin.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string LegacyId { get; set; } = string.Empty;

        public string NormalizedLegacyId { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Unit { get; set; } = string.Empty; // e.g. kg, pcs

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; } = null!;
    }
}
