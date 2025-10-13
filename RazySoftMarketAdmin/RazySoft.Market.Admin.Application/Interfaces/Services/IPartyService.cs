using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Application.DTOs;

namespace RazySoft.Market.Admin.Application.Interfaces.Services
{
    public interface IPartyService
    {
        Task<IEnumerable<PartyDto>> GetAllAsync(CancellationToken ct = default);
        Task<PartyDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<PartyDto?> GetByNormalizedIdAsync(string normalizedLegacyId, CancellationToken ct = default);
        Task<IEnumerable<PartyDto>> SearchByNameAsync(string namePart, CancellationToken ct = default);
    }
}
