using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{/// <summary>
/// Permet de gérer les cases numérotées du plateau
/// La différence par rapport à Case et la valeur du dé necessaire pour occuper la case
/// </summary>
    class CaseNumerotee : Case
    {
        // Attributs
        private int valeur;

        public int Valeur
        {
            get
            {
                return valeur;
            }

            set
            {
                valeur = value;
            }
        }

        public CaseNumerotee(int val) : base()
        {
            this.valeur = val;
        }
        
        /// <summary>
        /// Renvoi le contenu de la case sous forme de string
        /// </summary>
        /// <returns>string permettant un affichage des infos utiles de la case (objectif affichage du plateau)</returns>
        public override string ToString() { return ""; }
    }
}
