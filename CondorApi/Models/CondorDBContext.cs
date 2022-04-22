using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CondorApi.Models
{
    public partial class CondorDBContext : DbContext
    {
        public CondorDBContext()
        {
        }

        public CondorDBContext(DbContextOptions<CondorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employe> Employes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RAGNAR; Database=CondorDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("employes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.DateBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_birth");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TypeDocument)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_document");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
