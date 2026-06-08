using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Tests
{
    [TestClass]
    public class SimpleCalcTests
    {
        [TestMethod]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            

            // Act
            int result = SimpleCalc.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            int result = SimpleCalc.Add(-5, 3);
            Assert.AreEqual(-2, result);
        }
    }
}