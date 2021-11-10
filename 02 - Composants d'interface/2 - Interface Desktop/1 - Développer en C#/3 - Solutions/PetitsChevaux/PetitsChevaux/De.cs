using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitsChevaux
{
    /// <summary>
    /// gère les lancer de dé
    /// </summary>
    class De
    {
        /// <summary>
        /// renvoi un nombre aléatoire de 1 à 6
        /// </summary>
        /// <returns></returns>
        static public int LancerLeDe() {
            Random alea = new Random(DateTime.Now.Millisecond);
            return alea.Next(1, 7);
        }
    }
}
