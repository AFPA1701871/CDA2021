using GestionStocks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStocks.Data.Services
{
    class CategoriesServices
    {

        private readonly MyDbContext _context;

        public CategoriesServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddCategorie(Categorie obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Categories.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteCategorie(Categorie obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Categorie> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return _context.Categories.FirstOrDefault(obj => obj.IdCategorie == id);
        }

        //public Categorie GetCategorieByLibelle(string name)
        //{
        //    return _context.Categories.FirstOrDefault(obj => obj.LibelleCategorie == name);
        //}

        public void UpdateCategorie(Categorie obj)
        {
            _context.SaveChanges();
        }


    }
}
