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

        public virtual DbSet<TblStudent> TblStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=imakash.database.windows.net;Initial Catalog=CMS;User ID=imakash;Password=Akash25@122540;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.IntStudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.IntStudentId).HasColumnName("intStudentId");

                entity.Property(e => e.DteInsertDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dteInsertDateTime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("strAddress");

                entity.Property(e => e.StrBloodGroup)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("strBloodGroup");

                entity.Property(e => e.StrPhoneNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("strPhoneNo");

                entity.Property(e => e.StrStudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("strStudentName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
