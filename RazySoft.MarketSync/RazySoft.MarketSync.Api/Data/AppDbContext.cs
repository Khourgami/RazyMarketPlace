using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Domain.Entities;

namespace RazySoft.MarketSync.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>()
                .HasIndex(b => b.NationalId)
                .IsUnique();

            modelBuilder.Entity<SaleItem>()
                .HasOne(s => s.Invoice)
                .WithMany(i => i.SaleItems)
                .HasForeignKey(s => s.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SaleItem>()
                .HasOne(s => s.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
