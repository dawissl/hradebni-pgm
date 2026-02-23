using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarzTanky
{
    /// <summary>
    /// Reprezentuje jeden tank s jeho atributy.
    /// Implementuje IComparable<Tank> pro možnost řazení kolekcí tanků.
    /// </summary>
    class Tank : IComparable<Tank>
    {
        // Privátní datové členy – zapouzdření (encapsulation)
        // Přístup zvenčí je řízen přes properties nebo metody
        private string nazev;
        private int uroven;
        private string narod;
        private string typ;
        private int pancir;
        private int rychlost;
        private int kanon;

        /// <summary>
        /// Read-only property – pancíř lze číst, ale ne měnit zvenčí.
        /// Getter vrací hodnotu privátního pole pancir.
        /// </summary>
        public int Pancir { get { return pancir; } }

        /// <summary>
        /// Property s validací – úroveň lze nastavit pouze na kladnou hodnotu.
        /// Setter zabrání vložení nesmyslné hodnoty (0 nebo záporné číslo).
        /// </summary>
        public int Uroven
        {
            get { return uroven; }
            set
            {
                // Validace vstupu: úroveň musí být větší než 0
                if (value > 0) uroven = value;
            }
        }

        /// <summary>
        /// Konstruktor – inicializuje všechny datové členy najednou.
        /// Povinné při vytváření instance, zajistí konzistentní stav objektu.
        /// </summary>
        public Tank(string nazev, int uroven, string narod, string typ, int pancir, int rychlost, int kanon)
        {
            this.nazev = nazev;
            this.uroven = uroven;
            this.narod = narod;
            this.typ = typ;
            this.pancir = pancir;
            this.rychlost = rychlost;
            this.kanon = kanon;
        }

        /// <summary>
        /// Přepisuje výchozí ToString() z třídy Object.
        /// Vrací čitelný textový popis tanku – využívá se při výpisu do UI.
        /// Formát: [typ - úroveň. úroveň] název (národ)
        /// </summary>
        public override string ToString()
        {
            return $"[{typ} - {uroven}. úroveň] {nazev} ({narod})";
        }

        /// <summary>
        /// Implementace IComparable<Tank> – definuje přirozené řazení tanků.
        /// Primárně řadí sestupně podle úrovně (úroveň 10 je první).
        /// Při shodné úrovni řadí vzestupně podle názvu (abecedně).
        /// Používá se při volání List.Sort() bez explicitního Compareru.
        /// </summary>
        /// <param name="other">instance k porovnání</param>
        /// <returns>
        /// záporné číslo = this je "menší" (přijde dříve),
        /// 0 = stejné,
        /// kladné číslo = this je "větší" (přijde později)
        /// </returns>
        public int CompareTo(Tank? other)
        {
            // Pokud jsou úrovně stejné, řadíme abecedně podle názvu
            if (uroven.CompareTo(other.uroven) == 0)
            {
                return nazev.CompareTo(other.nazev);
            }

            // Násobení -1 invertuje výsledek CompareTo – tím dosáhneme
            // sestupného řazení (vyšší úroveň = dřív v seznamu)
            return -1 * uroven.CompareTo(other.uroven);
        }

        /// <summary>
        /// Přepisuje Equals() pro porovnávání tanků podle obsahu (hodnotová rovnost),
        /// nikoli podle reference (adresa v paměti).
        /// Používá se např. v List.Contains() při hledání duplicit v garáži.
        /// Dva tanky jsou shodné, pokud mají stejné: název, úroveň, národ a typ.
        /// </summary>
        public override bool Equals(object? obj)
        {
            // Pokus o přetypování – pokud obj není Tank, vrátí null
            Tank tank = obj as Tank;

            // Pokud přetypování selhalo (obj byl null nebo jiný typ), nejsou shodné
            if (tank == null) return false;

            // Porovnáme všechny relevantní vlastnosti
            return nazev == tank.nazev &&
                uroven == tank.uroven &&
                narod == tank.narod &&
                typ == tank.typ;
        }
    }
}
