using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleClick
{
    internal class Circle
    {
        private Point center;
        private Point topLeftCorner;
        private Color color;
        private int number;
        private int radius;

        public Point Center { get { return center; } }
        public Color Color { get { return color; } set { color = value; } }

        public Circle(Point center, Color color, int number)
        {
            this.center = center;
            this.color = color;
            this.number = number;
            // radius of circle is avalible from 10px to 200px
            radius = 2;
            topLeftCorner = new Point(center.X - radius, center.Y - radius);
        }

        // coefficient for count of radius represents values from 500 to 1M

        private double GetCoefficient(int number)
        {
            return 0.2;
        }

        public Rectangle GetArea()
        {
            return new Rectangle(topLeftCorner.X, topLeftCorner.Y, radius * 2, radius * 2);
        }

        public bool IsInCircle(Point cp)
        {
            return false;
        }

        public override string ToString()
        {
            return $"Center: [{center.X},{center.Y}]{Environment.NewLine}" +
                $"Value: {number}";
        }
    }
}
