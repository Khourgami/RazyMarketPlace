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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repo, ILogger<ProductService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto);
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            return e == null ? null : ToDto(e);
        }

        public async Task<IEnumerable<ProductDto>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default)
        {
            var list = await _repo.GetByPartyIdAsync(partyId, ct);
            return list.Select(ToDto);
        }

        private static ProductDto ToDto(RazySoft.Market.Admin.Domain.Entities.Product e)
            => new ProductDto
            {
                Id = e.Id,
                CmFullCode = e.CmFullCode,
                NormalizedLegacyId = e.NormalizedLegacyId,
                Name = e.Name,
                Unit = e.Unit,
                PartyId = e.PartyId,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}
