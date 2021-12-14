using GestionCantine.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Services
{
    class PaiementServices
    {
        private readonly GCantineContext _ctx;

        public PaiementServices(GCantineContext context)
        {
            _ctx = context;
        }
        public void AddPaiement(Paiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.Paiements.Add(obj);
            _ctx.SaveChanges();
        }

        public void DeletePaiement(Paiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.Paiements.Remove(obj);
            _ctx.SaveChanges();
        }

        public List<Paiement> GetAllPaiements()
        {
            return _ctx.Paiements.Include("Eleve").Include("ModeDePaiement").ToList();
        }

        public Paiement GetPaiementById(int id)
        {
            return _ctx.Paiements.Include("Eleve").Include("ModeDePaiement").FirstOrDefault(obj => obj.IdPaiement == id);
        }

        public void UpdatePaiement(Paiement obj)
        {
            _ctx.Update(obj);
            _ctx.SaveChanges();
        }
    }
}
