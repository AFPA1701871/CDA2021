using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DemoEF.Data.Models
{
    public partial class Personne
    {
        [Key]
        public int IdPersonne { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Ddn { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public float Numero { get; set; }
    }
}
