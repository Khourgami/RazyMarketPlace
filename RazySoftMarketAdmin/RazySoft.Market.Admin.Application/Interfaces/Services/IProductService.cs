using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RazySoft.Market.Admin.Application.DTOs;

namespace RazySoft.Market.Admin.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default);
        Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<ProductDto>> GetByPartyIdAsync(Guid partyId, CancellationToken ct = default);
    }
}
