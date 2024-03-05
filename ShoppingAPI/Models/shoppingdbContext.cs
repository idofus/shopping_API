using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoppingAPI.Models
{
    public partial class shoppingdbContext : DbContext
    {
        public shoppingdbContext()
        {
        }

        public shoppingdbContext(DbContextOptions<shoppingdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admindetail> Admindetails { get; set; } = null!;
        public virtual DbSet<Productdetail> Productdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shoppingdb;user id=root;password=mysql@123;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Admindetail>(entity =>
            {
                entity.ToTable("admindetail");

                entity.Property(e => e.EmailId).HasMaxLength(100);

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.UserName).HasMaxLength(45);
            });

            modelBuilder.Entity<Productdetail>(entity =>
            {
                entity.ToTable("productdetail");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Mrpprice)
                    .HasPrecision(14, 2)
                    .HasColumnName("MRPPrice");

                entity.Property(e => e.ProductImage).HasMaxLength(250);

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.SellingPrice).HasPrecision(14, 2);

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
