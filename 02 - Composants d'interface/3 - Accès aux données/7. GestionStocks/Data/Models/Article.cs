using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStocks.Data.Models
{
    public partial class Article
    {
        public int IdArticle { get; set; }
        public string LibelleArticle { get; set; }
        public int QuantiteStockee { get; set; }
        public int IdCategorie { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}
