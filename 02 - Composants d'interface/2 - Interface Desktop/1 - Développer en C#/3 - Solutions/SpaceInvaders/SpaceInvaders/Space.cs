using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Space
    {
        public int NbLignes { get; set; }
        public int NbColonnes { get; set; }
        public char[,] Grille { get; set; }

        public Space(int nbLignes, int nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            this.CreerListe();
        }

        private void  CreerListe()
        {
            Grille = new char[this.NbLignes, this.NbColonnes];
            for (int ligne =0; ligne< this.NbLignes;ligne++)
            {
                for (int colonne = 0; colonne < this.NbColonnes; colonne++)
                {
                    Grille[ligne, colonne] = ' ';
                }
            }
        }

        public void AfficherGrille()
        {
            for (int ligne = 0; ligne < this.NbLignes; ligne++)
            {
                for (int colonne = 0; colonne < this.NbColonnes; colonne++)
                {
                    Console.Write(Grille[ligne, colonne]);
                }
            }
            Console.WriteLine();
        }

        public  void Afficher()
        {
            Console.WriteLine("nbLignes : " + NbLignes + "\n");
            Console.WriteLine("nbColonnes : " + NbColonnes + "\n");
            AfficherGrille();
        }
    }
}
