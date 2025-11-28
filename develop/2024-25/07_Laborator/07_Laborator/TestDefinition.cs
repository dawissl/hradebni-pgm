using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Laborator
{
    public class TestDefinition
    {
        private string testName;
        private string sampleType;
        private int timeOfTest;
        private double threshold;

        public double Threshold {  get { return threshold; }}
        public string TestName { get { return testName; }}
        public string SampleType { get { return sampleType; }}
        public int TimeOfTest { get { return timeOfTest; }}

        public TestDefinition(string name, string type, int time, double threashold)
        {
            this.testName = name.ToUpper();
            this.sampleType = type.ToUpper();
            this.timeOfTest = time;
            this.threshold = threashold;
        }

        public override string ToString()
        {
            return $"{testName} [{timeOfTest} ms]";
        }

    }
}
