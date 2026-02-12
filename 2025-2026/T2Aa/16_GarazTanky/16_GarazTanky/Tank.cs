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
        private string narod;
        private string typ;
        private int pancir;
        private int rychlost;
        private int kanon;

        public int Pancir { get { return pancir; } }
        public int Uroven
        {
            get { return uroven; }
            set
            {

                if (value > 0) uroven = value;
            }
        }

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

        public override string ToString()
        {
            return $"[{typ} - {uroven}. úroveň] {nazev} ({narod})";
        }

        /// <summary>
        /// Řazení od nejvyšší úrovně po nejnižší, v případě shody porovnáváme podle jména
        /// </summary>
        /// <param name="other">instance k porovnání</param>
        /// <returns>zařazení instancí</returns>
        public int CompareTo(Tank? other)
        {
            if (uroven.CompareTo(other.uroven) == 0)
            {
                return nazev.CompareTo(other.nazev);
            }
            // nasobime -1 abychom obrátili pořadí řazení první je lvl 10 
            return -1 * uroven.CompareTo(other.uroven);
        }
    }
}
