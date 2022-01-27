using System;
using System.Collections.Generic;

#nullable disable

namespace VillesMultiCouche.Data.Models
{
    public partial class Ville
    {
        public int IdVille { get; set; }
        public string NomVille { get; set; }
        public int IdDepartement { get; set; }

        public virtual Departement LeDepartement { get; set; }
    }
}
