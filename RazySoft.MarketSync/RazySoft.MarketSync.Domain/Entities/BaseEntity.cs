using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        // Metadata for source (optional, useful for change detection)
        public bool IsSynced { get; set; } = false;
        public DateTimeOffset LastModified { get; set; } = DateTime.UtcNow;
        public DateTime? SourceLastModified { get; set; }

        // Optional: data hash (SHA256) to detect content changes (nullable)
        public byte[]? DataHash { get; set; }

    }
}
