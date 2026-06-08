using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dialogy
{
    public class Film
    {
        private string title;
        private string director;

        public string Title { get { return title; } set { title = value; } }
        public string Director
        {
            get => director;    
            set => director = Validace(value);
        }

        private string Validace(string x)
        {
            if (x.Contains("abc"))
            {
                throw new Exception("Nesmi obsahovat řetezec abc");
            }
            return x.ToUpper();
        }
        public Film(string title, string director)
        {
            this.title = title;
            this.director = director;
        }

        public override string ToString()
        {
            return $"Film: {title}, Director: {director}";
        }
    }
}
