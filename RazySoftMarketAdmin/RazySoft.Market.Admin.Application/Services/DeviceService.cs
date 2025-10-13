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
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;
        private readonly ILogger<DeviceService> _logger;

        public DeviceService(IDeviceRepository deviceRepo, ILogger<DeviceService> logger)
        {
            _deviceRepo = deviceRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<DeviceDto>> GetDevicesByTenantAsync(Guid tenantId, CancellationToken ct = default)
        {
            var list = await _deviceRepo.GetAllByTenantAsync(tenantId, ct);
            return list.Select(ToDto);
        }

        public async Task<DeviceDto?> GetDeviceByIdAsync(Guid id, CancellationToken ct = default)
        {
            var d = await _deviceRepo.GetByIdAsync(id, ct);
            return d == null ? null : ToDto(d);
        }

        public async Task<DeviceDto?> GetDeviceByDeviceIdAsync(string deviceId, CancellationToken ct = default)
        {
            var d = await _deviceRepo.GetByDeviceIdAsync(deviceId, ct);
            return d == null ? null : ToDto(d);
        }

        private static DeviceDto ToDto(RazySoft.Market.Admin.Domain.Entities.Device e)
            => new DeviceDto
            {
                Id = e.Id,
                DeviceId = e.DeviceId,
                TenantId = e.TenantId,
                OperatingSystem = e.OperatingSystem,
                Description = e.Description,
                Status = e.Status.ToString(),
                LastSeenAt = e.LastSeenAt,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}
