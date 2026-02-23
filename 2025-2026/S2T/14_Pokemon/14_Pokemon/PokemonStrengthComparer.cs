using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    /// <summary>
    /// Alternativní porovnávač pokémonů – řadí podle síly (sestupně).
    /// Implementuje rozhraní IComparer<Pokemon>, které umožňuje definovat
    /// vlastní způsob řazení mimo samotnou třídu Pokemon.
    ///
    /// Rozdíl oproti IComparable<Pokemon>:
    ///   - IComparable = "přirozené" řazení zabudované přímo do třídy Pokemon (podle úrovně)
    ///   - IComparer   = externí porovnávač, vhodný pro různé způsoby řazení
    ///
    /// Použití: items.Sort(new PokemonStrengthComparer())
    /// </summary>
    internal class PokemonStrengthComparer : IComparer<Pokemon>
    {
        /// <summary>
        /// Porovná dva pokémony podle hodnoty síly (Strength).
        /// Výsledek je invertován, aby silnější pokémon byl dřív (sestupné řazení).
        /// </summary>
        /// <param name="x">první pokémon</param>
        /// <param name="y">druhý pokémon</param>
        /// <returns>
        /// záporné = x přijde dříve (x je silnější),
        /// 0 = stejná síla,
        /// kladné = y přijde dříve
        /// </returns>
        public int Compare(Pokemon? x, Pokemon? y)
        {
            // Využití předdefinované metody CompareTo, výsledek invertován násobením -1
            return x.Strength.CompareTo(y.Strength) * -1;

            // Alternativní matematické vyjádření – funguje stejně:
            // return -1 * (x.Strength - y.Strength);
        }
    }
}
