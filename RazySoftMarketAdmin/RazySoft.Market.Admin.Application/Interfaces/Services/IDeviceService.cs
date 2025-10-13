using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Application.DTOs;

namespace RazySoft.Market.Admin.Application.Interfaces.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetDevicesByTenantAsync(Guid tenantId, CancellationToken ct = default);
        Task<DeviceDto?> GetDeviceByIdAsync(Guid id, CancellationToken ct = default);
        Task<DeviceDto?> GetDeviceByDeviceIdAsync(string deviceId, CancellationToken ct = default);
    }
}
