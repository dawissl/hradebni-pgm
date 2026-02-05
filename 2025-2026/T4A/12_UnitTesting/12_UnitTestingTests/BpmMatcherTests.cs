using Microsoft.VisualStudio.TestTools.UnitTesting;
using _12_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_UnitTesting.Tests
{
    [TestClass()]
    public class BpmMatcherTests
    {
        private List<Vinyl> desky = new List<Vinyl>();
        private BpmMatcher m = new BpmMatcher();

        [TestInitialize()]
        public void Setup()
        {


            desky.Add(new Vinyl(1, "Daft Punk", "One Moref Time", 123, "House", "1"));
            desky.Add(new Vinyl(2, "Daft Punk", "One Morhes Time", 103, "House", "1"));
            desky.Add(new Vinyl(3, "Daft Punk", "One More Time", 163, "House", "1"));
            desky.Add(new Vinyl(4, "Daft Punk", "One More Time", 100, "House", "1"));
            desky.Add(new Vinyl(5, "Daft Punk", "One Mdore Time", 98, "House", "1"));
        }

        [TestMethod()]
        public void FindMatchingVinylsTest()
        {
            List<Vinyl> res = m.FindMatchingVinyls(desky, 105, 20);
            Assert.AreEqual(4, res.Count);

        }
    }
}