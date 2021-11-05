using System;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnes p = new Personnes();
            Personnes toto = new Personnes("DUPOND", "Toto", 20, "Ici");
            //// p.nom="TRUC" si attribut public
            //p.SetNom( "TRUC"); // si attribut privé

            ///* si les attributs sont public */
            ////Console.WriteLine("info de toto : " + toto.nom + " " + toto.prenom +" " + toto);

            ///* si privé */
            //Console.WriteLine("nom de p : " + p.GetNom());
            //Console.WriteLine(p.ToString());

            //Console.WriteLine("info de toto : " + toto.GetNom() + " " + toto.GetPrenom() +" " + toto.ToString());


            //Personnes p1 = new Personnes("MACHIN", "Bidule");
            //Console.WriteLine("p1 " + p1.ToString());

            toto.Note = 3;
            Console.WriteLine("la note de toto est : " + toto.Note);

            Voitures v = new Voitures("titine", toto);
            Console.WriteLine(v.ToString());
        }
    }
}
