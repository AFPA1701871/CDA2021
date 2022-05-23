
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

        public void DeletePersonne(Personne p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Personnes.Remove(p);
            _context.SaveChanges();
        }

        

        public Personne GetPersonneById(int id)
        {
            return _context.Personnes.FirstOrDefault(p => p.IdPersonne == id);
        }

        public void UpdatePersonne(Personne p)
        {
            // le context est modifié automatiquement, on persiste les changements
            _context.SaveChanges();

        }
    }
}

