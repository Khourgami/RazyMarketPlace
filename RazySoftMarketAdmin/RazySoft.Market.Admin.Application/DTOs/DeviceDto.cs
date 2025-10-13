using System;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record DeviceDto
    {
        public Guid Id { get; init; }
        public string DeviceId { get; init; } = string.Empty;
        public Guid TenantId { get; init; }
        public string? OperatingSystem { get; init; }
        public string? Description { get; init; }
        public string Status { get; init; } = string.Empty;
        public DateTimeOffset? LastSeenAt { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? UpdatedAt { get; init; }
    }
}
