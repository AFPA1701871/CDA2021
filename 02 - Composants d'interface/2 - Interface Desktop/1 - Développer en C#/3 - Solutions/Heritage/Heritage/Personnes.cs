using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Personnes
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Personnes(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        

        public virtual bool VerifNom()
        {
            if (this.Nom.Length >= 2)
                return true;
            return false;
        }
        public override string ToString()
        {
            return "nom : "+ this.Nom+ " prenom : " + this.Prenom;
        }
    }
}
