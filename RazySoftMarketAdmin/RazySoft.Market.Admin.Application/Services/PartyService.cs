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
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _repo;
        private readonly ILogger<PartyService> _logger;

        public PartyService(IPartyRepository repo, ILogger<PartyService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<PartyDto>> GetAllAsync(CancellationToken ct = default)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto);
        }

        public async Task<PartyDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            return e == null ? null : ToDto(e);
        }

        public async Task<PartyDto?> GetByNormalizedIdAsync(string normalizedLegacyId, CancellationToken ct = default)
        {
            var e = await _repo.GetByNormalizedLegacyIdAsync(normalizedLegacyId, ct);
            return e == null ? null : ToDto(e);
        }

        public async Task<IEnumerable<PartyDto>> SearchByNameAsync(string namePart, CancellationToken ct = default)
        {
            var list = await _repo.GetByNameAsync(namePart, ct);
            return list.Select(ToDto);
        }

        private static PartyDto ToDto(RazySoft.Market.Admin.Domain.Entities.Party e)
            => new PartyDto
            {
                Id = e.Id,
                FkColCode = e.FkColCode,
                MoeinCode = e.MoeinCode,
                NationalId = e.NationalId,
                Name = e.Name,
                Mobile = e.Mobile,
                Address = e.Address,
                NormalizedLegacyId = e.NormalizedLegacyId,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}
