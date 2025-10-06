using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RazySoft.MarketSync.Domain.DTOs;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Infrastructure.Configuration;

namespace RazySoft.MarketSync.Infrastructure.Api
{
    public class HttpApiClient : IApiTenant
    {
        private readonly HttpClient _http;
        private readonly InfrastructureOptions _options;
        private readonly ILogger<HttpApiClient> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public HttpApiClient(HttpClient http, InfrastructureOptions options, ILogger<HttpApiClient> logger)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Configure base address if provided
            if (!string.IsNullOrWhiteSpace(_options.ApiBaseUrl))
            {
                _http.BaseAddress = new Uri(_options.ApiBaseUrl.TrimEnd('/') + "/");
            }

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            _http.DefaultRequestHeaders.Add("X-Client-Id", options.TenantId);
            _http.DefaultRequestHeaders.Add("X-Device-Id", options.DeviceId);

        }

        public Task<bool> SendPartiesAsync(IEnumerable<PartyDto> parties, CancellationToken ct = default)
        {
            var endpoint = _options.PartiesEndpoint;
            return PostWithRetryAsync(endpoint, parties, ct);
        }

        public Task<bool> SendProductsAsync(IEnumerable<ProductDto> products, CancellationToken ct = default)
        {
            var endpoint = _options.ProductsEndpoint;
            return PostWithRetryAsync(endpoint, products, ct);
        }

        public Task<bool> SendInvoicesAsync(IEnumerable<InvoiceDto> invoices, CancellationToken ct = default)
        {
            var endpoint = _options.InvoicesEndpoint;
            return PostWithRetryAsync(endpoint, invoices, ct);
        }

        private async Task<bool> PostWithRetryAsync<T>(string relativeEndpoint, IEnumerable<T> payload, CancellationToken ct)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            var url = relativeEndpoint?.TrimStart('/') ?? throw new ArgumentNullException(nameof(relativeEndpoint));
            string json = JsonSerializer.Serialize(payload, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            int attempts = Math.Max(1, _options.HttpRetryCount);
            int delayMs = Math.Max(100, _options.HttpRetryDelayMs);

            for (int attempt = 1; attempt <= attempts; attempt++)
            {
                try
                {
                    _logger.LogDebug("POST {Url} (attempt {Attempt}/{Attempts}) payload size: {Size} bytes", url, attempt, attempts, json.Length);
                    using var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new StringContent(json, Encoding.UTF8, "application/json") };
                    var resp = await _http.SendAsync(req, ct).ConfigureAwait(false);

                    if (resp.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("POST {Url} succeeded (status {StatusCode})", url, resp.StatusCode);
                        return true;
                    }

                    var body = await resp.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
                    _logger.LogWarning("POST {Url} returned {StatusCode}. Body: {Body}", url, resp.StatusCode, body);

                    // For 4xx errors, do not retry (likely client issue)
                    if ((int)resp.StatusCode >= 400 && (int)resp.StatusCode < 500)
                    {
                        return false;
                    }
                }
                catch (OperationCanceledException) when (ct.IsCancellationRequested)
                {
                    _logger.LogWarning("POST {Url} cancelled by token.", url);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "POST {Url} attempt {Attempt} failed.", url, attempt);
                }

                // delay before next attempt (exponential backoff)
                await Task.Delay(delayMs * attempt, ct).ConfigureAwait(false);
            }

            _logger.LogError("POST {Url} failed after {Attempts} attempts.", relativeEndpoint, attempts);
            return false;
        }
    }
}
