using System;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public string CmFullCode { get; init; } = string.Empty;
        public string NormalizedLegacyId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Unit { get; init; } = string.Empty;
        public Guid PartyId { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? UpdatedAt { get; init; }
    }
}
