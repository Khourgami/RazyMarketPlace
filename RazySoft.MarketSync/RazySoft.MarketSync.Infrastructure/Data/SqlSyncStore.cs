using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Domain.Entities;
using System.Data;

namespace RazySoft.MarketSync.Infrastructure.Data
{
    public class SqlSyncStore : ISyncStore, IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection? _connection;

        public SqlSyncStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SyncDb")
                ?? throw new InvalidOperationException("SyncDb connection string not found.");
        }

        private async Task<SqlConnection> GetOpenConnectionAsync(CancellationToken ct = default)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                await _connection.OpenAsync(ct);
            }
            else if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync(ct);
            }

            return _connection;
        }

        public async Task<IEnumerable<Party>> GetPendingPartiesAsync(CancellationToken ct = default)
        {
            var result = new List<Party>();
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_GetPendingPartis", conn) { CommandType = CommandType.StoredProcedure };
            using var reader = await cmd.ExecuteReaderAsync(ct);

            while (await reader.ReadAsync(ct))
            {
                result.Add(new Party
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    NationalId = reader.GetString(reader.GetOrdinal("NationalId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                });
            }

            return result;
        }

        public async Task<IEnumerable<Product>> GetPendingProductsAsync(CancellationToken ct = default)
        {
            var result = new List<Product>();
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_GetPendingProducts", conn) { CommandType = CommandType.StoredProcedure };
            using var reader = await cmd.ExecuteReaderAsync(ct);

            while (await reader.ReadAsync(ct))
            {
                result.Add(new Product
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    cmFullCode = reader.GetString(reader.GetOrdinal("cmFullCode")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Unit = reader.GetString(reader.GetOrdinal("Unit"))
                });
            }

            return result;
        }

        public async Task<IEnumerable<Invoice>> GetPendingInvoicesAsync(CancellationToken ct = default)
        {
            var result = new List<Invoice>();
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_GetPendingInvoices", conn) { CommandType = CommandType.StoredProcedure };
            using var reader = await cmd.ExecuteReaderAsync(ct);

            while (await reader.ReadAsync(ct))
            {
                result.Add(new Invoice
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                    PartyId = reader.GetGuid(reader.GetOrdinal("PartyId"))
                });
            }

            return result;
        }

        public async Task MarkPartyAsSyncedAsync(string partyId, bool success, CancellationToken ct = default)
        {
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_MarkPartyAsSynced", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@PartyId", partyId);
            cmd.Parameters.AddWithValue("@Success", success);
            await cmd.ExecuteNonQueryAsync(ct);
        }

        public async Task MarkProductAsSyncedAsync(string productId, bool success, CancellationToken ct = default)
        {
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_MarkProductAsSynced", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Success", success);
            await cmd.ExecuteNonQueryAsync(ct);
        }

        public async Task MarkInvoiceAsSyncedAsync(string invoiceId, bool success, CancellationToken ct = default)
        {
            var conn = await GetOpenConnectionAsync(ct);

            using var cmd = new SqlCommand("sp_MarkInvoiceAsSynced", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@InvoiceId", invoiceId);
            cmd.Parameters.AddWithValue("@Success", success);
            await cmd.ExecuteNonQueryAsync(ct);
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
