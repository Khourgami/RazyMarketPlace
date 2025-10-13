using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default);
        Task<Device?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Device?> GetByDeviceIdAsync(string deviceId, CancellationToken ct = default);
    }
}
