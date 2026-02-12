using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    class Pokemon : IComparable<Pokemon>
    {
        private string name;
        private int level;
        private string type;
        private int strength;
        private int speed;
        private int hp;

        public int Speed { get { return speed; } }
        public int Strength { get { return strength; } }

        public Pokemon(string name, int level, string type, int strength, int speed, int hp)
        {
            this.name = name;
            this.level = level;
            this.type = type;
            this.strength = strength;
            this.speed = speed;
            this.hp = hp;
        }

        public override string ToString()
        {
            return $"[{level}. úroveň] {name} ({type} typ)";
        }

        public int CompareTo(Pokemon? other)
        {
            if (level.CompareTo(other.level) == 0)
            {
                return name.CompareTo(other.name);
            }
            // upřednostníme vyšší čísla, obracíme pořadí
            return -1 * level.CompareTo(other.level);
        }


    }
}
