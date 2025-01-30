using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class BdInfraccionesContext : DbContext
    {
        public BdInfraccionesContext()
        {
        }

        public BdInfraccionesContext(DbContextOptions<BdInfraccionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camara> Camaras { get; set; } = null!;
        public virtual DbSet<EstadoCamara> EstadoCamaras { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camara>(entity =>
            {
                entity.ToTable("Camara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.NumeroCamara).HasColumnName("numeroCamara");

                entity.HasOne(d => d.IdEstadoCamaraNavigation)
                    .WithMany(p => p.Camaras)
                    .HasForeignKey(d => d.IdEstadoCamara)
                    .HasConstraintName("FK_Camara_EstadoCamara");
            });

            modelBuilder.Entity<EstadoCamara>(entity =>
            {
                entity.ToTable("EstadoCamara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
