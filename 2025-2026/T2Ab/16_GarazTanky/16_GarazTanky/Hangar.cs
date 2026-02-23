using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarazTanky
{
    /// <summary>
    /// Kolekce tanků – modeluje tankový hangár.
    /// Implementuje IEnumerable<Tank>, díky čemuž lze hangár procházet
    /// pomocí foreach stejně jako běžný seznam.
    ///
    /// Interně využívá List<Tank> jako úložiště – třída Hangar je tzv. wrapper
    /// (obal), který přidává doménovou logiku nad generickým listem.
    /// </summary>
    class Hangar : IEnumerable<Tank>
    {
        // Vnitřní seznam tanků – privátní, přístupný jen přes metody třídy
        private List<Tank> items;

        /// <summary>
        /// Vrátí aktuální počet tanků v hangáru.
        /// </summary>
        public int PocetTanku()
        {
            return items.Count;
        }

        /// <summary>
        /// Konstruktor inicializuje prázdný seznam tanků.
        /// </summary>
        public Hangar()
        {
            items = new List<Tank>();
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
        /// Negenerická verze GetEnumerator() – vyžadována rozhraním IEnumerable.
        /// Deleguje na generickou verzi výše (standardní vzor implementace).
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Přidá nový tank do hangáru.
        /// Vrací true při úspěchu, false při chybě:
        ///   false – předán null (neplatný vstup)
        ///   false – tank už v hangáru existuje (využívá Equals z Tank)
        /// </summary>
        public bool PridejTank(Tank novyTank)
        {
            // Ochrana před null referencí
            if (novyTank == null) return false;

            // Contains() interně volá Equals() – proto máme v Tank přepsaný Equals()
            if (items.Contains(novyTank)) return false;

            items.Add(novyTank);
            return true;
        }

        /// <summary>
        /// Odebere tank z hangáru.
        /// Vrací true při úspěchu, false pokud tank není v hangáru nebo je null.
        /// </summary>
        public bool OdstranTank(Tank odstranovanyTank)
        {
            if (odstranovanyTank == null) return false;

            // Pokud tank neexistuje, není co odebírat
            if (!items.Contains(odstranovanyTank)) return false;

            items.Remove(odstranovanyTank);
            return true;
        }

        /// <summary>
        /// Vrátí tank s nejsilnějším pancířem.
        /// Seřadí seznam pomocí TankComparatorPancir (sestupně dle pancíře)
        /// a vrátí první prvek – tedy ten s největší hodnotou pancíře.
        /// Vrací null, pokud je hangár prázdný.
        /// </summary>
        public Tank NejsilnejsiPancirVHangaru()
        {
            if (items.Count == 0) return null;

            // Sort přijímá IComparer<Tank> – použijeme specializovaný porovnávač
            items.Sort(new TankComparatorPancir());

            // Po seřazení je tank s největším pancířem na indexu 0
            return items[0];
        }

        /// <summary>
        /// Vrátí textový přehled hangáru seřazený dle přirozeného řazení tanků
        /// (sestupně dle úrovně, pak abecedně – definováno v Tank.CompareTo).
        /// Formát: hlavička + každý tank na novém řádku.
        /// </summary>
        public override string ToString()
        {
            // Seřadí tanky jejich přirozeným pořadím (IComparable<Tank>)
            items.Sort();

            string vystup = $"Tankový hangár [{PocetTanku()} tanků]:{Environment.NewLine}";

            foreach (Tank t in items)
            {
                vystup += t.ToString() + Environment.NewLine;
            }

            return vystup;
        }
    }
}
