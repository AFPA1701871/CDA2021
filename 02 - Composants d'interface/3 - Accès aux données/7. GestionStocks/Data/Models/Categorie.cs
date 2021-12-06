using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStocks.Data.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Articles = new HashSet<Article>();
        }

        public int IdCategorie { get; set; }
        public string LibelleCategorie { get; set; }
        public int IdTypeProduit { get; set; }

        public virtual TypeProduit IdTypeProduitNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
