using GestionStocks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStocks.Data.Services
{
    class TypesProduitsServices
    {

        private readonly MyDbContext _context;

        public TypesProduitsServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddTypesProduit(TypeProduit obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesProduits.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteTypesProduit(TypeProduit obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesProduits.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TypeProduit> GetAllTypesProduits()
        {
            return _context.TypesProduits.ToList();
        }

        public TypeProduit GetTypesProduitById(int id)
        {
            return _context.TypesProduits.FirstOrDefault(obj => obj.IdTypeProduit == id);
        }

        public void UpdateTypesProduit(TypeProduit obj)
        {
            _context.SaveChanges();
        }


    }
}
