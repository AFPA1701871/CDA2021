using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// gère la partie
    /// </summary>
    class Partie
    {
        Joueur joueurEnCours; // joueur en cours
        List<Joueur> listeJoueurs; // liste des joueurs de la partie
        Plateau p; // plateau de jeu 
        Affichage a = new Affichage();

        /// <summary>
        /// initialise le jeu, fait les demandes à l'utilisateur
        /// </summary>
        public void Initialise()
        {


            a.DemandeNbChevaux();
            listeJoueurs = a.DemandeNbJoueur();
            /*
            Joueur.NbChevaux = 2;
            Joueur j1 = new Joueur("moi", "bleu");
            Joueur j2 = new Joueur("toi", "vert");
            listeJoueurs = new List<Joueur>();
            listeJoueurs.Add(j1);
            listeJoueurs.Add(j2);*/
            p = new Plateau(listeJoueurs);
            a.AffichePlateau(p);
        }


        /// <summary>
        /// méthode qui lance la partie et rythme le jeu
        /// </summary>
        public void LancerPartie(int temps)
        {
            int valeurDe;
            bool memeJoueur = false;
            List<Possibilite> listepos = new List<Possibilite>();
            Possibilite unePossibilite;
            Initialise();
            do
            {
                Thread.Sleep(temps*1000);
                Console.Clear();
                if (!memeJoueur) { JoueurSuivant(); }
                  valeurDe = joueurEnCours.LanceLeDe(); 
              //  valeurDe = int.Parse(Console.ReadLine());
                a.Afficherde(joueurEnCours, valeurDe);
                // on rempli la liste des possibilités
                listepos = joueurEnCours.Avance(p, valeurDe);
                if (valeurDe == 6)
                {
                    memeJoueur = true;
                    // si le joueur n' a pas déjà un pion sur sa case de départ
                    if (p.PlateauJeu[joueurEnCours.CaseDepart].JoueurOccupant != joueurEnCours)
                    {
                        unePossibilite = joueurEnCours.SortirEcurie();
                        if (unePossibilite != null)
                        {// si possible, on ajoute la sortie d'un cheval à la liste des possibilités
                    
                            listepos.Add(unePossibilite);
                        }
                    }
                }
                else
                {
                    memeJoueur = false;
                }

                a.AffichePlateau(p);
                unePossibilite = a.ChoixDeJeu(joueurEnCours, listepos);
                if (unePossibilite != null)
                {
                    joueurEnCours.DeplacerPion(p, unePossibilite);
                }
               // a.AffichePlateau(p);

            }
            while (!joueurEnCours.Gagne());
            a.AfficherGagnant(joueurEnCours);
        }

        /// <summary>
        /// définit le joueur suivant, met à jour joueurEnCours
        /// </summary>
        /// <returns></returns>
        public void JoueurSuivant()
        {
            int numProchainJoueur;
            Random alea = new Random(DateTime.Now.Millisecond);
            if (joueurEnCours == null)
            {
                joueurEnCours = new Joueur();
                joueurEnCours.NumJoueur = alea.Next(1, listeJoueurs.Count);
                
                    
                    joueurEnCours = listeJoueurs.ElementAt(joueurEnCours.NumJoueur);
            }
            else
            { //A simplifier avec l'utilisation de modulo

                if (joueurEnCours.NumJoueur == Joueur.NbJoueur) numProchainJoueur = 1;
                else numProchainJoueur = joueurEnCours.NumJoueur + 1;

                joueurEnCours = listeJoueurs.ElementAt(numProchainJoueur-1);
            }
        }
    }
}
