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
        // Q5 public char[,] Grille { get; set; }
        public Invader[,] Grille { get; set; }

        public Space(int nbLignes, int nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            this.CreerListe();
        }

        private void  CreerListe()
        {
           // Q5 Grille = new char[this.NbLignes, this.NbColonnes];
            Grille = new Invader[this.NbLignes, this.NbColonnes];
            for (int ligne =0; ligne< this.NbLignes;ligne++)
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
            for (int ligne = 0; ligne < this.NbLignes; ligne++)
            {
                for (int colonne = 0; colonne < this.NbColonnes; colonne++)
                {
                    aff += (Grille[ligne, colonne]);
                }
            }
            aff += "\n";
            return aff;
        }

        public  void Afficher()
        {
            Console.WriteLine("nbLignes : " + NbLignes + "\n");
            Console.WriteLine("nbColonnes : " + NbColonnes + "\n");
            Console.WriteLine(  this.ToString());
        }
    }
}
