using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Pokemon
{
    internal class Pokemon : IComparable<Pokemon>
    {
        private string name;
        private string type;
        private int HP;
        private int speed;
        private int level;
        private int strength;

        public int Speed { get { return speed; } }
        public int Strength { get { return strength; } }

        public Pokemon(string name, string type, int hP, int speed, int level, int strength)
        {
            this.name = name;
            this.type = type;
            HP = hP;
            this.speed = speed;
            this.level = level;
            this.strength = strength;
        }

        public override string ToString() {
            return $"[{type} - {level}. úroveň] {name}";
        }

        public override bool Equals(object? obj)
        {           
            if(obj == null) return false ;
            if (!(obj is Pokemon)) return false; 
            Pokemon p = obj as Pokemon;
            return name == p.name && level == p.level && type == p.type;
        }

        public int CompareTo(Pokemon? other)
        {
            if(level.CompareTo(other.level) == 0)
            {
                return name.CompareTo(other.name);
            }
            // obracíme výsledek pro řazení od nejvyšší hodnoty
            return -1 * level.CompareTo(other.level);
        }
    }
}
