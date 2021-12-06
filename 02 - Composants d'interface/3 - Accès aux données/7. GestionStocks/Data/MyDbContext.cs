using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionStocks.Data.Models;

#nullable disable

namespace GestionStocks.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<TypeProduit> TypesProduits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=gestionStocks;port=3306;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle)
                    .HasName("PRIMARY");

                entity.ToTable("articles");

                entity.HasIndex(e => e.IdCategorie, "IdCategorie");

                entity.Property(e => e.IdArticle).HasColumnType("int(11)");

                entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                entity.Property(e => e.LibelleArticle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.QuantiteStockee).HasColumnType("int(11)");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("articles_ibfk_1");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PRIMARY");

                entity.ToTable("categories");

                entity.HasIndex(e => e.IdTypeProduit, "IdTypeProduit");

                entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");

                entity.Property(e => e.LibelleCategorie)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdTypeProduitNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdTypeProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("categories_ibfk_1");
            });

            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(e => e.IdTypeProduit)
                    .HasName("PRIMARY");

                entity.ToTable("typesproduits");

                entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypeProduit).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
