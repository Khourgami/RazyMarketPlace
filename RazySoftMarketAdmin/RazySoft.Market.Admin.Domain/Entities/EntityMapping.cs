using System;
using RazySoft.Market.Admin.Domain.Common;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// Mapping between legacy ids (local systems) and central GUID entities.
    /// This single mapping table can store mappings for Parties, Products, Invoices, etc.
    /// </summary>
    public class EntityMapping : BaseEntity
    {
        /// <summary>
        /// Tenant / Client GUID (the owner of the legacy data).
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Entity type as string, e.g. "Party", "Product", "Invoice"
        /// </summary>
        public string EntityType { get; set; } = string.Empty;

        /// <summary>
        /// Raw legacy id (as in old DB, e.g. "fk_ColCode|MoeinCode" or "12345")
        /// </summary>
        public string LegacyId { get; set; } = string.Empty;

        /// <summary>
        /// Optional parts of composite legacy id (if present).
        /// </summary>
        public string? LegacyIdPart1 { get; set; }
        public string? LegacyIdPart2 { get; set; }

        /// <summary>
        /// Normalized legacy id (consistent format for lookup).
        /// </summary>
        public string NormalizedLegacyId { get; set; } = string.Empty;

        /// <summary>
        /// Optional business identifiers:
        /// NationalId for individuals, RegisterCode/EconomicCode for organizations.
        /// </summary>
        public string? NationalId { get; set; }
        public string? RegisterCode { get; set; }
        public string? EconomicCode { get; set; }

        /// <summary>
        /// Central GUID of the mapped entity (Party.Id, Product.Id, Invoice.Id, ...)
        /// </summary>
        public Guid EntityId { get; set; }

        public string? SourceSystem { get; set; }

        public DateTimeOffset? SourceLastModified { get; set; }

        /// <summary>
        /// Optional data hash to detect content changes.
        /// </summary>
        public byte[]? DataHash { get; set; }
    }
}
