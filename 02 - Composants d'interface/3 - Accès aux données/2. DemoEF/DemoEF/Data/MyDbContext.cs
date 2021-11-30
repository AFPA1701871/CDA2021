using DemoEF.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEF.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Personne> Personnes { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
