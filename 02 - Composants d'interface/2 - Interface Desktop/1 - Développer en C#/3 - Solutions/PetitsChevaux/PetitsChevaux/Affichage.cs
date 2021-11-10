using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// class qui gère toutes les interactions avec l'utilisateur
    /// </summary>
    class Affichage
    {
        /// <summary>
        /// demande à l'utilisateur le nombre de joueur et instancie les joueurs en fonction de la réponse
        /// met à jour le nom, le numero, la couleur des joueurs
        /// </summary>
        /// <returns>Liste des joueurs instanciés</returns>
        public List<Joueur> DemandeNbJoueur()
        {
            string nom, couleur;
            int rep;
            bool ok;
            List<Joueur> liste = new List<Joueur>();
            do
            {
                Console.Write("Combien de joueurs ? :");
                ok = int.TryParse(Console.ReadLine(), out rep);
            }
            while (rep < 2 || !ok);

            // on crée les joueurs
            for (int i = 0; i < rep; i++)
            {
                // le nom du joueur
                Console.Write("Quel est le nom du joueur " + (i + 1) + " : ");
                nom = Console.ReadLine();
                // la couleur
                do
                {
                    Console.Write(@"Quelle est la couleur du joueur " + (i + 1) + " : ");
                    couleur = Console.ReadLine();
                }
                while (couleur != "bleu" && couleur != "rouge" & couleur != "jaune" && couleur != "vert");
                Joueur j = new Joueur(nom, couleur);
                liste.Add(j);

            }
            return liste;
        }

        /// <summary>
        /// demande à l'utilisateur le nombre de chevaux par joueur et modifie les instance de joueur
        /// </summary>
        public void DemandeNbChevaux()
        {
            int rep;
            bool ok;
            do
            {
                Console.Write("Combien de chevaux ? :");
                ok = int.TryParse(Console.ReadLine(), out rep);
            }
            while (rep < 1 || !ok);
            Joueur.NbChevaux = rep;
        }

        /// <summary>
        /// Demande à l'utilisateur de faire un choix de jeu, parmis une liste de possibilite
        /// </summary>
        /// <param name="j">joueur qui doit faire le choix</param>
        /// <param name="listePos">liste des chevaux qu'il peut bouger et les cases sur lesquels les mettre</param>
        /// <returns></returns>
        public Possibilite ChoixDeJeu(Joueur j, List<Possibilite> listePos)
        {
            string aff = "";
            int nbpossibilite = 0;
            bool ok;
            int rep;

            foreach (Possibilite po in listePos)
            {
                aff += nbpossibilite +"  :  le pion " + po.Cheval + " en case numéro " + po.IndicePlateau + "\n";
                nbpossibilite++;
            }
            switch (nbpossibilite)
            {
                case 0: Console.WriteLine(" :(  Impossible de jouer"); Console.WriteLine(""); return null;
                case 1:
                    {
                        Console.WriteLine(aff);
                        return listePos[0]; // on retourne la seule possibilite
                    }
                default:
                    {
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine(" Quelle solution voulez vous jouer : \n" + aff);
                            ok = int.TryParse(Console.ReadLine(), out rep);
                        }
                        while (rep < 0 || rep >= nbpossibilite || !ok);
                        return listePos[rep]; // on retourne la possibilite choisie
                    }
            }
        }

        /// <summary>
        /// permet d'écrire un message dans une couleur en fonction des paramètres
        /// on ne gère que les couleurs simples par un switch/case entre les couleurs et leur correspondance
        /// </summary>
        /// <param name="message">message à ecrire</param>
        /// <param name="couleur">libellé d'une couleur primaire</param>
        /// <param name="passageLigne">-1 pas de passage à la ligne, 0 changement colonne, 1 passage à la ligne</param>
        public void WriteCouleur(string message, string couleur, int passageLigne)
        {
            switch (couleur)
            {
                case "bleu": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "rouge": Console.ForegroundColor = ConsoleColor.Red; break;
                case "jaune": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "vert": Console.ForegroundColor = ConsoleColor.Green; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
            //  if (passageLigne) Console.WriteLine(message);
            switch (passageLigne)
            {
                case -1: Console.Write(message );
                    break;
                case 0:
                    Console.Write(message + "  | "); break;
                case 1:
                    Console.WriteLine(message);
                    break;
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>
        /// permet d'afficher le plateau avec des couleurs différentes pour les joueurs
        /// </summary>
        /// <param name="plat"></param>
        public void AffichePlateau(Plateau plat)
        {
            Console.WriteLine();
            foreach (Case c in plat.PlateauJeu)
            {
                if (c.JoueurOccupant == null)  // si une action après le if pas besoin {
                    WriteCouleur(c.Statut, "blanc",0);             
                else                
                    WriteCouleur(c.Statut + "   " +c.JoueurOccupant.Nom  , c.JoueurOccupant.Couleur,0);   
                if (c.Statut.Substring(0,1)=="a")
                {
                    // afficher les cases numérotées
                   
                }         
            }
            Console.WriteLine("\n");
            
        }
        public void Afficherde(Joueur joueur, int valeurDe)
        {
            WriteCouleur(joueur.Nom + " lance le dé : "  + valeurDe, joueur.Couleur,1);
        }
        public void AfficherGagnant(Joueur joueurEnCours)
        {
            WriteCouleur(joueurEnCours.Nom + " a gagné  " , joueurEnCours.Couleur, 1);
        }
    }
}
