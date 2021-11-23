
using DemoEF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEF.Data.Services
{
    public class PersonnesServices
    {
        private readonly MyDbContext _context;
       
        public PersonnesServices(MyDbContext context)
        {
            _context = context;
          
        }

        public void AddPersonnes(Personne p)
        {
            if (p==null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Add(p);
            _context.SaveChanges();

        }

        public IEnumerable<Personne> GetAllPersonnes()
        {
            return _context.Personnes.ToList();
        }
    }
}
