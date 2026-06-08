using System;
using System.Drawing;

namespace ShlukMest
{
    /// <summary>
    /// Třída reprezentující město s jeho vlastnostmi
    /// </summary>
    internal class City
    {
        private string name;
        private Point center;
        private int population;
        private int infectedCount;
        private bool isRegional;

        public string Name { get { return name; } }
        public Point Center { get { return center; } }
        public int Population { get { return population; } }
        public int InfectedCount { get { return infectedCount; } }
        public bool IsRegional { get { return isRegional; } }

        public City(string name, Point center, int population, bool isRegional, int infectedCount)
        {
            this.name = name;
            this.center = center;
            this.population = population;
            this.isRegional = isRegional;
            this.infectedCount = infectedCount;
        }

        /// <summary>
        /// Vrací procento nakažených v tomto městě
        /// </summary>
        public double GetInfectionRate()
        {
            return (double)infectedCount / population * 100.0;
        }

        /// <summary>
        /// Vrací oblast pro vykreslení města jako malého kruhu
        /// </summary>
        public Rectangle GetCityArea()
        {
            // Velikost podle kategorie populace (malé značky)
            int size = GetSizeByPopulation() / 4;
            return new Rectangle(center.X - size, center.Y - size, size * 2, size * 2);
        }

        /// <summary>
        /// Vrací velikost podle kategorie populace
        /// </summary>
        private int GetSizeByPopulation()
        {
            if (population <= 1000) return 5;
            if (population <= 5000) return 8;
            if (population <= 20000) return 12;
            if (population <= 50000) return 16;
            if (population <= 100000) return 20;
            return 25;
        }

        public override string ToString()
        {
            return $"{name} ({population:N0} obyv., {GetInfectionRate():F1}% nakažených)";
        }
    }
}
