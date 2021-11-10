using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    class Program
    {
        static void Main(string[] args)
        {
            string rep;
            do
            {
                // Lancer une partie
                Partie p = new Partie();
                int temps=2;
                int nbArgs = args.Length;

                if (nbArgs>0 && int.TryParse( args[0], out temps));
               
                p.LancerPartie(temps);

                // Demander à l'utilisateur s'il veut rejouer et boucler
                Console.WriteLine("Voulez-vous rejouer ? (o/n) :");
                rep = Console.ReadLine();
            }
            while (rep.ToUpper() == "O");
            Console.ReadLine();
        }
    }
}
