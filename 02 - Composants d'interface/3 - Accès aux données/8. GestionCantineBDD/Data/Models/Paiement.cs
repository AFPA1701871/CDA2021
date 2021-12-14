using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Models
{
    public partial class Paiement
    {
        public int IdPaiement { get; set; }
        public double? MontantPaiement { get; set; }
        public DateTime? DatePaiement { get; set; }
        public int IdEleve { get; set; }
        public int IdModeDePaiement { get; set; }

        public virtual Eleve Eleve { get; set; }
        public virtual ModeDePaiement ModeDePaiement { get; set; }
    }
}
