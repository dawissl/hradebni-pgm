using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DnDKostky
{
    /// <summary>
    /// Třída reprezentující kostku (dice) pro hru.
    /// Uchovává počet stěn, barvu, volitelný popisek
    /// a výsledek posledního hodu.
    /// </summary>
    class Dice
    {
        // Počet stěn kostky (např. 6 = klasická šestistěnná)
        private int dSize;

        // Barva kostky (použitá při vykreslování)
        private Color color;

        // Volitelný popisek kostky (např. "útok", "obrana")
        private string dLabel;

        // Poslední hozená hodnota, výchozí -1 (ještě se neházelo)
        private int rolled = -1;

        // Veřejné vlastnosti
        public string DLabel { get { return dLabel; } set { dLabel = value; } }
        public Color DColor { get { return color; } }
        public int Rolled { get { return rolled; } }

        /// <summary>
        /// Konstruktor – vytvoří kostku se zadaným počtem stěn a barvou.
        /// </summary>
        public Dice(int d, Color c)
        {
            dSize = d;
            color = c;
        }

        /// <summary>
        /// Konstruktor – vytvoří kostku se stěnami, barvou a popiskem.
        /// </summary>
        public Dice(int d, Color c, string n)
        {
            dSize = d;
            color = c;
            dLabel = n;
        }

        /// <summary>
        /// Výchozí konstruktor – klasická žlutá šestistěnná kostka bez popisku.
        /// </summary>
        public Dice()
        {
            dSize = 6;
            color = Color.Yellow;
            dLabel = "";
        }

        /// <summary>
        /// Metoda provede hod kostkou.
        /// Vrátí náhodné číslo mezi 1 a počtem stěn včetně.
        /// Výsledek se uloží do vlastnosti Rolled.
        /// </summary>
        public int Roll()
        {
            int r = new Random().Next(1, dSize + 1);
            rolled = r;
            return r;
        }

        /// <summary>
        /// Textová reprezentace kostky – např. "D6 - Útok (Yellow)".
        /// </summary>
        public override string ToString()
        {
            return $"D{dSize} - {DLabel} ({color.Name})";
        }
    }
}
