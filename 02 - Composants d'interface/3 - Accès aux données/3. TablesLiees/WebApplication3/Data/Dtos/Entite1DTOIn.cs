using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TablesLiees.Data.Dtos

{
    public class Entite1DTOIn
    {
        public string NomEntite1 { get; set; }
        // On masque également les informations dans Entité2
        public int IdEntite2 { get; set; }
    }
}
