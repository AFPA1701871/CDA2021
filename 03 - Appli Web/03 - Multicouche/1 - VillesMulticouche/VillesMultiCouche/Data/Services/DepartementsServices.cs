using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillesMultiCouche.Data.Models;

namespace VillesMultiCouche.Data.Services
{
    public class DepartementsServices
    {
        private readonly MyDbContext _context;

        public DepartementsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddDepartement(Departement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Departements.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteDepartement(Departement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Departements.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Departement> GetAllDepartements()
        {
            return _context.Departements.ToList();
        }

        public Departement GetDepartementById(int id)
        {
            return _context.Departements.FirstOrDefault(obj => obj.IdDepartement == id);
        }

        public void UpdateDepartement(Departement obj)
        {
            _context.SaveChanges();
        }


    }
}
