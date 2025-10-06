using System;

namespace RazySoft.MarketSync.Domain.Entities
{
    public class Party : BaseEntity
    {

        // Legacy composite key parts from MoeinAcc
        public int FkColCode { get; set; }       // fk_ColCode
        public int MoeinCode { get; set; }       // MoeinCode
        // National code (could be national id or company register code)
        public string? NationalId { get; set; }
        public Guid TenantId {  get; set; }

        // Name (MoeinName in legacy)
        public string Name { get; set; } = string.Empty;

    }
}
