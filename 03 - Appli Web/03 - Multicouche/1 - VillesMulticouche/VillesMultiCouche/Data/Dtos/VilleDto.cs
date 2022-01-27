using System;
using System.Collections.Generic;
using VillesMultiCouche.Data.Models;

#nullable disable

namespace VillesMultiCouche.Data.Dtos
{
    public  class VilleDTO
    {
        public int IdVille { get; set; }
        public string NomVille { get; set; }
        public int IdDepartement { get; set; }

        public virtual DepartementDTO LeDepartement { get; set; }
    }
}
