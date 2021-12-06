using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStocks.Data.Models
{
    public partial class TypeProduit
    {
        public TypeProduit()
        {
            Categories = new HashSet<Categorie>();
        }

        public int IdTypeProduit { get; set; }
        public string LibelleTypeProduit { get; set; }

        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
