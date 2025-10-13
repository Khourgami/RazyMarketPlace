using System;
using System.Collections.Generic;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record InvoiceDto
    {
        public Guid Id { get; init; }
        public Guid PartyId { get; init; }
        public DateTimeOffset? Date { get; init; }
        public decimal? TotalQuantity { get; init; }
        public IEnumerable<SaleItemDto> Items { get; init; } = Array.Empty<SaleItemDto>();
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? UpdatedAt { get; init; }
    }
}
