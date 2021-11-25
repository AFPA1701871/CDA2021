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
    }
}
