using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// Class qui gère un joueur, ses pions, les positions de ceux-ci 
    /// </summary>
    class Joueur
    {
        // Attributs
        public static int NbJoueur { get; set; } = 0; // permet de savoir combien de joueurs ont été créés pour initialiser le plateau et faire les rotations de tour
        public static int NbChevaux { get; set; } // nombre de chevaux par Joueur, idem pour tous les joueurs, donc static
        public string Nom { get; set; } // nom du joueur défini au départ du jeu
        public string Couleur { get; set; } // couleur correspondant au joueur (utile à l'affichage)
        public int NumJoueur { get; set; } // numero du joueur
        public int CaseDepart { get; set; } // repère la position de la case de départ pour ce joueur
        public int CaseArrivee { get; set; } // repère la position de la case d'arrivee pour ce joueur
        public int NbChevauxEcurie { get; set; } // contient le nombre de chevaux encore à l'ecurie = NbChevaux au départ du jeu
        public List<int> ListePosition { get; set; } // liste des positions des chevaux à chaque instant -1 pour écurie, numéro de case si plateau principal, numero de caseNumerotée *1000 ou -2 si tour terminé
                                                      // ce sont les positions des chevaux dans l'ordre, le 0ieme, le 1er, ...

        public Joueur() { } // ne sert que pour le joueur en cours
        public Joueur(string nom, string coul)
        {
            NbJoueur++;
            this.Nom = nom;
            this.Couleur = coul;
            NumJoueur = NbJoueur;
            NbChevauxEcurie = NbChevaux;
            ListePosition = new List<int>();
            for (int i = 0; i < NbChevaux; i++)
            {
                ListePosition.Add(-1);
            }
        }

        /// <summary>
        /// renvoi un nombre aléatoire correspondant à un lancé de dé
        /// </summary>
        /// <returns></returns>
        public int LanceLeDe()
        {
            return De.LancerLeDe();
        }

        /// <summary>
        /// gère l'avancée des pions
        /// cette méthode liste toutes les possibilités d'avancement de pion
        /// </summary>
        /// <param name="p">plateau qui informe de la position des pions de tous les joueurs</param>
        /// <param name="ValeurDe">valeur du dé qui détermine le nombre de case à avancer ou définit si on peut atteindre une case numérotée</param>
        /// <returns></returns>
        public List<Possibilite> Avance(Plateau p, int valeurDe)
        {
            List<Possibilite> liste = new List<Possibilite>();
            List<Possibilite> listeCase = AvanceCase(p, valeurDe);
            List<Possibilite> listeCaseNumerotee = AvanceCaseNumerotee(p, valeurDe);
            foreach (Possibilite po in listeCase)
            {
                if (po != null)
                    liste.Add(po);
            }
            foreach (Possibilite po in listeCaseNumerotee)
            {
                if (po != null)
                    liste.Add(po);
            }
            return liste;
        }


        /// <summary>
        /// cherche les possibilités d'avancer sur le plateau principal
        /// </summary>
        /// <param name="p">plateau qui informe de la position des pions de tous les joueurs</param>
        /// <param name="ValeurDe">valeur du dé qui détermine le nombre de case à avancer ou définit si on peut atteindre une case numérotée</param>
        /// <returns></returns>
        private List<Possibilite> AvanceCase(Plateau p, int valeurDe)
        {
            List<Possibilite> liste = new List<Possibilite>();
            Possibilite p1;
            int pion = 0; // numero du pion traité
            foreach (int posi in ListePosition)
            {
                if (posi >= 0 && posi < 1000)
                {
                    p1 = AvanceCase(p, valeurDe, pion);
                    liste.Add(p1);
                }
                pion++;
            }
            return liste;
        }

        /// <summary>
        ///  possibilité pour un pion
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ValeurDe"></param>
        /// <param name="pion">numero du cheval testé</param>
        /// <returns></returns>
        private Possibilite AvanceCase(Plateau p, int ValeurDe, int pion)
        {
            int positionPionDansPlateau = ListePosition.ElementAt(pion);
            // on teste si le pion va dépasser sa case d'arrivée

            if (positionPionDansPlateau <= this.CaseArrivee && (positionPionDansPlateau + ValeurDe) % p.PlateauJeu.Count > this.CaseArrivee) //tester si avant ou apres fin de tableau
            {
                return null;
            }
            if (CaseArrivee == 0 && positionPionDansPlateau + ValeurDe > p.PlateauJeu.Count)
            {// test spécial pour l'arrivée en case 0
                return null;
            }
            // on teste si le pion va arriver sur une case occupée par un autre pion du même joueur
            if (p.PlateauJeu[(positionPionDansPlateau + ValeurDe) % p.PlateauJeu.Count].JoueurOccupant == this) //tester si avant ou apres fin de tableau
            {
                return null;
            }
            // on verifie que les cases suivantes soient libres
            for (int i = 1; i < ValeurDe; i++)  // on ne va pas jusqu'à ValeurDe, parce qu'elle soit occupée ou pas, c'est une possibilité
            {
                if (p.PlateauJeu[(positionPionDansPlateau + i) % p.PlateauJeu.Count].JoueurOccupant != null)
                {// % p.PlateauJeu.Count permet de revenir au départ 
                    return null; // si une case est occupée, pas de possibilité
                }
            }
            return new Possibilite(this, pion, p.PlateauJeu[(positionPionDansPlateau + ValeurDe) % p.PlateauJeu.Count], (positionPionDansPlateau + ValeurDe) % p.PlateauJeu.Count);
            // si toutes les cases sont libres, on retourne la possibilité

        }

        /// <summary>
        /// cherche les possibilités d'avancer sur les cases numérotées
        /// </summary>
        /// <param name="p">plateau qui informe de la position des pions de tous les joueurs</param>
        /// <param name="ValeurDe">valeur du dé qui détermine le nombre de case à avancer ou définit si on peut atteindre une case numérotée</param>
        // <returns></returns>
        private List<Possibilite> AvanceCaseNumerotee(Plateau p, int ValeurDe)
        {
            return new List<Possibilite>();
        }


        /// <summary>
        /// renvoi le numéro du cheval si l'un peut sortir de l'écurie
        /// </summary>
        /// <returns></returns>
        public Possibilite SortirEcurie()
        {
            int position = -1; // indice (le numero de cheval) si un cheval est encore disponible
            if (NbChevauxEcurie > 0)
            {
                foreach (int l in ListePosition)
                {
                    position++;
                    if (l == -1)
                    {
                        return new Possibilite(this, position, new Case(), CaseDepart);
                        // renvoi une possibilité avec le cheval dispo, la case est initialise à new car non disponible et pas utilisé dans ce cas
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// méthode qui renvoi un pion à l'écurie (mise à jour de la liste des positions)
        /// </summary>
        /// <param name="posPlateau">position du cheval sur le plateau</param>
        public void RetourEcurie(int posPlateau)
        {
            int pion = -1, index = 0;
            NbChevauxEcurie++;
            foreach (int p in ListePosition)
            {
                if (p == posPlateau) pion = index;
                index++;
            }
            ListePosition[pion] = -1;

        }
        /// <summary>
        /// permet de deplacer un pion, gère la liste des positions des pions et mets à jour le tableau
        /// </summary>
        /// <param name="p">plateaiu de jeu</param>
        /// <param name="po">possibilite retenue</param>
        public void DeplacerPion(Plateau p, Possibilite po)
        {
            int pion = po.Cheval;
            int positionActuelPion = ListePosition.ElementAt(pion);
            if (positionActuelPion == -1)
                demarrerUnPion(p);
            else
            {
                p.PlateauJeu[positionActuelPion].JoueurOccupant = null; // on enlève le pion de l'ancienne place
                // si quelqu'un a la nouvelle place, on enlève le pion
                if (p.PlateauJeu[po.IndicePlateau].JoueurOccupant != null) p.PlateauJeu[po.IndicePlateau].JoueurOccupant.RetourEcurie(po.IndicePlateau);
                // si on est sur la case arrivée , on sort le pion en attendant de gérer les cases numérotées
                if (po.IndicePlateau == CaseArrivee)
                {
                    ListePosition[pion] = -2;
                    Console.WriteLine("Le pion " + pion + " a terminé");
                }
                else
                {
                    ListePosition[pion] = po.IndicePlateau; // on met à jour la liste des positions
                    p.PlateauJeu[po.IndicePlateau].JoueurOccupant = this; // on place le pion à la nouvelle place
                }
            }
        }

        /// <summary>
        /// Choisit un pion et le met sur la case depart
        /// </summary>
        /// <param name="p"></param>
        private void demarrerUnPion(Plateau p)
        {
            int index = 0;
            int elementAModifier = -1;
            // définir le pion à demarrer
            foreach (int pion in ListePosition)
            {
                if (pion == -1)
                {
                    NbChevauxEcurie--;
                    elementAModifier = index;

                    break;
                }
                index++;
            }
            ListePosition[elementAModifier] = CaseDepart;
            p.PlateauJeu[CaseDepart].JoueurOccupant = this;
        }


        /// <summary>
        /// défini si un joueur a gagné, si aucun pions dans l'écurie, si tous les chevaux ont fit le tour
        /// </summary>
        /// <returns>vrai si le joueur a gagné, faux sinon</returns>
        public bool Gagne()
        {
            if (NbChevauxEcurie == 0)
            {
                foreach (int index in ListePosition)
                {
                    if (index != -2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
