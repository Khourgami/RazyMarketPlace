using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Product>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default);
        Task<Product?> GetByNormalizedLegacyIdAsync(string normalizedLegacyId, CancellationToken ct = default);
    }
}
