using System;

namespace TestsUnitaires
{
    class Program
    {
        static void Main(string[] args)
        {
            Compte compte = new Compte("Toto", 200);
            compte.Credit(100);
            compte.Debit(50);
            Console.WriteLine("Le nouveau solde est de : {0}€", compte.Solde);
            Console.ReadKey(); // permet de garder la console ouverte
        }
    }
}
