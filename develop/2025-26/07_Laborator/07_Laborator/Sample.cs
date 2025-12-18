using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Laborator
{
    public class Sample
    {
        private string name;
        private string type;

        public string Name { get { return name; } }
        public string Type { get { return type; } }

        public Sample(string name, string type)
        {
            this.name = name.ToUpper();
            this.type = type.ToUpper();
        }

        public override string ToString()
        {
            return $"{name} [{type}]";
        }
    }
}
