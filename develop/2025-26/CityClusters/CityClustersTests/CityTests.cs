using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityClusters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityClusters.Tests
{
    [TestClass()]
    public class CityTests
    {
        [TestMethod()]
        public void DistanceToTest()
        {

            City c1 = new City();
            c1.X = 0;
            c1.Y = 0;
            c1.Name = "mesto1";

            City c2 = new City();
            c2.X = 10;
            c2.Y = 0;
            c2.Name = "mesto2";
            double d1 = c1.DistanceTo(c2);
            double d2 = c2.DistanceTo(c1);

            Assert.AreEqual(d1, d2);
            Assert.AreEqual(d1, 10);


        }
    }
}