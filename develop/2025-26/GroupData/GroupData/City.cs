using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupData
{
    class City
    {
        private bool isCounty;
        private int infectedCount;
        private string cityName;
        private int population;
        private Point center;

        public bool IsCounty { get { return isCounty; } }
        public int InfectedCount { get { return infectedCount; } }
        public int Population { get { return population; } }
        public Point Center { get { return center; } }

        public string Name {  get { return cityName; } }

        public City(string cityName, Point center, int infected, int population, bool isCounty)
        {
            this.cityName = cityName;
            this.center = center;
            this.isCounty = isCounty;
            this.infectedCount = infected;
            this.population = population;
        }

        public Rectangle GetCityArea()
        {
            int size = (int)(10 + 90 * GetCoefficient(population));
            return new Rectangle(center.X, center.Y, size, size);
        }

        private double GetCoefficient(int value)
        {
            return (value - 100.0) / (100000.0 - 100.0);
        }

        public override string ToString()
        {
            return $"{cityName} [{Math.Round((double)infectedCount / population, 2)} ({isCounty})]";
        }
        
    }
}
