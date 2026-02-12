using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarazTanky
{
    class Hangar : IEnumerable<Tank>
    {
        private List<Tank> items;

        public int PocetTanku()
        {
            return items.Count;
        }
        public Hangar()
        {
            items = new List<Tank>();
        }
        public IEnumerator<Tank> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool PridejTank(Tank novyTank)
        {
            if (novyTank == null) return false;
            items.Add(novyTank);
            return true;
        }

        public bool OdstranTank(Tank odstranovanyTank)
        {
            if(odstranovanyTank == null)  return false;
            if (!items.Contains(odstranovanyTank)) return false;
            items.Remove(odstranovanyTank);
            return true;
        }

        public Tank NejsilnejsiPancirVHangaru()
        {
            items.Sort(new TankComparatorPancir());
            return items[0];
        }
        public override string ToString()
        {
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
