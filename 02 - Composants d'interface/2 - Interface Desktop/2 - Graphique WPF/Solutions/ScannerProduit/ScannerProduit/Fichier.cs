
        using System;
        using System.IO;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

namespace ScannerProduit
{
    class Fichier
    {

        //Méthodes

        public void EcrireFichier(string[] enreg, string path)
        // Ecris dans le fichier enreg
        {
            File.WriteAllLines(path, enreg);
        }

        public string[] LireFichier(string path)
        //Renvoi un tableau de chaine contenant les records stockées dans le fichier records
        {
            string[] tab = new string[5];
            //Lecture et stockage dans voiture
            tab = File.ReadAllLines(path);
            return tab;
        }


    }
}

	