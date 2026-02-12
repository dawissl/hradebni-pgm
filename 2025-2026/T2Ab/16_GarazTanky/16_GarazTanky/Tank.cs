using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GarazTanky
{
    class Tank : IComparable<Tank>
    {
        private string nazev;
        private int uroven;
        private string typ;
        private string narod;
        private int pancir;
        private int rychlost;
        private int kanon;

        public int Pancir { get { return pancir; } }

        public Tank(string nazev, int uroven, string typ, string narod, int pancir, int rychlost, int kanon)
        {
            this.nazev = nazev;
            this.uroven = uroven;
            this.typ = typ;
            this.narod = narod;
            this.pancir = pancir;
            this.rychlost = rychlost;
            this.kanon = kanon;
        }

        public int CompareTo(Tank? other)
        {
            if (other == null) return 1;
            if (uroven.CompareTo(other.uroven) == 0)
            {
                // dodatečné kriterium název
                return nazev.CompareTo(other.nazev);
            }
            else
            {
                // násobení -1 otáčí pořadí řazení (výchozí je od nejmenšího)
                return -1 * uroven.CompareTo(other.uroven);
            }
        }

        public override string ToString()
        {
            return $"[{typ} - {uroven}. úroveň] {nazev} ({narod})";
        }
    }
}
