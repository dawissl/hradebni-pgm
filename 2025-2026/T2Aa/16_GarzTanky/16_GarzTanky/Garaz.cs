using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarzTanky
{
    /// <summary>
    /// Kolekce tanků – modeluje tankovou garáž.
    /// Implementuje IEnumerable<Tank>, díky čemuž lze garáž procházet
    /// pomocí foreach stejně jako běžný seznam.
    ///
    /// Interně využívá List<Tank> jako úložiště – třída Garaz je tzv. wrapper
    /// (obal), který přidává doménovou logiku nad generickým listem.
    /// </summary>
    class Garaz : IEnumerable<Tank>
    {
        // Vnitřní seznam tanků – privátní, přístupný jen přes metody třídy
        private List<Tank> items;

        /// <summary>
        /// Konstruktor inicializuje prázdný seznam tanků.
        /// </summary>
        public Garaz()
        {
            items = new List<Tank>();
        }

        /// <summary>
        /// Vrátí aktuální počet tanků v garáži.
        /// </summary>
        public int PocetTanku()
        {
            return items.Count;
        }

        /// <summary>
        /// Přidá nový tank do garáže.
        /// Vrací stavový kód podobný HTTP stavům pro jednoznačnou signalizaci výsledku:
        ///   200 = OK, tank přidán
        ///   403 = Forbidden, předán null (neplatný vstup)
        ///   404 = Conflict, tank už v garáži existuje (využívá Equals z Tank)
        /// </summary>
        public int PridejTank(Tank novyTank)
        {
            // Ochrana před null referencí
            if (novyTank == null) return 403;

            // Contains() interně volá Equals() – proto máme v Tank přepsaný Equals()
            if (items.Contains(novyTank)) return 404;

            items.Add(novyTank);
            return 200;
        }

        /// <summary>
        /// Odebere tank z garáže.
        ///   204 = No Content, tank úspěšně odebrán
        ///   404 = Not Found, tank v garáži není
        /// </summary>
        public int OdeberTank(Tank tankNaOdebrani)
        {
            if (!items.Contains(tankNaOdebrani)) return 404;
            items.Remove(tankNaOdebrani);
            return 204;
        }

        /// <summary>
        /// Vrátí tank s nejsilnějším pancířem.
        /// Seřadí seznam pomocí TankComparerPancir (sestupně dle pancíře)
        /// a vrátí první prvek – tedy ten s největší hodnotou pancíře.
        /// Vrací null, pokud je garáž prázdná.
        /// </summary>
        public Tank NejsilnejsiPancirGaraze()
        {
            if (items.Count == 0) return null;

            // Sort přijímá IComparer<Tank> – použijeme náš specializovaný porovnávač
            items.Sort(new TankComparerPancir());

            // Po seřazení je tank s největším pancířem na indexu 0
            return items[0];
        }

        /// <summary>
        /// Implementace IEnumerable<Tank> – umožňuje iteraci přes foreach.
        /// Delegujeme přímo na enumerátor vnitřního listu.
        /// </summary>
        public IEnumerator<Tank> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Negenericka verze GetEnumerator() – vyžadována rozhraním IEnumerable.
        /// Deleguje na generickou verzi výše (standardní vzor implementace).
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Vrátí textový přehled garáže seřazený dle přirozeného řazení tanků
        /// (sestupně dle úrovně, pak abecedně – definováno v Tank.CompareTo).
        /// Formát: hlavička + každý tank na novém řádku.
        /// </summary>
        public override string ToString()
        {
            // Seřadí tanky jejich přirozeným pořadím (IComparable<Tank>)
            items.Sort();

            string vystup = $"Tanková garáž [{PocetTanku()} tanků]:{Environment.NewLine}";

            foreach (Tank tank in items)
                vystup += tank.ToString() + Environment.NewLine;

            return vystup;
        }
    }
}
