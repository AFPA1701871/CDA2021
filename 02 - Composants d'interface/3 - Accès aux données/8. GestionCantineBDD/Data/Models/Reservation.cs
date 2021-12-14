using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Models
{
    public partial class Reservation
    {
        public int IdReservation { get; set; }
        public int? IdEleve { get; set; }
        public int? IdMenu { get; set; }
        public DateTime? DateReservation { get; set; }

        public virtual Eleve Eleve { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
