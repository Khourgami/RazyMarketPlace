using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Domain.Entities;
using RazySoft.Market.Admin.Infrastructure.Data;

namespace RazySoft.Market.Admin.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AdminDbContext _db;

        public DeviceRepository(AdminDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Device>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default)
            => await _db.Devices.AsNoTracking()
                .Where(x => x.TenantId == tenantId)
                .ToListAsync(ct);

        public async Task<Device?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _db.Devices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<Device?> GetByDeviceIdAsync(string deviceId, CancellationToken ct = default)
            => await _db.Devices.AsNoTracking().FirstOrDefaultAsync(x => x.DeviceId == deviceId, ct);
    }
}
