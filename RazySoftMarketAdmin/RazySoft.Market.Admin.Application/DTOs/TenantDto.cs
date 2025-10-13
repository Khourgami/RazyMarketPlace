using System;
using System.Collections.Generic;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record TenantDto
    {
        public TenantDto(Guid id, string name, string? identifier, string? contact, bool isActive)
        {
            Id = id;
            Name = name;
            Identifier = identifier;
            Contact = contact;
            IsActive = isActive;
        }

        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Identifier { get; init; }
        public string? Contact { get; init; }
        public bool IsActive { get; init; }
        public DateTimeOffset CreatedAt { get; init; } = DateTime.Now;
        public DateTimeOffset? UpdatedAt { get; init; } = DateTime.Now;
    }
}
