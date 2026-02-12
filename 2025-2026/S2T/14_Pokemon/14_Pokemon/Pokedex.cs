using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    internal class Pokedex : IEnumerable<Pokemon>
    {
        private List<Pokemon> items;
        public int Count()
        {
            return items.Count;
        }

        public IEnumerator<Pokemon> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Pokedex()
        {
            items = new List<Pokemon>();
        }

        public void PridejPokemona(Pokemon pokemon)
        {
            if (pokemon == null) return;
            items.Add(pokemon);
            items.Sort();
        }

        public void OdeberPokemona(Pokemon pokemon)
        {
            if (items.Contains(pokemon))
            {
                items.Remove(pokemon);
            }

        }

        public Pokemon NejsilnejsiPokemon()
        {
            if (items.Count == 0) return null;
            items.Sort(new PokemonStrengthComparer());
            return items[0];
        }

        public override string ToString()
        {
            items.Sort();
            string vystup = $"Počet pokemonů v pokedexu: {Count()}{Environment.NewLine}";
          
            foreach (Pokemon p in items)
            {
                vystup += $"{p.ToString()}{Environment.NewLine}";
            }
            return vystup;

        }
    }
}
