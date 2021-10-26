using System;

namespace Decouverte
{
    class Program
    {
        static void Main(string[] args)
        {
            String chaineSaisie;
            int entier;
           
            Console.Write("Saisir un entier : ");

            chaineSaisie = Console.ReadLine().ToUpper();

            try
            {
                entier = Convert.ToInt32(chaineSaisie);
                Console.Write("Votre entier est : " + entier);
            }
            catch (Exception e)
            {
                Console.Write("Votre entier n'est pas un entier");
                Console.WriteLine("L'erreur généré est " + e);
                
            }
            
        }
    }
}
