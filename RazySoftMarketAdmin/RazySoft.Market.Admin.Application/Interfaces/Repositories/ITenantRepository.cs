using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAllAsync(CancellationToken ct = default);
        Task<Tenant?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
