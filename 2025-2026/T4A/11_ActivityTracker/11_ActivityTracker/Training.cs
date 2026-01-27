using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ActivityTracker
{
    public class Training
    {
        private string _activityName;
        private DateTime _date;
        private int _durationMinutes;
        private int _calories;
        public string ActivityName { get { return _activityName; } set { _activityName = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public int DurationMinutes { get { return _durationMinutes; } set { _durationMinutes = value; } }
        public int Calories { get { return _calories; } set { _calories = value; } }

        public override string ToString()
        {
            return $"Aktivita: {ActivityName}, Datum: {Date:yyyy-MM-dd}, Délka (min): {DurationMinutes}, Kalorie: {Calories}";
        }
    }

}
