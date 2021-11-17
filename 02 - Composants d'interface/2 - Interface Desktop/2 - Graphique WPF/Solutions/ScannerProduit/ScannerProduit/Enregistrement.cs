using System;
using System.Collections.Generic;
namespace ScannerProduit
{
    class Enregistrement
    {

        //Attributs
        private string codeBarre;
        private string produit;

        static string path = @"../../../Produit.txt";

        public string Produit { get => produit; set => produit = value; }
        public string CodeBarre { get => codeBarre; set => codeBarre = value; }



        //Constructeurs

        public Enregistrement() { }
        public Enregistrement(string codeBarre, string produit)
        {
            this.codeBarre = codeBarre;
            this.produit = produit;

        }



        public void AjoutEnregistrement()
        //Méthode qui permet d'entrer un enregistrement
        {
            string[] tabDesEnregistrements; //Créer un nouveau tableau de string
            List<Enregistrement> liste = new List<Enregistrement>();
            Fichier f = new Fichier();
            tabDesEnregistrements = f.LireFichier(path); //Mets le fichier Produits.txt dans le tableau
            int taille = tabDesEnregistrements.Length;
            Array.Resize(ref tabDesEnregistrements, taille + 1);
            tabDesEnregistrements[taille] = this.ToString();// modifier le dernier enreg du tableau
            Array.Sort(tabDesEnregistrements);//trier le tableau
            f.EcrireFichier(tabDesEnregistrements, path); //enregistrer fichier
        }



        public override string ToString() // Méthode toString transforme un objet en chaîne de caractère
        {
            return CodeBarre + ";" + Produit;
        }

        static public List<Enregistrement> ListeEnreg()
        //Ajoute un nouveau enregistrement à une liste selon le niveau choisi
        {

            int i;
            Enregistrement r;
            List<Enregistrement> liste = new List<Enregistrement>();
            Fichier f = new Fichier();
            string[] tab = new string[10];
            string[] ligne;
            tab = f.LireFichier(path);
            for (i = 0; i < tab.Length; i++)
            {
                r = new Enregistrement();
                ligne = tab[i].Split(';');
                r.CodeBarre = ligne[0]; // prend les 2 premiers caractères à partir de la position 0
                r.Produit = ligne[1]; // prend 5 caractères à partir de la position 2
                liste.Add(r);
            }

            return liste;
        }
        static public List<Enregistrement> ChercherEnreg(string code)
        //Ajoute un nouveau enregistrement à une liste selon le niveau choisi
        {

            int i;
            Enregistrement r;
            List<Enregistrement> liste = new List<Enregistrement>();
            Fichier f = new Fichier();
            string[] tab = new string[10];
            string[] ligne;
            tab = f.LireFichier(path);
            for (i = 0; i < tab.Length; i++)
            {
                
                r = new Enregistrement();
                ligne = tab[i].Split(';');
                r.CodeBarre = ligne[0]; // prend les 2 premiers caractères à partir de la position 0
                r.Produit = ligne[1]; // prend 5 caractères à partir de la position 2
                if (code== r.codeBarre) liste.Add(r);
            }

            return liste;
        }
    }

}

