using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Application.DTOs;

namespace RazySoft.Market.Admin.Application.Interfaces.Services
{
    public interface ITenantService
    {
        Task<IEnumerable<TenantDto>> GetAllAsync(CancellationToken ct = default);
        Task<TenantDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
