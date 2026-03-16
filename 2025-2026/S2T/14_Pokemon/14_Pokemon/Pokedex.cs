using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    /// <summary>
    /// Kolekce pokémonů – modeluje Pokédex.
    /// Implementuje IEnumerable<Pokemon>, díky čemuž lze Pokédex procházet
    /// pomocí foreach stejně jako běžný seznam.
    ///
    /// Interně využívá List<Pokemon> jako úložiště – třída Pokedex je tzv. wrapper
    /// (obal), který přidává doménovou logiku nad generickým listem.
    /// </summary>
    internal class Pokedex : IEnumerable<Pokemon>
    {
        // Vnitřní seznam pokémonů – privátní, přístupný jen přes metody třídy
        private List<Pokemon> items;

        /// <summary>
        /// Vrátí aktuální počet pokémonů v Pokédexu.
        /// </summary>
        public int Count()
        {
            return items.Count;
        }

        /// <summary>
        /// Implementace IEnumerable<Pokemon> – umožňuje iteraci přes foreach.
        /// Delegujeme přímo na enumerátor vnitřního listu.
        /// </summary>
       public IEnumerator<Pokemon> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Negenerická verze GetEnumerator() – vyžadována rozhraním IEnumerable.
        /// Deleguje na generickou verzi výše (standardní vzor implementace).
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Konstruktor inicializuje prázdný seznam pokémonů.
        /// </summary>
        public Pokedex()
        {
            items = new List<Pokemon>();
        }

        /// <summary>
        /// Přidá pokémona do Pokédexu a seznam ihned seřadí (přirozené řazení dle úrovně).
        /// Ignoruje null a duplicity – Contains() interně volá Equals() z třídy Pokemon.
        /// </summary>
        public void PridejPokemona(Pokemon pokemon)
        {
            // Ochrana před null referencí
            if (pokemon == null) return;

            // Contains() interně volá Equals() – proto máme v Pokemon přepsaný Equals()
            if (items.Contains(pokemon)) return;

            items.Add(pokemon);

            // Seřadíme hned po přidání, seznam je vždy připravený k výpisu
            items.Sort();
        }

        /// <summary>
        /// Odebere pokémona z Pokédexu, pokud v seznamu existuje.
        /// Nevyhodí výjimku, pokud pokemon není nalezen.
        /// </summary>
        public void OdeberPokemona(Pokemon pokemon)
        {
            // Contains() opět využívá Equals() pro porovnání
            if (items.Contains(pokemon))
            {
                items.Remove(pokemon);
            }
        }

        /// <summary>
        /// Vrátí nejsilnějšího pokémona (nejvyšší hodnota Strength).
        /// Seřadí seznam pomocí PokemonStrengthComparer (sestupně dle síly)
        /// a vrátí první prvek.
        /// Vrací null, pokud je Pokédex prázdný.
        /// </summary>
        public Pokemon NejsilnejsiPokemon()
        {
            if (items.Count == 0) return null;

            // Sort přijímá IComparer<Pokemon> – použijeme specializovaný porovnávač
            items.Sort(new PokemonStrengthComparer());

            // Po seřazení je nejsilnější pokémon na indexu 0
            return items[0];
        }

        /// <summary>
        /// Vrátí textový přehled Pokédexu seřazený dle přirozeného řazení pokémonů
        /// (sestupně dle úrovně, pak abecedně – definováno v Pokemon.CompareTo).
        /// Formát: hlavička s počtem + každý pokémon na novém řádku.
        /// </summary>
        public override string ToString()
        {
            // Seřadíme přirozeným pořadím (IComparable<Pokemon>) před výpisem
            items.Sort();

            string vystup = $"Počet pokemonů v pokedexu: {Count()}{Environment.NewLine}";

            foreach (Pokemon p in items)
            {
                vystup += $"{p.ToString()}{Environment.NewLine}";
            }

            return vystup;
        }

        /// <summary>
        /// Vrátí rozšířený přehled Pokédexu včetně nejsilnějšího pokémona.
        /// Kombinuje výstup ToString() s informací o nejsilnějším pokémonovi.
        /// Pokud je Pokédex prázdný, vrátí pouze základní přehled.
        ///
        /// Pozor: NejsilnejsiPokemon() interně volá Sort() s jiným Comparer než ToString(),
        /// proto Overview() volá NejsilnejsiPokemon() až po sestavení základního výstupu –
        /// jinak by Sort(PokemonStrengthComparer) přepsal řazení před výpisem.
        /// </summary>
        public string Overview()
        {
            // Nejdřív sestavíme základní výpis (ten interně seřadí dle úrovně)
            string vystup = ToString() + Environment.NewLine;

            // Pokud je Pokédex prázdný, není co zobrazovat
            if (NejsilnejsiPokemon() == null) return vystup;

            // Přidáme informaci o nejsilnějším pokémonovi
            return $"{vystup}Nejsilnější pokemon:" +
                $"{Environment.NewLine}{NejsilnejsiPokemon()}";
        }
    }
}
