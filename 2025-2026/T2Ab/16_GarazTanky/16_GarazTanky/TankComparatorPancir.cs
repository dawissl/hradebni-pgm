using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarazTanky
{
    class TankComparatorPancir : IComparer<Tank>
    {
        // ve výchozím případě řadíme od nejmenšího po největší
        public int Compare(Tank? x, Tank? y)
        {
            // násobení -1 otáčí pořadí řazení
            return -1 * x.Pancir.CompareTo(y.Pancir);
        }
    }
}
