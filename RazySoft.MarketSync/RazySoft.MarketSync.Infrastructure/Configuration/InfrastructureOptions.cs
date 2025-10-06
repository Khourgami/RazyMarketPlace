using System;

namespace RazySoft.MarketSync.Infrastructure.Configuration
{
    public class InfrastructureOptions
    {
        /// <summary>
        /// Connection string to local Sync DB (SQL Server).
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// Base URL of central API, e.g. https://api.company.com/api/sync
        /// </summary>
        public string ApiBaseUrl { get; set; } = string.Empty;

        /// <summary>
        /// Relative endpoints (optional override); defaults used by HttpApiClient if empty.
        /// </summary>
        public string PartiesEndpoint { get; set; } = "parties";
        public string ProductsEndpoint { get; set; } = "products";
        public string InvoicesEndpoint { get; set; } = "invoices";

        /// <summary>
        /// Number of attempts for HTTP retries.
        /// </summary>
        public int HttpRetryCount { get; set; } = 3;

        /// <summary>
        /// Delay in milliseconds between HTTP retries (exponential backoff applied).
        /// </summary>
        public int HttpRetryDelayMs { get; set; } = 1000;

        public string TenantId { get; set; }
        public string DeviceId { get; set; }
    }
}
