using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back_end.Data
{
    public partial class BD_GBIFContext : DbContext
    {
        public BD_GBIFContext()
        {
        }

        public BD_GBIFContext(DbContextOptions<BD_GBIFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especie> Especie { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CanonicalName)
                    .HasColumnName("canonicalName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.KeyEspecie).HasColumnName("keyEspecie");

                entity.Property(e => e.Kingdom)
                    .HasColumnName("kingdom")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameType)
                    .HasColumnName("nameType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumDescendants).HasColumnName("numDescendants");

                entity.Property(e => e.Origin)
                    .HasColumnName("origin")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ScientificName)
                    .HasColumnName("scientificName")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
