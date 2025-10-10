using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Data
{
    public class MarketSyncDbContext : DbContext
    {
        public MarketSyncDbContext(DbContextOptions<MarketSyncDbContext> options) : base(options) { }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>()
                .HasIndex(b => b.NationalId)
                .IsUnique();

        }
    }
}
