using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Models
{
    public partial class Eleve
    {
        public Eleve()
        {
            Paiements = new HashSet<Paiement>();
            Reservations = new HashSet<Reservation>();
        }

        public Eleve(string nomEleve, string prenomEleve, DateTime ddnEleve)
        {
            NomEleve = nomEleve;
            PrenomEleve = prenomEleve;
            DDNEleve = ddnEleve;

        }
        public int IdEleve { get; set; }
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public DateTime DDNEleve { get; set; }
        public double? SoldeEleve { get; set; }

        public virtual ICollection<Paiement> Paiements { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
