using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    class Pokedex : IEnumerable<Pokemon>
    {
        private List<Pokemon> pokemons;

        public Pokedex()
        {
            pokemons = new List<Pokemon>();

        }

        public bool PridejPokemona(Pokemon p)
        {
            if (p == null) return false;
            if (p.Strength < 0) return false;
            pokemons.Add(p);
            return true;
        }

        public bool OdstranPokemona(Pokemon p)
        {
            if (p == null) return false;
            if (!pokemons.Contains(p)) return false;
            if (pokemons.Count == 0) return false;
            pokemons.Remove(p);
            return true;
        }

        public Pokemon NejrychlejsiPokemon()
        {
            pokemons.Sort(new PokemonCoparatorSpeed());
            return pokemons[0];
        }

        public override string ToString()
        {
            pokemons.Sort();
            string vystup = $"V pokedexu je {pokemons.Count} pokemonů: {Environment.NewLine}";
            foreach (Pokemon p in pokemons)
                vystup += p.ToString() + Environment.NewLine;
            return vystup;
        }

        public IEnumerator<Pokemon> GetEnumerator()
        {
            return pokemons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
