using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data;
using TablesLiees.Data.Models;

namespace TablesLiees.Data
{
    public class Context:DbContext
    {
        public DbSet<Entite1> Entite1 { get; set; }
        public DbSet<Entite2> Entite2 { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entite2>(e2 =>
            {
                e2.ToTable("Entite2");
                e2.Property(e => e.IdEntite2).HasColumnName("IdEntite2");
            });
            modelBuilder.Entity<Entite1>(e1 =>
            {
                e1.ToTable("Entite1");
                e1.Property(e => e.IdEntite2).HasColumnName("IdEntite2");
                e1.HasOne(e => e.Ent2).WithOne().HasForeignKey<Entite2>(e => e.IdEntite2);
            });
        }
    }
}
