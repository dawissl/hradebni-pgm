using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    internal class PokemonStrengthComparer : IComparer<Pokemon>
    {
        public int Compare(Pokemon? x, Pokemon? y)
        {
            // využití předdefinované metody
            return x.Strength.CompareTo(y.Strength) * -1;
            // matematické vyjádření
           // return -1 * (x.Strength - y.Strength);
        }
    }
}
