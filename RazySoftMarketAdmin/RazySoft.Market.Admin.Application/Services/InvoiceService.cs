using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RazySoft.Market.Admin.Application.DTOs;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Application.Interfaces.Services;

namespace RazySoft.Market.Admin.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(IInvoiceRepository repo, ILogger<InvoiceService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto);
        }

        public async Task<InvoiceDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            return e == null ? null : ToDto(e);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default)
        {
            var list = await _repo.GetByPartyIdAsync(partyId, ct);
            return list.Select(ToDto);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByDateRangeAsync(DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default)
        {
            var list = await _repo.GetByDateRangeAsync(from, to, ct);
            return list.Select(ToDto);
        }

        private InvoiceDto ToDto(RazySoft.Market.Admin.Domain.Entities.Invoice e)
            => new InvoiceDto
            {
                Id = e.Id,
                PartyId = e.PartyId,
                Date = e.Date,
                TotalQuantity = e.TotalQuantity,
                Items = e.SaleItems?.Select(si => new SaleItemDto
                {
                    Id = si.Id,
                    InvoiceId = si.InvoiceId,
                    ProductId = si.ProductId,
                    Quantity = si.Quantity,
                    CreatedAt = si.CreatedAt,
                    UpdatedAt = si.UpdatedAt
                }).ToList() ?? new List<SaleItemDto>(),
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}
