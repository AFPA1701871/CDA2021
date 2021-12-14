using GestionCantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCantine.Data.Dtos
{
    public class EleveDTOIn
    {
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public DateTime DDNEleve { get; set; }
    }
    public class EleveDTOOut
    {
        public int IdEleve { get; set; }
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public string DDNEleve { get; set; }
        public double SoldeEleve { get; set; }
    }

    public class EleveReservationDTOOut
    {
        public int IdEleve { get; set; }
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public string DDNEleve { get; set; }
        public double SoldeEleve { get; set; }
        public virtual List<ReservationDTOOut> Reservations { get; set; }
    }
}
