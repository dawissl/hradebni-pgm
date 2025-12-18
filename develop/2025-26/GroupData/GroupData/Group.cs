using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupData
{
    class Group
    {
        private Point centroid;
        private int value;
        private List<City> cityList = new List<City>();
        private Color color;
        private static int BASE_RADIUS = 10;

        public int Value { get { return value; } }
        public Color Color { get { return color; } set { color = value; } }
        public List<City> CityList { get { return cityList; } }
        public Point Centroid { get { return centroid; } }
        public Group(City city)
        {
            value = city.Population;
            cityList.Add(city);
            color = Color.FromArgb(200,255,0,0);
            centroid = city.Center;
        }

        public Rectangle GetArea()
        {
            int size = (int)(BASE_RADIUS + 140 * GetCoefficient(value))/2;
            return new Rectangle(centroid.X-size, centroid.Y-size, 2*size, 2*size);
        }

        public double GetGroupPercents()
        {
            double total = 0;
            double infectedTotal = 0;
            foreach (City city in cityList)
            {
                total += city.Population;
                infectedTotal += city.InfectedCount;
            }
            return Math.Round(100 * (infectedTotal / total), 2);
        }
        private double GetCoefficient(int value)
        {
            return (value - 100.0) / (100000.0 - 100.0);
        }

        public void AddCity(City c)
        {
            cityList.Add(c);
            value += c.Population;
        }

        public double GetDistance(Point p)
        {
            return Math.Sqrt((p.X - centroid.X) * (p.X - centroid.X) + (p.Y - centroid.Y) * (p.Y - centroid.Y));
        }

        public override string ToString()
        {
            return $"{cityList[0].Name} [{cityList.Count - 1}]";
        }

        public string Info()
        {
            string s = ToString()+" " + cityList[0].Population + Environment.NewLine;
            for (int i = 1; i < cityList.Count; i++)
            {
                s += cityList[i].Name+" "+ cityList[i].Population + Environment.NewLine;
            }
            return s;
        }
    }
}
