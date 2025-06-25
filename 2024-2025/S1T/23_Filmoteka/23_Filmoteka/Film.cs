using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Filmoteka
{
    class Film
    {
        private string nazevFilmu;
        private string reziserFilmu;
        private int hodnoceni;
        private double delka;
        public int Hodnoceni { set { hodnoceni = value; } }
        
        public Film(string nazev, string rezie, int hodnoceni)
        {
            nazevFilmu = nazev;
            reziserFilmu = rezie;
            this.hodnoceni = hodnoceni;
            delka = new Random().Next(40, 240);

        }
        
        public string Info()
        {
            return $"{nazevFilmu} ({Hvezdy(hodnoceni)}){Environment.NewLine}--------------{Environment.NewLine}Režie: {reziserFilmu}{Environment.NewLine}Délka: {delka} ";
        }

        private string Hvezdy(int hodnoceni)
        {
            string hvezdy = "*";
            for(int i = 0; i < hodnoceni / 20; i++)
            {
                hvezdy += "*";
            }
            return hvezdy;
        }

        public override string ToString()
        {

            return $"{nazevFilmu} {Hvezdy(hodnoceni)}";
        }
    }
}
