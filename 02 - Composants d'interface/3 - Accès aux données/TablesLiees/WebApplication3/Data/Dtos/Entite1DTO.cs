using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TablesLiees.Data.Dtos

{
    public class Entite1DTO
    {
        public string NomEntite1 { get; set; }
        // On masque également les informations dans Entité2
        public Entite2DTO Ent2 { get; set; }
    }
}
