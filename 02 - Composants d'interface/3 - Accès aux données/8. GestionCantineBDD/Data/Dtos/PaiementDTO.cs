using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Dtos
{
    public partial class PaiementDTOIn
    {
        public double? MontantPaiement { get; set; }
        public DateTime? DatePaiement { get; set; }
        public int IdEleve { get; set; }
        public int IdModeDePaiement { get; set; }
    }

    public partial class PaiementDTOOut
    {
        public int IdPaiement { get; set; }
        public double? MontantPaiement { get; set; }
        public string DatePaiement { get; set; }
        public int IdEleve { get; set; }
        public string NomEleve { get; set; }
        public string PrenomEleve { get; set; }
        public string DDNEleve { get; set; }
        public int IdModeDePaiement { get; set; }
        public string LibelleModeDePaement { get; set; }
    }
}
