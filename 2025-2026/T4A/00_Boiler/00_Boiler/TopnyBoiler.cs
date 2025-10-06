using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Boiler
{
    class TopnyBoiler
    {
        private int volume;
        private double temperature = 15;
        private int power;
        private bool isOn = false;
        private bool drain = false;

        private  const double MTK = 4186.0;
        private const double COLD_WATER = 15.0;
        private const double K_VALUE = 0.01;
        private const double DRAIN_VOLUME = 5.0;

        public double Temperature { get { return temperature; } }
        public bool IsOn { get { return isOn; } set { isOn = value; } }
        public bool Drain {  get { return drain; } set { drain = value; } }
        public TopnyBoiler(int p, int v)
        {
            volume = v;
            power = p;
        }

        public void HeatWater()
        {
            temperature += (power*1000) / (volume* MTK);
        }

        public void CoolWater()
        {
            temperature -= -K_VALUE * (temperature - 20);
        }

        public void DrainWater(double time)
        {
            double drainedWater = time * DRAIN_VOLUME;
            double remaimWater = volume - drainedWater;
            temperature = (temperature * remaimWater + COLD_WATER * drainedWater)
                / (drainedWater + remaimWater);
        }

        public override string ToString()
        {
            return $"{temperature}";
        }

    }
}
