using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// gère le plateau de jeu
    /// Celui-ci est découpé en une liste de Case (nb joueur *14) et une liste de tableau de 6 CaseNumerotee
    /// </summary>
    class Plateau
    {
        // Attributs
        List<Case> plateauJeu; // plateau principal
        List<CaseNumerotee[]> maison = new List<CaseNumerotee[]>();

        internal List<Case> PlateauJeu
        {
            get
            {
                return plateauJeu;
            }

            set
            {
                plateauJeu = value;
            }
        }
        internal List<CaseNumerotee[]> Maison
        {
            get
            {
                return maison;
            }

            set
            {
                maison = value;
            }
        }

        // Constructeur
        /// <summary>
        /// Construit le plateau en fonction du nombre de joueur
        /// Initialise les statuts des cases en affectant les départs et les arrivées
        /// modifie les joueurs pour leur affecter les cases départ et arrivée
        /// Construit les tableaux de case numérotées
        /// </summary>
        /// <param name="joueurs"></param>
        public Plateau(List<Joueur> joueurs)
        {
            int indicePlateau = 0;
            plateauJeu = new List<Case>();
            CaseNumerotee[] caseNum = new CaseNumerotee[6];

            foreach (Joueur j in joueurs)
            {// création plateau principal
                plateauJeu.Add(new Case("A" + j.Nom));
                j.CaseArrivee = indicePlateau;
                indicePlateau++;
                plateauJeu.Add(new Case("D" + j.Nom));
                j.CaseDepart = indicePlateau;
                indicePlateau++;
                for (int i = 2; i < 14; i++)
                {
                    plateauJeu.Add(new Case(indicePlateau+""));
                    indicePlateau++;
                }
                //création de la maison
                for (int k = 0; k < 6; k++)
                {
                    caseNum[k] = new CaseNumerotee( k+1);
                    caseNum[k].Statut = "m" + k;
                }
                maison.Add(caseNum);
            }
            
        }

        /// <summary>
        /// renvoi un string qui permet l'affichagfe du plateau
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// déplace un pion sur le plateau
        /// le cas échéant, renvoi un cheval à l'écurie
        /// </summary>
        /// <param name="poss"></param>
        public void ChangePosition(Possibilite poss)
        {
            poss.J.DeplacerPion(this, poss); // on demande au joueur de deplacer le pion

        }
    }
}
