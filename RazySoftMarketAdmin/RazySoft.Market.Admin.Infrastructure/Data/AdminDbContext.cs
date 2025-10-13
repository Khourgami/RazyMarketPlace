using Microsoft.EntityFrameworkCore;
using RazySoft.Market.Admin.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RazySoft.Market.Admin.Infrastructure.Data
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Party> Parties => Set<Party>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Party
            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.NormalizedLegacyId);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.NormalizedLegacyId);
                entity.HasOne<Tenant>()
                      .WithMany()
                      .HasForeignKey(e => e.PartyId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.SaleItems)
                      .WithOne()
                      .HasForeignKey(e => e.InvoiceId);
            });

            // SaleItem
            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            // Tenant
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Identifier);
            });

            // Device
            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.DeviceId);
                entity.HasOne(e => e.Tenant)
                      .WithMany(t => t.Devices)
                      .HasForeignKey(e => e.TenantId);
            });
        }
    }
}
