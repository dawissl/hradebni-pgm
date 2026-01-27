using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ActivityTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StatsHelper
    {
        /// <summary>
        /// Vrátí top N atletů pro zvolenou aktivitu podle celkového času.
        /// </summary>
        public static List<AthleteSummary> TopAthletesByActivity(List<Athlete> athletes, string activityName, int top = 5)
        {
            List<AthleteSummary> result = new List<AthleteSummary>();

            foreach (Athlete athlete in athletes)
            {
                int totalTime = 0;
                int totalCalories = 0;

                foreach (Training training in athlete.Trainings)
                {
                    if (training.ActivityName == activityName)
                    {
                        totalTime += training.DurationMinutes;
                        totalCalories += training.Calories;
                    }
                }

                if (totalTime > 0)
                {
                    AthleteSummary summary = new AthleteSummary();
                    summary.Name = athlete.Name;
                    summary.Club = athlete.Club;
                    summary.TotalDuration = totalTime;
                    summary.TotalCalories = totalCalories;
                    result.Add(summary);
                }
            }

            // Seřadit sestupně podle celkového času
            result.Sort(delegate (AthleteSummary a, AthleteSummary b)
            {
                return b.TotalDuration.CompareTo(a.TotalDuration);
            });

            // Vrátit pouze top N
            if (result.Count > top)
            {
                return result.GetRange(0, top);
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Vrátí nejaktivnějšího atleta pro konkrétní den.
        /// </summary>
        public static AthleteSummary TopAthleteByDay(List<Athlete> athletes, DateTime day)
        {
            AthleteSummary top = null;
            int maxTime = 0;

            foreach (Athlete athlete in athletes)
            {
                int dayTime = 0;

                foreach (Training training in athlete.Trainings)
                {
                    if (training.Date.Date == day.Date)
                    {
                        dayTime += training.DurationMinutes;
                    }
                }

                if (dayTime > maxTime)
                {
                    maxTime = dayTime;
                    top = new AthleteSummary();
                    top.Name = athlete.Name;
                    top.Club = athlete.Club;
                    top.TotalDuration = dayTime;
                }
            }

            return top;
        }

        /// <summary>
        /// Vrátí seznam všech unikátních aktivit z kolekce atletů.
        /// </summary>
        public static List<string> GetAllActivities(List<Athlete> athletes)
        {
            List<string> activities = new List<string>();

            foreach (Athlete athlete in athletes)
            {
                foreach (Training training in athlete.Trainings)
                {
                    if (!activities.Contains(training.ActivityName))
                    {
                        activities.Add(training.ActivityName);
                    }
                }
            }

            return activities;
        }
    }

}
