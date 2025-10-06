using Microsoft.AspNetCore.Mvc;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Services
{
    public interface IPartyService
    {
        Task SaveReceivedPartiesAsync(IEnumerable<Party> parties, string tenantId, string deviceId, CancellationToken ct = default);
    }

}
