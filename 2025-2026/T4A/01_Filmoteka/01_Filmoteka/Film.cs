using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Filmoteka
{
    internal class Film
    {
        private string name;
        private string director;
        private int rating;
        private string note;

        public string Name { get { return name; } }
        public string Director { get { return director; } }

        public int Rating { get { return rating; } set { rating = SetRating(value); } }

        private int SetRating(int value)
        {
            if (value < 0) return 0;
            if (value > 100) return 100;
            return value;
        }

        public string Note
        {
            set { note = value; }
        }

        public Film(string name,string director)
        {
            this.name = name;
            this.director = director;
            rating = 0;
            note = string.Empty;
        }

        public string Info()
        {
            //Enviroment.NewLine - systémová konstanta pro zjištění 
            // zalomení nového řádku (vkládá /n nebo /r/n podle OS)
            return $"Hodnocení: {rating}{Environment.NewLine}{note}";
        }

       public override string ToString()
        {
            // $"" - formátovaný řetězec
            // $"běžný text {vstup pro umístění proměnné}"
            // Na výstup se objeví "TOPGUN - Guy Ritchie"
            //return name.ToUpper() + " - " + director;
            return $"{name.ToUpper()} - {director}";
        }
    }
}