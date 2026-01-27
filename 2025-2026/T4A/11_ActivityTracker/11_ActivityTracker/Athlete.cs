using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ActivityTracker
{
    public class Athlete
    {
        private string _name;
        private string _club;
        private List<Training> _trainings = new List<Training>();
        public string Name { get { return _name; } set { _name = value; } }
        public string Club { get { return _club; } set { _club = value; } }
        public List<Training> Trainings { get { return _trainings; } set { _trainings = value; } }


    }

}
