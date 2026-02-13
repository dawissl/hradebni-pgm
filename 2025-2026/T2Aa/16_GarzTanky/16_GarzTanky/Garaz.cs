using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarzTanky
{
    class Garaz : IEnumerable<Tank>
    {
        private List<Tank> items;

        public Garaz()
        {
            items = new List<Tank>();
        }

        public int PocetTanku()
        {
            return items.Count;
        }

        public int PridejTank(Tank novyTank)
        {
            if (novyTank == null) return 403;
            if (items.Contains(novyTank)) return 404;

            items.Add(novyTank);
            return 200;
        }

        public int OdeberTank(Tank tankNaOdebrani)
        {
            if (!items.Contains(tankNaOdebrani)) return 404;
            items.Remove(tankNaOdebrani);
            return 204;
        }

        public Tank NejsilnejsiPancirGaraze()
        {
            if (items.Count == 0) return null;
            items.Sort(new TankComparerPancir());
            return items[0];
        }

        public IEnumerator<Tank> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            items.Sort();
            string vystup = $"Tanková garáž [{PocetTanku()} tanků]:{Environment.NewLine}";
            foreach (Tank tank in items)
                vystup += tank.ToString() + Environment.NewLine;
            return vystup;
        }
    }
}
