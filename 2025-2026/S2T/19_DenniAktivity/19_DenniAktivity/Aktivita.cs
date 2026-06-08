using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_DenniAktivity
{
    internal class Aktivita
    {
        private string nazevAktivity;
        private Color barva;
        private int stravenyCas;

        public string NazevAktivity => nazevAktivity;
        public int StravenyCas { get { return stravenyCas; } }
        public Color Barva { get => barva; }

        public Aktivita(string nazev, Color brv, int cas)
        {
            nazevAktivity = nazev;
            barva = brv;
            stravenyCas = cas;
        }

        public Aktivita(string nazev, int cas)
        {
            nazevAktivity = nazev;
            barva = Color.Black;
            stravenyCas = cas;
        }

        public override string ToString()
        {
            // TODO převést minuty do formátu HH:mm
            return $"{nazevAktivity}, strávený čas: {stravenyCas} minut";
        }
    }

}

