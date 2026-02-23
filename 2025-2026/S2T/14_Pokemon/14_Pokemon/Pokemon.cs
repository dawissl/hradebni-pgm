using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    /// <summary>
    /// Reprezentuje jednoho pokémona s jeho atributy.
    /// Implementuje IComparable<Pokemon> pro možnost řazení kolekcí pokémonů.
    /// </summary>
    internal class Pokemon : IComparable<Pokemon>
    {
        // Privátní datové členy – zapouzdření (encapsulation)
        // Přístup zvenčí je řízen přes properties nebo metody
        private string name;
        private string type;
        private int HP;
        private int speed;
        private int level;
        private int strength;

        /// <summary>
        /// Read-only property – rychlost lze číst, ale ne měnit zvenčí.
        /// </summary>
        public int Speed { get { return speed; } }

        /// <summary>
        /// Read-only property – sílu lze číst, ale ne měnit zvenčí.
        /// Využívána v PokemonStrengthComparer pro porovnávání.
        /// </summary>
        public int Strength { get { return strength; } }

        /// <summary>
        /// Konstruktor – inicializuje všechny datové členy najednou.
        /// Povinné při vytváření instance, zajistí konzistentní stav objektu.
        /// </summary>
        public Pokemon(string name, string type, int hP, int speed, int level, int strength)
        {
            this.name = name;
            this.type = type;
            HP = hP;
            this.speed = speed;
            this.level = level;
            this.strength = strength;
        }

        /// <summary>
        /// Přepisuje výchozí ToString() z třídy Object.
        /// Vrací čitelný textový popis pokémona – využívá se při výpisu do UI.
        /// Formát: [typ - úroveň. úroveň] jméno
        /// </summary>
        public override string ToString()
        {
            return $"[{type} - {level}. úroveň] {name}";
        }

        /// <summary>
        /// Přepisuje Equals() pro hodnotové porovnávání (ne porovnávání referencí).
        /// Používá se interně v List.Contains() – například při kontrole duplicit v Pokédexu.
        /// Dva pokémoni jsou shodní, pokud mají stejné: jméno, úroveň a typ.
        /// </summary>
        public override bool Equals(object? obj)
        {
            // Null check – bez tohoto by mohl obj as Pokemon vyhodit výjimku
            if (obj == null) return false;

            // Bezpečná kontrola typu – nevyhodí výjimku, pokud obj není Pokemon
            if (!(obj is Pokemon)) return false;

            Pokemon p = obj as Pokemon;

            // Porovnáme relevantní vlastnosti – HP, speed ani strength nerozhodují o identitě
            return name == p.name && level == p.level && type == p.type;
        }

        /// <summary>
        /// Implementace IComparable<Pokemon> – definuje přirozené řazení pokémonů.
        /// Primárně řadí sestupně podle úrovně (nejvyšší úroveň je první).
        /// Při shodné úrovni řadí vzestupně podle jména (abecedně).
        /// Používá se při volání List.Sort() bez explicitního Compareru.
        /// </summary>
        /// <param name="other">instance k porovnání</param>
        /// <returns>
        /// záporné číslo = this přijde dříve,
        /// 0 = stejné,
        /// kladné číslo = this přijde později
        /// </returns>
        public int CompareTo(Pokemon? other)
        {
            if (level.CompareTo(other.level) == 0)
            {
                // Shodná úroveň → sekundární kritérium: abecedně podle jména
                return name.CompareTo(other.name);
            }

            // Násobení -1 invertuje výsledek CompareTo – tím dosáhneme
            // sestupného řazení (vyšší úroveň = dřív v seznamu)
            return -1 * level.CompareTo(other.level);
        }
    }
}
