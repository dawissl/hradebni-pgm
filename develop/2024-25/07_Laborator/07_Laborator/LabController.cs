using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Laborator
{
    public static class LabController
    {
        static Random rnd = new Random();

        public static TestResult ResolveTest(TestRequest request)
        {
            return new TestResult(request.Sample,request.TestDefinition,rnd.NextDouble());
        }

    }
}
