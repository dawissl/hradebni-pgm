using Microsoft.VisualStudio.TestTools.UnitTesting;
using _12_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _12_UnitTesting.Tests
{
    [TestClass()]
    public class SimpleCalcTests
    {
        private SimpleCalc calc;
        [TestInitialize()]
        public void Setup()
        {
            calc = new SimpleCalc();

        }

        [TestMethod()]
        public void AddTest()
        {
            int result = calc.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void AddTest_1()
        {
            int result = calc.Add(-5, -3);
            Assert.IsTrue(result < 0);
            Assert.AreEqual(-8, result);
        }

        [TestMethod()]
        public void SubTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MulTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DivTest()
        {
            Assert.Fail();
        }
    }
}