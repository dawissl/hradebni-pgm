using System.Drawing.Drawing2D;
using System.IO;
using System.Xml.Linq;

namespace StudentskySenat
{
    internal class Delitel : IComparable<Delitel>
    {
        public string Name { get; }
        public double Divider { get; }

        public Delitel(string n, double d)
        {
            Name = n;
            Divider = d;
        }

        public int CompareTo(Delitel? other)
        {
            if (other == null) return -1;
            return -1 * Divider.CompareTo(other.Divider);
        }
    }
}