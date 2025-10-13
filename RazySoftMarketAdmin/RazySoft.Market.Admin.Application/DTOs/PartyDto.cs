using System;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record PartyDto
    {
        public Guid Id { get; init; }
        public int FkColCode { get; init; }
        public int MoeinCode { get; init; }
        public string? NationalId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Mobile { get; init; }
        public string? Address { get; init; }
        public string NormalizedLegacyId { get; init; } = string.Empty;
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? UpdatedAt { get; init; }
    }
}
