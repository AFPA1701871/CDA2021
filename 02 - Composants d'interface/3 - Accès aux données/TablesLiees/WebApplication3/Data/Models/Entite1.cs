using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TablesLiees.Data.Models

{
    public class Entite1
    {
        [Key]
        public int IdEntite1 { get; set; }
        public string NomEntite1 { get; set; }
        public int IdEntite2 { get; set; }
    }

    //La classe contient une autre classe
    //public class Entite1
    //{
    //    [Key]
    //    public int IdEntite1 { get; set; }
    //    public string NomEntite1 { get; set; }
    //    //on garde l'id de la table pour établir la jointure
    //    public int IdEntite2 { get; set; }
    //    public Entite2 Ent2 { get; set; }
    //}

}

