using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Gini
{
    static class GiniCalc
    {
        public static double GiniCoef(string fileName)
        {
            List<double> result = GetData(fileName);
            result.Sort(); // seřazení
            double[] lorenzoPoints = CumulativeDividers(result.ToArray());
            double plocha = LorenzArea(lorenzoPoints);
            return 0;
        }

        private static double LorenzArea(double[] lorenzoPoints)
        {
            int len = lorenzoPoints.Length;
            double plocha = 0;
            int interval = len - 1; // počet obdelniku, pro ktere počítáme obsah
            for (int i = 1; i < len; i++)
            {
                double x1 = (double)(i - 1) / interval;
                double x2 = (double)i / interval;
                plocha += (x2 - x1) * (lorenzoPoints[i - 1] + lorenzoPoints[i]);
            }
            return plocha;
        }

        private static double[] CumulativeDividers(double[] input)
        {
            int len = input.Length;
            double suma = input.Sum();
            double[] dividers = new double[len + 1];// křivka má n+1 bodů
            dividers[0] = 0.0;
            double cumulativeSum = 0;

            for (int i = 0; i < len; i++)
            {
                cumulativeSum += input[i];
                dividers[i + 1] = cumulativeSum / suma;
            }
            return dividers;

        }

        private static List<double> GetData(string fileName)
        {
            List<double> data = new List<double>();
            using (StreamReader sr = new StreamReader(fileName))
            {

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    if (line == null || line == String.Empty)
                        continue;
                    data.Add(double.Parse(line));
                }
            }
            return data;
        }
    }
}
