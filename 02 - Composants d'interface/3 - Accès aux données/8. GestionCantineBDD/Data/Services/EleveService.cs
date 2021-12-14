using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Services
{
    class EleveService
    {

        private readonly GCantineContext _context;

        public EleveService(GCantineContext context)
        {
            _context = context;
        }

        public void AddEleve(Eleve obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Eleves.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEleve(Eleve obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Eleves.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Eleve> GetAllEleve()
        {
            return _context.Eleves.ToList();
        }

        public Eleve GetEleveById(int id)
        {
            return _context.Eleves.FirstOrDefault(obj => obj.IdEleve == id);
        }

        public void UpdateEleve(Eleve obj)
        {
            _context.SaveChanges();
        }

        public void Operation(int IdEleve, double montant)
        {
            Eleve EleveAModif = this.GetEleveById(IdEleve);
            EleveAModif.SoldeEleve += montant;
            _context.SaveChanges();
        }
    }
}
