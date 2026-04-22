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
        private string cityName;
        private int population;
        private Point center;

        public int Population { get { return population; } }
        public Point Center { get { return center; } }

        public string Name {  get { return cityName; } }

        public City(string cityName, Point center, int population)
        {
            this.cityName = cityName;
            this.center = center;
            this.population = population;
        }

        public Rectangle GetCityArea()
        {
            // TODO
            return new Rectangle();
        }

        private double GetCoefficient(int value)
        {
            return 1.2;
        }

        public override string ToString()
        {
            return $"{cityName} [{Math.Round((double)infectedCount / population, 2)} ({isCounty})]";
        }
        
    }
}
