using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ActivityTracker
{
    /// <summary>
    /// View třída, která je využita pro zobrazování agregovaných dat
    /// </summary>
    public class AthleteSummary
    {
        private string _name;
        private string _club;
        private int _totalDuration;
        private int _totalCalories;
        public string Name { get { return _name; } set { _name = value; } }
        public string Club { get { return _club; } set { _club = value; } }
        public int TotalDuration { get { return _totalDuration; } set { _totalDuration = value; } }
        public int TotalCalories { get { return _totalCalories; } set { _totalCalories = value; } }
    }

}
