using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillesMultiCouche.Data.Models;

namespace VillesMultiCouche.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDepartement)
                    .HasName("PRIMARY");

                entity.ToTable("departements");

                entity.Property(e => e.IdDepartement).HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.HasKey(e => e.IdVille)
                    .HasName("PRIMARY");

                entity.ToTable("villes");

                entity.HasIndex(e => e.IdDepartement, "fk");

                entity.Property(e => e.IdVille).HasColumnType("int(11)");

                entity.Property(e => e.IdDepartement).HasColumnType("int(11)");

                entity.Property(e => e.NomVille)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LeDepartement)
                    .WithMany(p => p.Villes)
                    .HasForeignKey(d => d.IdDepartement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
