using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Laborator
{
    public class TestRequest
    {
        private Sample sample;
        private TestDefinition testDefinition;
        private int time;
        private double threashold;

        public Sample Sample { get { return sample; } }
        public TestDefinition TestDefinition { get { return testDefinition; } }
        public TestRequest(Sample s,TestDefinition t)
        {
            this.sample = s;
            this.testDefinition = t;
            this.time = t.TimeOfTest;
            this.threashold = t.Threshold;
        }

        public override string ToString() {
            return $"{testDefinition.TestName} na vzorek {sample.Name} [{time} ms]";
        }
    }
}
