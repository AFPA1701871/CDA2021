using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesLiees.Data.Models;

namespace TablesLiees.Data.Services
{
    public class Entite1Services
    {
        private readonly Context _context;

        public Entite1Services(Context context)
        {
            _context = context;

        }

        // L'entité1 est indépendante
        //public IEnumerable<Entite1> GetAllEntite1()
        //{
        //    return _context.Entite1.ToList();
        //}


        // L'entité 1 contient une Entite2
        // On crée une jointure pour récupérer les données

        public IEnumerable<Entite1> GetAllEntite1()
        {
            var liste = (from e1 in _context.Entite1
                         join e2 in _context.Entite2
                         on   e1.IdEntite2 equals e2.IdEntite2 
                         select new Entite1
                         {
                             IdEntite1 = e1.IdEntite1,
                             NomEntite1 = e1.NomEntite1,
                             IdEntite2 = e2.IdEntite2,
                             Ent2 = e2
                         }).ToList();
            return liste;
        }
    }
}
