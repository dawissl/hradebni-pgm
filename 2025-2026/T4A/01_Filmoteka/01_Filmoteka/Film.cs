using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Filmoteka
{
    // třída implementuje interface IComparable, která nám umožňuje následné řazení objektu dle 
    // našich kritérií
    internal class Film  : IComparable<Film>
    {
        private string name;
        private string director;
        private int rating;
        private string note;

        public string Name { get { return name; } }
        public string Director { get { return director; } }
        public string Note { get { return note; } set { note = value; } }
        public int Rating { get { return rating; } set { rating = SetRating(value); } }

        private int SetRating(int value)
        {
            if (value < 0) return 0;
            if (value > 100) return 100;
            return value;
        }

        public Film(string name,string director)
        {
            this.name = name;
            this.director = director;
            rating = 0;
            note = string.Empty;
        }

        /// <summary>
        /// Vypisu info o filmu zejmena hodnocení
        /// </summary>
        /// <returns>retezec na vystup</returns>
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

        public string ToCsv()
        {
            return $"{name};{director};{rating};{note}";
        }

        public int CompareTo(Film? other)
        {
            if (other == null) return -1;
            if(name.CompareTo(other.name) == 0)
            {
                return director.CompareTo(other.director);
            }
            return name.CompareTo(other.name);
        }
               
    }
}