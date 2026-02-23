using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarazTanky
{
    /// <summary>
    /// Alternativní porovnávač tanků – řadí podle síly pancíře (sestupně).
    /// Implementuje rozhraní IComparer<Tank>, které umožňuje definovat
    /// vlastní způsob řazení mimo samotnou třídu Tank.
    ///
    /// Rozdíl oproti IComparable<Tank>:
    ///   - IComparable = "přirozené" řazení zabudované přímo do třídy Tank
    ///   - IComparer   = externí porovnávač, vhodný pro různé způsoby řazení
    ///
    /// Použití: items.Sort(new TankComparatorPancir())
    /// </summary>
    class TankComparatorPancir : IComparer<Tank>
    {
        /// <summary>
        /// Porovná dva tanky podle hodnoty pancíře.
        /// Ve výchozím případě CompareTo řadí od nejmenšího – násobení -1
        /// toto obrátí, takže tank s největším pancířem bude na indexu 0.
        /// </summary>
        /// <param name="x">první tank</param>
        /// <param name="y">druhý tank</param>
        /// <returns>
        /// záporné = x přijde dříve (x má silnější pancíř),
        /// 0 = stejná síla pancíře,
        /// kladné = y přijde dříve
        /// </returns>
        public int Compare(Tank? x, Tank? y)
        {
            // Násobení -1 invertuje výsledek → sestupné řazení (největší pancíř = první)
            return -1 * x.Pancir.CompareTo(y.Pancir);
        }
    }
}
