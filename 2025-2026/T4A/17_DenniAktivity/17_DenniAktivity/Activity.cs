using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DenniAktivity
{
    class Activity
    {
        private string name;
        private Color clrLabel;
        private int time;

        public string Name { get { return name; } }
        public Color Color { get { return clrLabel; } }
        public int Time { get { return time; } }
        public Activity(string name, Color clrLabel, int time)
        {

            this.name = name;
            this.clrLabel = clrLabel;
            this.time = time;
        }
  

        public override string ToString()
        {
            return $"{name} čas: {time} minut";
        }

    }
}
