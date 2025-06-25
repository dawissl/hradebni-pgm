using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Filmoteka
{
   class Komedie : Film
    {
        private string hlaska;

        public Komedie(string n, string r, int h, string hlaska) : base(n, r, h)
        {
            this.hlaska = hlaska;
        }

        public override string ToString()
        {
            return base.ToString()+"(Komedie)";
        }
    }
    class Horor : Film
    {
        private bool podleSkutecnosti;
        public Horor(string n, string r, int h, bool real) : base(n, r, h)
        {
            podleSkutecnosti = real;
        }
        public override string ToString()
        {
            return base.ToString() + "(Horor)";
        }
    }
    class Dokument : Film
    {
        private int rokVydani;
        public Dokument(string n, string r, int h, int rok) : base(n, r, h)
        {
            rokVydani = rok;
        }
        public override string ToString()
        {
            return base.ToString() + "(Dokument)";
        }
    }

    class Scifi : Film
    {
        private string hrdina;
        public Scifi(string n, string r, int h, string hrdina) : base(n, r, h)
        {
            this.hrdina = hrdina;
        }
        public override string ToString()
        {
            return base.ToString() + "(Sci-Fi)";
        }
    }
}
