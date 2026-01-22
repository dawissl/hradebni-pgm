using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskySenat
{
    /// <summary>
    /// Reprezentuje spolek (politickou stranu) ve volbách.
    /// </summary>
    internal class Spolek : IComparable<Spolek>
    {
        public string Name { get; }
        public int Vote { get; set; }
        public int Seats { get; set; }
        public double Percents { get; set; }
        public bool Valid { get; set; }

        public Spolek(string n, int initialVotes)
        {
            Name = n;
            Vote = initialVotes;
            Valid = false;
            Seats = 0;
            Percents = 0;
        }

        public int CompareTo(Spolek? other)
        {
            if (other == null) return -1;
            return -1 * this.Vote.CompareTo(other.Vote);
        }

        public override string ToString()
        {
            return $"{Name} získal {Vote} hlasů ({Math.Round(Percents * 100, 2)}%), {stringEnd()}";
        }

        private string stringEnd()
        {
            return Valid ? $"získal {Seats} křesel" : "nezískal žádná křesla";
        }
    }
}
