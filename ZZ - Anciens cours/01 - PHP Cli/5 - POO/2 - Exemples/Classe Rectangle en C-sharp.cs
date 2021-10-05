using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe_Geometrie
{
    class Rectangle
    {
        //Declaration des attributs de l'objet
        private int longueur;
        private int largeur;

        //Getter / Setter
        public int Longueur { get => longueur; set => longueur = value; }
        public int Largeur { get => largeur; set => largeur = value; }

        //Constructeurs
        public Rectangle()
        {

        }

        public Rectangle(int longueur, int largeur)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        //Methodes

        public int Perimetre()
        {            
            return this.longueur+this.largeur;
        }

        public int Aire()
        {
            return this.longueur * this.largeur;
        }

        //public void EstCarre()
        //{
        //    if (this.longueur == this.largeur)
        //    {
        //        Console.WriteLine("Il s'agit d'un Carré !");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Il s'agit d'un Rectangle !");
        //    }
        //}

        public string EstCarre()
        {
            if (this.longueur == this.largeur)
            {
                return "Il s'agit d'un Carré !";
            }
            else
            {
                return"Il s'agit d'un Rectangle !";
            }
        }

        public void AfficherRectangle()
        {
            Console.WriteLine("Longueur : " + this.longueur +" - Largeur : "+ this.largeur+" - Périmètre : "+ Perimetre()+" - Aire : "+ Aire()+" "+EstCarre());
        }

    }
}
