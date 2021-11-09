using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employe
{
    class Employes
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Fonction { get; set; }
        public double Salaire { get; set; }
        public string Service { get; set; }

        public Employes(string nom, string prenom, DateTime dateEmbauche, string fonction, double salaire, string service)
        {
            Nom = nom;
            Prenom = prenom;
            DateEmbauche = dateEmbauche;
            Fonction = fonction;
            Salaire = salaire;
            Service = service;
        }

        public int NbAnneesAnciennete()
        {
            TimeSpan ecart = DateTime.Today - DateEmbauche;
            //Nombre d'années dans l'entreprise
            return ((int)ecart.TotalDays / 365);
        }

        public double PrimeSalaire()
        {
            return this.Salaire * 0.05;
        }

        public double PrimeAnciennete()
        {
            return this.Salaire * 0.02 * this.NbAnneesAnciennete();
        }
        public double Prime()
        {
            return Math.Round(this.PrimeSalaire()+this.PrimeAnciennete(),2); // on arrondi 2 chiffres après la virgule
        }
        /// <summary>
        /// Méthode théorique : en réalité la méthode serait déplacer en dehors de la classe Employes
        /// </summary>
        public void OrdreDeTransfert()
        {
            DateTime dateVersement = new DateTime(DateTime.Now.Year, 11, 30); // DateTime.Now.Year donne l'année du jour en cours
            if (DateTime.Now==dateVersement)  // peut être modifié par une comparaison de mois et jour uniquement
            {
                Console.WriteLine("Ordre de transfert de " + this.Prime() + "pour la salarié " + this.Nom);
            }
        }

        public static int ClassementNom(Employes a, Employes b)
        {
            if (a.Nom.CompareTo(b.Nom) > 0)
            {
                return 1;
            }else if(a.Nom.CompareTo(b.Nom) < 0)
            {
                return -1;
            }else if(a.Prenom.CompareTo(b.Prenom) > 0) // les noms sont égaux, on compare les prenoms
            {
                return 1;
            }else if (a.Prenom.CompareTo(b.Prenom) < 0)
            {
                return -1;
            }
            else
            {
                return 0; // noms et prenoms egaux
            }
        }
        public static int ClassementService(Employes a, Employes b)
        {
            if (a.Service.CompareTo(b.Service) > 0)
            {
                return 1;
            }
            else if (a.Service.CompareTo(b.Service) < 0)
            {
                return -1;
            }
            return ClassementNom(a, b); // si les services sont égaux, on renvoi la comparaison par Nom
        }

        public double MasseSalariale()
        {
            return this.Salaire + this.Prime();
        }

        public override string ToString()
        {
            
            string reponse =
            "****_INFORMATION_SUR_L'EMPLOYES_****" +
            "\n|Nom                : " + this.Nom +
            "\n|Prenom           : " + this.Prenom +
            "\n|Date Embauche    : " + this.DateEmbauche.ToString("dd/MM/yyyy") +  // on formate la date avant l'affichage
            "\n|Fonction         : " + this.Fonction +
            "\n|Salaire          : " + this.Salaire +
            "\n|Service          : " + this.Service;
            return reponse;
        }
    }
}
