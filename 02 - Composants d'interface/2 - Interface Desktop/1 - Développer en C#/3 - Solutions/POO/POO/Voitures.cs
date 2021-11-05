using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    class Voitures
    {
        public string Nom { get; set; }
        public Personnes Proprietaire { get; set; }

        public Voitures(string nom, Personnes proprietaire)
        {
            Nom = nom;
            Proprietaire = proprietaire;
        }

        public override string ToString()
        {
            return "la voiture s'appelle " + this.Nom + ". Son propriétaire est " + this.Proprietaire.ToString();
        }

    }
}
