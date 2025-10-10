using System;

namespace RazySoft.Market.Admin.Domain.Common
{
    /// <summary>
    /// Base class for all domain entities.
    /// Provides Id, CreatedAt, UpdatedAt.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public Guid Tenantid { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdatedAt { get; protected set; }

        public void Touch() => UpdatedAt = DateTimeOffset.UtcNow;
    }
}
