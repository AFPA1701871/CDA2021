using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionCantine.Data.Models;
using GestionCantine.Help;

#nullable disable

namespace GestionCantine.Data
{
    public partial class GCantineContext : DbContext
    {
        public string Connexion { get; set; }

        public GCantineContext()
        {
        }

        public GCantineContext(DatabaseConnection connectionObject)
        {
            this.Connexion = "server=" + connectionObject.Server + ";user=" + connectionObject.User + ";password=" + connectionObject.Password + ";database=" + connectionObject.Database + ";port=" + connectionObject.Port + ";ssl mode=" + connectionObject.SSL;
        }

        public GCantineContext(DbContextOptions<GCantineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ModeDePaiement> ModesDePaiement { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public object Reservation { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(Connexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eleve>(entity =>
            {
                entity.HasKey(e => e.IdEleve)
                    .HasName("PRIMARY");

                entity.ToTable("eleves");

                entity.Property(e => e.IdEleve).HasColumnType("int(11)");

                entity.Property(e => e.DDNEleve)
                    .HasColumnType("date")
                    .HasColumnName("DDNEleve");

                entity.Property(e => e.NomEleve).HasMaxLength(150);

                entity.Property(e => e.PrenomEleve).HasMaxLength(150);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PRIMARY");

                entity.ToTable("menus");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.Property(e => e.DateMenu).HasColumnType("date");

                entity.Property(e => e.LibelleMenu).HasMaxLength(50);
            });

            modelBuilder.Entity<ModeDePaiement>(entity =>
            {
                entity.HasKey(e => e.IdModeDePaiement)
                    .HasName("PRIMARY");

                entity.ToTable("modesdepaiement");

                entity.Property(e => e.IdModeDePaiement).HasColumnType("int(11)");

                entity.Property(e => e.LibelleModeDePaiement).HasMaxLength(50);
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.HasKey(e => e.IdPaiement)
                    .HasName("PRIMARY");

                entity.ToTable("paiements");

                entity.HasIndex(e => e.IdEleve, "FK_Paiements_Eleves");

                entity.HasIndex(e => e.IdModeDePaiement, "FK_Paiements_ModesDePaiement");

                entity.Property(e => e.IdPaiement).HasColumnType("int(11)");

                entity.Property(e => e.DatePaiement).HasColumnType("date");

                entity.Property(e => e.IdEleve).HasColumnType("int(11)");

                entity.Property(e => e.IdModeDePaiement).HasColumnType("int(11)");

                entity.HasOne(d => d.Eleve)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdEleve)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paiements_Eleves");

                entity.HasOne(d => d.ModeDePaiement)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdModeDePaiement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paiements_ModesDePaiement");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PRIMARY");

                entity.ToTable("reservations");

                entity.HasIndex(e => e.IdEleve, "FK_Reservations_Eleves");

                entity.HasIndex(e => e.IdMenu, "FK_Reservations_Menus");

                entity.Property(e => e.IdReservation).HasColumnType("int(11)");

                entity.Property(e => e.DateReservation).HasColumnType("date");

                entity.Property(e => e.IdEleve).HasColumnType("int(11)");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.HasOne(d => d.Eleve)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdEleve)
                    .HasConstraintName("FK_Reservations_Eleves");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_Reservations_Menus");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole).HasColumnType("int(11)");

                entity.Property(e => e.LibelleRole).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.IdRole, "FK_Users_Roles");

                entity.Property(e => e.IdUser).HasColumnType("int(11)");

                entity.Property(e => e.EmailUser).HasMaxLength(200);

                entity.Property(e => e.IdRole).HasColumnType("int(11)");

                entity.Property(e => e.Mdpuser)
                    .HasMaxLength(50)
                    .HasColumnName("MDPUser");

                entity.Property(e => e.NomUser).HasMaxLength(150);

                entity.Property(e => e.PrenomUser).HasMaxLength(150);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
