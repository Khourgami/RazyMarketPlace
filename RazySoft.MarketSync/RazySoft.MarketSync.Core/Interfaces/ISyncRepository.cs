using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazySoft.MarketSync.Core.Interfaces
{
    public interface ISyncRepository
    {
        Task<DateTime?> GetLastSyncTimeAsync(string entityType);
        Task UpdateLastSyncTimeAsync(string entityType, DateTime syncTime);
    }
}
