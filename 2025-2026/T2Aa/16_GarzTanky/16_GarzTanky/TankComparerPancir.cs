using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarzTanky
{
    class TankComparerPancir : IComparer<Tank>
    {
        // porovnání dvou instancí na základě šíře pancíře
        // silnější pancíř je dříve v pořadí
        public int Compare(Tank? x, Tank? y)
        {
            
            return -1 * x.Pancir.CompareTo(y.Pancir);
        }
    }
}
