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
                entity.HasOne(d => d.IdEstadoCamaraNavigation)
                    .WithMany(p => p.Camaras)
                    .HasForeignKey(d => d.IdEstadoCamara)
                    .HasConstraintName("FK_Camara_EstadoCamara");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
