using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Arqueria.Models
{
    public partial class ArqueriaDbContext : DbContext
    {
        public ArqueriaDbContext()
        {
        }

        public ArqueriaDbContext(DbContextOptions<ArqueriaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arquero> Arquero { get; set; }
        public virtual DbSet<Campeonato> Campeonato { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Diana> Diana { get; set; }
        public virtual DbSet<Participacion> Participacion { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ENDY;Database=Arqueria;user=;trusted_connection=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arquero>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClubNavigation)
                    .WithMany(p => p.Arquero)
                    .HasForeignKey(d => d.Club)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Arquero__Club__34C8D9D1");
            });

            modelBuilder.Entity<Campeonato>(entity =>
            {
                entity.Property(e => e.Anio)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrimerPuestoNavigation)
                    .WithMany(p => p.CampeonatoPrimerPuestoNavigation)
                    .HasForeignKey(d => d.PrimerPuesto)
                    .HasConstraintName("FK__Campeonat__Prime__37A5467C");

                entity.HasOne(d => d.SegundoPuestoNavigation)
                    .WithMany(p => p.CampeonatoSegundoPuestoNavigation)
                    .HasForeignKey(d => d.SegundoPuesto)
                    .HasConstraintName("FK__Campeonat__Segun__38996AB5");

                entity.HasOne(d => d.TercerPuestoNavigation)
                    .WithMany(p => p.CampeonatoTercerPuestoNavigation)
                    .HasForeignKey(d => d.TercerPuesto)
                    .HasConstraintName("FK__Campeonat__Terce__398D8EEE");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diana>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Participacion>(entity =>
            {
                entity.HasOne(d => d.ArqueroNavigation)
                    .WithMany(p => p.Participacion)
                    .HasForeignKey(d => d.Arquero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__Arque__3F466844");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Participacion)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__Categ__412EB0B6");

                entity.HasOne(d => d.DianaNavigation)
                    .WithMany(p => p.Participacion)
                    .HasForeignKey(d => d.Diana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__Diana__4222D4EF");

                entity.HasOne(d => d.TorneoNavigation)
                    .WithMany(p => p.Participacion)
                    .HasForeignKey(d => d.Torneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__Torne__403A8C7D");
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CampeonatoNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.Campeonato)
                    .HasConstraintName("FK__Torneo__Campeona__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
