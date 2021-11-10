using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Space
    {
        public int NbLignes { get; set; }
        public int NbColonnes { get; set; }
        // Q5 public char[,] Grille { get; set; }
        public Invader[,] Grille { get; set; }

        public Space(int nbLignes, int nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            this.CreerListe();
        }

        private void CreerListe()
        {
            // Q5 Grille = new char[this.NbLignes, this.NbColonnes];
            Grille = new Invader[this.NbLignes, this.NbColonnes];
            for (int ligne = 0; ligne < this.NbLignes; ligne++)
            {
                for (int colonne = 0; colonne < this.NbColonnes; colonne++)
                {
                    //Q5  Grille[ligne, colonne] = ' ';
                    if (ligne == 0)
                    {
                        Grille[ligne, colonne] = new Invader();
                    }
                    else
                    {
                        Grille[ligne, colonne] = new Invader(' ');
                    }
                }
            }
        }

        public override string ToString()
        {
            string aff = "";  // cette variable permet de construire au fur et à mesure les éléments à afficher
            string ligneTiret = "";
            // on affiche la ligne au dessus
            for (int colonne = 0; colonne < this.NbColonnes; colonne++)
            {
                ligneTiret += "─";
            }
            aff += "┌" + ligneTiret + "┐\n";
            // on parcours toutes les cases du tableau
            for (int ligne = 0; ligne < this.NbLignes; ligne++)
            {
                aff += "|"; // on ajoute une barre verticale à gauche
                for (int colonne = 0; colonne < this.NbColonnes; colonne++)
                {
                    aff += (Grille[ligne, colonne]);
                }
                aff += "|\n";// on ajoute une barre verticale à droite
            }
            // on affiche la ligne au dessus
            aff += "└" + ligneTiret + "┘\n";
            return aff;
        }

        public void Afficher()
        {
            Console.WriteLine("nbLignes : " + NbLignes + "\n");
            Console.WriteLine("nbColonnes : " + NbColonnes + "\n");
            Console.WriteLine(this.ToString());
        }

        public void Tirer(int numColonne)
        {
            int ligne = NbLignes - 1;

            do
            {
                this.PlacerMissile(numColonne, ligne);
                Console.Clear();
                this.Afficher();
                Thread.Sleep(3000);
                ligne--;
            }
            while (ligne>=0); // tant qu'on est pas en haut , on fait avancer le missile
            // on retire le missile , il est arrivé en haut
            Grille[0, numColonne] = new Invader(' ');
            Console.Clear();
            this.Afficher();
        }

        private void PlacerMissile(int numColonne, int ligne)
        {
            Grille[ligne, numColonne] = new Invader('î'); // on place le missile au nouvel endroit
            if (ligne < this.NbLignes - 1)
                Grille[ligne + 1, numColonne] = new Invader(' '); // on enleve le missile de sa position precedente
        }
    }
}
