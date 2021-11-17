using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Stagiaires : Personnes
    {
        public int Numero { get; set; }
        public string Hebergement { get; set; }

        public Stagiaires(string nom, string prenom,int numero, string hebergement) : base( nom,  prenom)
        {
            
            Numero = numero;
            Hebergement = hebergement;
        }

        public override string ToString()
        {
             return base.ToString() +  " numero : " + this.Numero + " heb " + this.Hebergement;
        }

        public override bool VerifNom()
        {
            if (this.Nom.Length >= 5)
                return true;
            return false;
        }
    }
}
