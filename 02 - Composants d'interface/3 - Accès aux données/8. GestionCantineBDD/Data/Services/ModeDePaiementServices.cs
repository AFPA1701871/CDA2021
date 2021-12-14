using GestionCantine.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Services
{
    class ModeDePaiementServices
    {
        private readonly GCantineContext _ctx;

        public ModeDePaiementServices(GCantineContext context)
        {
            _ctx = context;
        }
        public void AddModeDePaiement(ModeDePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.ModesDePaiement.Add(obj);
            _ctx.SaveChanges();
        }

        public void DeleteModeDePaiement(ModeDePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.ModesDePaiement.Remove(obj);
            _ctx.SaveChanges();
        }

        public List<ModeDePaiement> GetAllModeDePaiements()
        {
            return _ctx.ModesDePaiement.ToList();
        }

        public ModeDePaiement GetModeDePaiementById(int id)
        {
            return _ctx.ModesDePaiement.FirstOrDefault(obj => obj.IdModeDePaiement == id);
        }

        public void UpdateModeDePaiement(ModeDePaiement obj)
        {
            _ctx.Update(obj);
            _ctx.SaveChanges();
        }
    }
}
