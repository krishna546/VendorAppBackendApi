using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vendormachineapi.Models
{
    public partial class VendorDBContext : DbContext
    {
        public VendorDBContext()
        {
        }

        public VendorDBContext(DbContextOptions<VendorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coins> Coins { get; set; }
        public virtual DbSet<OrdersHistory> OrdersHistory { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=VendorDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coins>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoinDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Coinvalue).HasColumnType("money");
            });

            modelBuilder.Entity<OrdersHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersHistory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrdersHis__Produ__4E88ABD4");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
