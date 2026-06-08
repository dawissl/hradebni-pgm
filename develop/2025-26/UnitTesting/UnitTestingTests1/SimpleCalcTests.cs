using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Tests
{
    [TestClass()]
    public class SimpleCalcTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void SanityCheck()
        {
            Assert.IsTrue(true);
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