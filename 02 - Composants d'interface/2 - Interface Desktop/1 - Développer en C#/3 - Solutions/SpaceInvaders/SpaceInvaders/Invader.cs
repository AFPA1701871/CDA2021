using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Invader
    {
        public char Motif { get; set; } 

        public Invader(char motif)
        {
            this.Motif = motif;
        }
        public Invader()
        {
            this.Motif = '#';
        }

        public override string ToString()
        {
            return this.Motif+"";
          // ou   return char.ToString(this.Motif);
        }
    }
}
