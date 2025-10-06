using System;
using RazySoft.Market.Admin.Domain.Common;
using RazySoft.Market.Admin.Domain.Enums;

namespace RazySoft.Market.Admin.Domain.Entities
{
    /// <summary>
    /// Represents a physical installation/device where Windows Service runs.
    /// DeviceId is the id sent by the client in headers (X-Device-Id).
    /// </summary>
    public class Device : BaseEntity
    {
        /// <summary>
        /// Device unique id coming from client (can be a GUID or any string).
        /// </summary>
        public string DeviceId { get; set; } = string.Empty;

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; } = null!;

        public string? OperatingSystem { get; set; }

        public string? Description { get; set; }

        public DeviceStatus Status { get; set; } = DeviceStatus.Active;

        public DateTimeOffset? LastSeenAt { get; set; }
    }
}
