using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int IdMenu { get; set; }
        public DateTime? DateMenu { get; set; }
        public string LibelleMenu { get; set; }
        public double? PrixMenu { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
