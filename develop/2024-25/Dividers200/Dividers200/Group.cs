using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dividers200
{
    internal class Group : IComparable<Group>
    {
        private string name;
        private int member_count;
        private bool valid;
        private Color badge;
        private int leaders;

        public int Count { get { return member_count; } set { member_count = value; } }
        public Color Badge { get { return valid ? badge : TransparetShade(badge); } }
        public bool Valid { get { return valid; } set { valid = value; } }

        public int Leaders { get { return leaders; }set { leaders = value; } }
        public string Name { get { return name; } }

        /// <summary>
        /// Make color with 30% transparency
        /// </summary>
        /// <param name="badge"></param>
        /// <returns></returns>
        private Color TransparetShade(Color badge)
        {
            int originalColor = badge.ToArgb();
            int alpha = (originalColor >> 24) & 0xFF;
            int newAlpha = (int)(alpha * 0.3);
            int newColor = (originalColor & 0x00FFFFFF) | (newAlpha << 24);
            return Color.FromArgb(newColor);
        }

        public int CompareTo(Group? other)
        {
            return other.Count.CompareTo(Count);
        }

        public Group(string name, Color badge)
        {
            this.name = name;
            this.badge = badge;
        }

        public override string ToString()
        {
            return $"{name.ToUpper()}: {member_count} [{leaders}] [{valid}]";
        }
    }
}
