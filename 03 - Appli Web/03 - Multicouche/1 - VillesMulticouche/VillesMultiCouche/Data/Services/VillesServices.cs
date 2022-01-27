using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillesMultiCouche.Data.Models;

namespace VillesMultiCouche.Data.Services
{
    public class VillesServices
    {
        private readonly MyDbContext _context;

        public VillesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddVille(Ville obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Villes.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteVille(Ville obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Villes.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Ville> GetAllVilles()
        {
            return _context.Villes.Include("LeDepartement").ToList();
        }

        public Ville GetVilleById(int id)
        {
            return _context.Villes.FirstOrDefault(obj => obj.IdVille == id);
        }

        public void UpdateVille(Ville obj)
        {
            _context.SaveChanges();
        }


    }
}
