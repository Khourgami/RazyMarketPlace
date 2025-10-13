using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Interfaces.Repositories
{
    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAllAsync(CancellationToken ct = default);
        Task<Party?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Party?> GetByNormalizedLegacyIdAsync(string normalizedLegacyId, CancellationToken ct = default);
        Task<IEnumerable<Party>> GetByNameAsync(string namePart, CancellationToken ct = default);
    }
}
