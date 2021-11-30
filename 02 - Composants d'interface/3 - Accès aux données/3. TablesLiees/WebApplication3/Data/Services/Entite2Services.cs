using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data.Models;

namespace TablesLiees.Data.Services
{
    public class Entite2Services
    {
        private readonly Context _context;

        public Entite2Services(Context context)
        {
            _context = context;

        }


        public IEnumerable<Entite2> GetAllEntite2()
        {
            return _context.Entite2.ToList();
        }
    }
}
