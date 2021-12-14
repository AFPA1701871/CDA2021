using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCantine.Data.Dtos
{
    public partial class ModeDePaiementDTOIn
    {
        public string LibelleModeDePaiement { get; set; }
    }
    public partial class ModeDePaiementDTOOut
    {
        public int IdModeDePaiement { get; set; }
        public string LibelleModeDePaiement { get; set; }
    }
}
