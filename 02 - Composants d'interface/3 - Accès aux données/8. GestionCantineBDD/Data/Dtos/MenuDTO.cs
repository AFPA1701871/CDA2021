using GestionCantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Dtos
{
    public class MenuDTOIn
    {
        public DateTime? DateMenu { get; set; }
        public string LibelleMenu { get; set; }
        public double? PrixMenu { get; set; }
    }

    public class MenuDTOOut
    {
        public int IdMenu { get; set; }
        public string DateMenu { get; set; }
        public string LibelleMenu { get; set; }
        public double? PrixMenu { get; set; }
        //public virtual ICollection<ReservationDTOOut> Reservations { get; set; }
    }
}
