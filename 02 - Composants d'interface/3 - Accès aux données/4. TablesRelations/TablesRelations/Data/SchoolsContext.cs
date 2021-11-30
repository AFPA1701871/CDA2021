using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TablesRelations.Data
{
    public class SchoolsContext : DbContext
    {
        public SchoolsContext(DbContextOptions<SchoolsContext> options):base(options)
        {

        }

    }
}
