using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarzTanky
{
    /// <summary>
    /// Alternativní porovnávač tanků – řadí podle síly pancíře (sestupně).
    /// Implementuje rozhraní IComparer<Tank>, které umožňuje definovat
    /// vlastní způsob řazení mimo samotnou třídu Tank.
    ///
    /// Rozdíl oproti IComparable<Tank>:
    ///   - IComparable = "přirozené" řazení zabudované přímo do třídy
    ///   - IComparer   = externí porovnávač, vhodný pro různé způsoby řazení
    ///
    /// Použití: items.Sort(new TankComparerPancir())
    /// </summary>
    class TankComparerPancir : IComparer<Tank>
    {
        /// <summary>
        /// Porovná dva tanky podle hodnoty pancíře.
        /// Vrací výsledek tak, aby silnější pancíř byl dřív (sestupné řazení).
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
            // Násobení -1 invertuje výsledek CompareTo,
            // čímž docílíme sestupného řazení (největší pancíř = první pozice)
            return -1 * x.Pancir.CompareTo(y.Pancir);
        }
    }
}
