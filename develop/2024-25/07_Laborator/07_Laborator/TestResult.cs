using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Laborator
{
    public class TestResult
    {
        private Sample sample;
        private TestDefinition testDefinition;
        private bool result;
        public TestResult(Sample s, TestDefinition t, double res)
        {
            sample = s;
            testDefinition = t;
            result = t.Threshold <= res;
        }

        public override string ToString() {

            return $"{testDefinition.TestName} na vzorku {sample.Name}: {(result?"pozitivní":"negativní")}";
        }
    }
}
