using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// Permet de regrouper un joueur, un cheval et une case
    /// </summary>
    class Possibilite
    {
        //Propriétés
        

        public Joueur J { get; set; }

        public int Cheval { get; set; }

        public Case Cas { get; set; }

        public int IndicePlateau { get; set; }
        

        //Constructeur
        public Possibilite(Joueur j, int cheval, Case cas, int indice)
        {
            this.J = j;
            this.Cheval = cheval;
            this.Cas = cas;
            this.IndicePlateau = indice;
        }

        

    }
}
