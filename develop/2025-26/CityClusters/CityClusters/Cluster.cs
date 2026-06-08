using System.Collections.Generic;
using System.Linq;


namespace CityClusters
{
    public class Cluster
    {
        public City Centroid { get; set; }
        public List<City> Cities { get; set; } = new List<City>();


        public int TotalPopulation => Cities.Sum(c => c.Population);
        public int TotalInfected => Cities.Sum(c => c.Infected);


        public double InfectionRate => TotalPopulation == 0
        ? 0
        : (double)TotalInfected / TotalPopulation * 100;


        public override string ToString()
        {
            return $"{Centroid.Name} ({Cities.Count} měst) - {InfectionRate:F2}%";
        }
    }
}