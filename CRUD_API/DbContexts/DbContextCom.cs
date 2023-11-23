using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRUD_API.Models;

#nullable disable

namespace CRUD_API.DbContexts
{
    public partial class DbContextCom : DbContext
    {
        public DbContextCom()
        {
        }

        public DbContextCom(DbContextOptions<DbContextCom> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.209.99.144;Initial Catalog=SME;User ID=smeapp;Password=sds#dt454sesa0wdnp@1vpo#98;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ActionTime).HasColumnType("datetime");

                entity.Property(e => e.AltUomId).HasDefaultValueSql("((0))");

                entity.Property(e => e.AltUomName).HasMaxLength(100);

                entity.Property(e => e.AvgRate)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BarCodeSerial).HasDefaultValueSql("((1))");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Brand).HasMaxLength(500);

                entity.Property(e => e.ConversionUnit)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentSellingPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.Hscode)
                    .HasMaxLength(100)
                    .HasColumnName("HSCode");

                entity.Property(e => e.ImageString).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProducible).HasComment("if this field is true that means this item will use in Production or this item is a producible item.");

                entity.Property(e => e.ItemCategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ItemSubCategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastActionTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ManufacturerName).HasMaxLength(150);

                entity.Property(e => e.MaximumDiscountAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaximumDiscountPercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("Item wise Maximum Discount % set in this field and this field will check in sales Order or Delivery Module");

                entity.Property(e => e.MinSalesQty).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinorCategoryName).HasMaxLength(100);

                entity.Property(e => e.OriginId).HasDefaultValueSql("((0))");

                entity.Property(e => e.OriginName).HasMaxLength(200);

                entity.Property(e => e.PartNumber).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Sd)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("SD");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StdPurchasePrice)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StockLimitQuantity).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalQuantity).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalValue)
                    .HasColumnType("numeric(37, 4)")
                    .HasComputedColumnSql("(round([TotalQuantity]*[AvgRate],(2)))", false);

                entity.Property(e => e.UomName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Vat).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VatPercentage)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
