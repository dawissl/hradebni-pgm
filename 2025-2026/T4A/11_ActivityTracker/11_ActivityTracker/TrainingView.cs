using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ActivityTracker
{
    public class TrainingView
    {
        private Training _training;
        private Athlete _athlete;

        public TrainingView(Training training, Athlete athlete)
        {
            _training = training;
            _athlete = athlete;
        }

        public string AthleteName { get { return _athlete.Name; } }
        public string Club { get { return _athlete.Club; } }
        public string ActivityName { get { return _training.ActivityName; } }
        public DateTime Date { get { return _training.Date; } }
        public int DurationMinutes { get { return _training.DurationMinutes; } }
        public int Calories { get { return _training.Calories; } }

        public override string ToString()
        {
            return $"Jméno: {AthleteName}, Klub: {Club}, Aktivita: {ActivityName}, Datum: {Date:yyyy-MM-dd}, " +
                   $"Délka (min): {DurationMinutes}, Kalorie: {Calories}";
        }
    }

}
