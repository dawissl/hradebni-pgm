using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_NpcManager
{
    public class NpcCharacter
    {
        private string name;
        private int level;
        private bool friendly;
        public string Name { get { return name; } }
        public int Level { get { return level; } }
        public bool Friendly { get { return friendly; } }
        public NpcCharacter(string name, int level, bool friendly)
        {
            this.name = name;
            this.level = level;
            this.friendly = friendly;
        }
        public override string ToString()
        {
            return $"{name} (LVL {level})";
        }
    }
}
