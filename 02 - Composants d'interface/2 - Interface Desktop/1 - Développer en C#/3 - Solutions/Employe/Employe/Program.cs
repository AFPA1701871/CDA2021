using System;
using System.Collections.Generic;

namespace Employe
{
    class Program
    {
        static void Main(string[] args)
        {
            Employes bruno = new Employes("MAYEUX","Bruno",  new DateTime(2000, 10, 15), "Chef de projet", 45500, "Front-End");
            Employes pierre = new Employes("COURQUIN","Pierre",  new DateTime(2020, 5, 1), "Developpeur", 67500, "Front-End");
            Employes martine = new Employes("POIX","Martine",  new DateTime(2021, 11, 01), "Stagiaire", 0, "Café");
            Employes quentin = new Employes("BALAIR","Quentin",  new DateTime(2017, 02, 15), "Developpeur", 0, "Back-End");
            Employes maxence = new Employes("THACKER","Maxence",  new DateTime(2021, 11, 01), "Stagiaire", -1000, "Menage");

            Console.WriteLine(bruno.Prime());

            List<Employes> listeEmployes = new List<Employes>()
            {
            bruno,
            pierre };
            listeEmployes.Add(martine);
            listeEmployes.Add(quentin);
            listeEmployes.Add(maxence);

            Console.WriteLine("Nombre d'employer dans la societe : " + listeEmployes.Count);

            Console.WriteLine("\n Avant TRI\n");
            foreach (var item in listeEmployes)
            {
                Console.WriteLine(item);
            }

            listeEmployes.Sort(Employes.ClassementService); // tri de la liste en utilisant la methode de comparaison Classement

            Console.WriteLine("\n APRES TRI\n");
            foreach (var item in listeEmployes)
            {
                Console.WriteLine(item);
            }


            /* Masse salariale*/
            double masseSalarialeAnnuelle=0;
            foreach (var item in listeEmployes)
            {
                masseSalarialeAnnuelle += item.MasseSalariale();
            }
            Console.WriteLine("La masse salariale annuelle est de " + masseSalarialeAnnuelle);
        }
    }
}
