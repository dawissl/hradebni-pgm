using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ShlukMest
{
    /// <summary>
    /// Třída reprezentující shluk měst seskupených kolem krajského města (centroidu)
    /// </summary>
    internal class Group
    {
        private Point centroid;
        private int totalPopulation;
        private List<City> cities = new List<City>();
        private Color color;
        private static int BASE_RADIUS = 15;

        public int TotalPopulation { get { return totalPopulation; } }
        public Color Color { get { return color; } set { color = value; } }
        public List<City> Cities { get { return cities; } }
        public Point Centroid { get { return centroid; } }

        /// <summary>
        /// Konstruktor - vytvoří nový shluk s krajským městem jako centroidem
        /// </summary>
        public Group(City regionalCity)
        {
            totalPopulation = regionalCity.Population;
            cities.Add(regionalCity);
            centroid = regionalCity.Center;
            // Barva se nastaví podle % nakažených
            UpdateColor();
        }

        /// <summary>
        /// Přidá město do shluku a aktualizuje celkovou populaci
        /// </summary>
        public void AddCity(City city)
        {
            cities.Add(city);
            totalPopulation += city.Population;
            UpdateColor();
        }

        /// <summary>
        /// Vrací oblast pro vykreslení shluku jako kruhu
        /// Velikost kruhu závisí na celkové populaci shluku
        /// </summary>
        public Rectangle GetArea()
        {
            // Výpočet velikosti kruhu podle celkové populace
            int size = BASE_RADIUS + (int)(totalPopulation / 15000.0);
            if (size > 80) size = 80; // Maximální velikost
            return new Rectangle(centroid.X - size, centroid.Y - size, size * 2, size * 2);
        }

        /// <summary>
        /// Vypočítá procento nakažených v celém shluku
        /// </summary>
        public double GetInfectionRate()
        {
            double totalInfected = 0;
            foreach (City city in cities)
            {
                totalInfected += city.InfectedCount;
            }
            return (totalInfected / totalPopulation) * 100.0;
        }

        /// <summary>
        /// Aktualizuje barvu shluku podle % nakažených
        /// Škála: <40% zelená, <70% žlutá, <80% oranžová, <90% tmavě oranžová, >=90% červená
        /// </summary>
        private void UpdateColor()
        {
            double rate = GetInfectionRate();
            if (rate < 40)
                color = Color.FromArgb(200, 0, 200, 0);      // Zelená
            else if (rate < 70)
                color = Color.FromArgb(200, 255, 255, 0);    // Žlutá
            else if (rate < 80)
                color = Color.FromArgb(200, 255, 165, 0);    // Oranžová
            else if (rate < 90)
                color = Color.FromArgb(200, 255, 100, 0);    // Tmavě oranžová
            else
                color = Color.FromArgb(200, 255, 0, 0);      // Červená
        }

        /// <summary>
        /// Vypočítá euklidovskou vzdálenost od daného bodu k centroidu
        /// </summary>
        public double GetDistance(Point point)
        {
            int dx = point.X - centroid.X;
            int dy = point.Y - centroid.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Kontroluje, zda daný bod leží uvnitř kruhu shluku
        /// </summary>
        public bool IsInCluster(Point point)
        {
            Rectangle area = GetArea();
            int radius = area.Width / 2;
            double distance = GetDistance(point);
            return distance <= radius;
        }

        /// <summary>
        /// ToString pro zobrazení v ListBoxu - název krajského města + počet dalších měst
        /// </summary>
        public override string ToString()
        {
            City regionalCity = cities[0]; // První město je vždy krajské
            if (cities.Count == 1)
                return $"{regionalCity.Name} (žádná další města)";
            else
                return $"{regionalCity.Name} [{cities.Count - 1} dalších měst]";
        }

        /// <summary>
        /// Vrací detailní informace o shluku pro zobrazení v labelu
        /// </summary>
        public string GetDetailInfo()
        {
            string info = $"=== {cities[0].Name} ==={Environment.NewLine}";
            info += $"Celková populace: {totalPopulation:N0}{Environment.NewLine}";
            info += $"Procento nakažených: {GetInfectionRate():F2}%{Environment.NewLine}";
            info += $"{Environment.NewLine}Města ve shluku:{Environment.NewLine}";
            
            foreach (City city in cities)
            {
                info += $"• {city.Name} - {city.Population:N0} obyv. ({city.GetInfectionRate():F1}%){Environment.NewLine}";
            }
            
            return info;
        }
    }
}
