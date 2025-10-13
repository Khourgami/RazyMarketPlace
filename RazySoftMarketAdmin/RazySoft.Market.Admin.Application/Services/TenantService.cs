using Microsoft.Extensions.Logging;
using RazySoft.Market.Admin.Application.DTOs;
using RazySoft.Market.Admin.Application.Interfaces.Repositories;
using RazySoft.Market.Admin.Application.Interfaces.Services;
using RazySoft.Market.Admin.Domain.Entities;

namespace RazySoft.Market.Admin.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ILogger<TenantService> _logger;

        public TenantService(ITenantRepository tenantRepository, ILogger<TenantService> logger)
        {
            _tenantRepository = tenantRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<TenantDto>> GetAllAsync(CancellationToken ct = default)
        {
            var tenants = await _tenantRepository.GetAllAsync(ct);
            return tenants.Select(MapToDto);
        }

        public async Task<TenantDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id, ct);
            return tenant is null ? null : MapToDto(tenant);
        }

        //public async Task<TenantDto> CreateAsync(TenantDto dto, CancellationToken ct = default)
        //{
        //    var entity = new Tenant
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = dto.Name,
        //        Identifier = dto.Identifier,
        //        Contact = dto.Contact,
        //        IsActive = dto.IsActive
        //    };

        //    await _tenantRepository.AddAsync(entity, ct);
        //    await _tenantRepository.SaveChangesAsync(ct);

        //    _logger.LogInformation("Tenant created: {Name}", dto.Name);

        //    return MapToDto(entity);
        //}

        //public async Task<TenantDto?> UpdateAsync(Guid id, TenantDto dto, CancellationToken ct = default)
        //{
        //    var entity = await _tenantRepository.GetByIdAsync(id, ct);
        //    if (entity == null)
        //    {
        //        _logger.LogWarning("Tenant not found: {Id}", id);
        //        return null;
        //    }

        //    entity.Name = dto.Name;
        //    entity.Identifier = dto.Identifier;
        //    entity.Contact = dto.Contact;
        //    entity.IsActive = dto.IsActive;
        //    entity.Touch();

        //    await _tenantRepository.UpdateAsync(entity, ct);
        //    await _tenantRepository.SaveChangesAsync(ct);

        //    _logger.LogInformation("Tenant updated: {Id}", id);
        //    return MapToDto(entity);
        //}

        //public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        //{
        //    var entity = await _tenantRepository.GetByIdAsync(id, ct);
        //    if (entity == null) return false;

        //    await _tenantRepository.DeleteAsync(entity, ct);
        //    await _tenantRepository.SaveChangesAsync(ct);

        //    _logger.LogInformation("Tenant deleted: {Id}", id);
        //    return true;
        //}

        // Mapping helper
        private static TenantDto MapToDto(Tenant t) =>
            new TenantDto(t.Id, t.Name, t.Identifier, t.Contact, t.IsActive);
    }
}
