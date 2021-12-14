using GestionCantine.Data.Models;
using GestionCantine.Help;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Services
{
    class ReservationServices
    {

        private readonly GCantineContext _ctx;

        public ReservationServices(GCantineContext context)
        {
            _ctx = context;
        }

        public void AddReservation(Reservation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.Reservations.Add(obj);
            _ctx.SaveChanges();
        }

        public void DeleteReservation(Reservation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _ctx.Reservations.Remove(obj);
            _ctx.SaveChanges();
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return _ctx.Reservations.Include("Menu").Include("Eleve").ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _ctx.Reservations.FirstOrDefault(obj => obj.IdReservation == id);
        }

        public void UpdateReservation(Reservation obj)
        {
            _ctx.SaveChanges();
        }


    }
}
