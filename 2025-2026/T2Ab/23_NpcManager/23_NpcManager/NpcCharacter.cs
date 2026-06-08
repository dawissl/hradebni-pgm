using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_NpcManager
{
    public class NpcCharacter
    {
        private string name;
        private int lvl;
        private bool friendly;
        private string race;
        private string description;

        public string Name { get { return name; } }
        public int Level { get { return lvl; } }
        public bool Friendly { get { return friendly; } }
        public string Race { get { return race; } }

        public string Description { get { return description; } }


        public NpcCharacter(string n, int l, bool f, string r, string d)
        {
            name = n;
            lvl = l;
            friendly = f;
            race = r;
            description = d;
        }

        public override string ToString()
        {
            return $"{name} ({race}, LVL {lvl})";
        }


    }
}
