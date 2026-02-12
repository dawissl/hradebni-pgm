using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    class PokemonCoparatorSpeed : IComparer<Pokemon>
    {
        public int Compare(Pokemon? x, Pokemon? y)
        {
            return -1 * x.Speed.CompareTo(y.Speed);
        }
    }
}
