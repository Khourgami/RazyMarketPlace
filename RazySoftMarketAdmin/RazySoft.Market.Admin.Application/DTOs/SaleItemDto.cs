using System;

namespace RazySoft.Market.Admin.Application.DTOs
{
    public record SaleItemDto
    {
        public Guid Id { get; init; }
        public Guid InvoiceId { get; init; }
        public Guid ProductId { get; init; }
        public decimal Quantity { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? UpdatedAt { get; init; }
    }
}
