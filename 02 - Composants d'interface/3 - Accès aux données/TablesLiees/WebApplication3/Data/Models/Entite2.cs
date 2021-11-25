using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TablesLiees.Data.Models
{
    public class Entite2
    {
        [Key]
        public int IdEntite2 { get; set; }
        public string  NomEntite2 { get; set; }
    }
}
