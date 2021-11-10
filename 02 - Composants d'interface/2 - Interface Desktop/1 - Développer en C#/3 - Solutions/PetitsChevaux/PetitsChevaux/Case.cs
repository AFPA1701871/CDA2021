using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// gère les cases standards du plateau
    /// </summary>
    class Case
    {
        // Attributs
        public Joueur JoueurOccupant { get; set; } // contient le joueur occupant la case ou null
        public string Statut { get; set; } // contient le statut départ, arrivée, ....



        // Constructeur
        /// <summary>
        /// initialise la case à null et statut vide
        /// </summary>
        public Case()
        {
            JoueurOccupant = null;
            Statut = "";
        }

        /// <summary>
        /// initialise la case à null etmet à jour le statut
        /// </summary>
        /// <param name="stat">donne un statut à la case</param>
        public Case(string stat) {
            this.JoueurOccupant = null;
            this.Statut = stat;
        }


        //Pas de getter et setter, les attrriburts change en fonction du construct et changeEtat

        /// <summary>
        /// Renvoi le contenu de la case sous forme de string
        /// </summary>
        /// <returns>string permettant un affichage des infos utiles de la case (objectif affichage du plateau)</returns>
        public override string ToString() { return ""; }
    }
}
