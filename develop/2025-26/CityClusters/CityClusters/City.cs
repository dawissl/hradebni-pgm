using System;


namespace CityClusters
{
    public class City
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Population { get; set; }
        public bool IsCapital { get; set; }
        public int Infected { get; set; }


        public double DistanceTo(City other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }
    }
}