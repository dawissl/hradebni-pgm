using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ZamestanciSestavy
{
    class Employee
    {
        private string name;
        private string surname;
        private int workedHours;
        private bool chief;

        public int WorkedHours { get => workedHours; }
        // public int WorkedHours { get{return workedHours;} }
        // public Func<int,int,bool> Abc = (x,y) => x == y;
        public bool Chief { get => chief; }
        public string FullName { get => $"{name} {surname}"; }

        public Employee(string name, string surname, int workedHours, bool chief)
        {
            this.name = name;
            this.surname = surname;
            this.workedHours = workedHours;
            this.chief = chief;
        }

        public override string ToString()
        {
            // $ = alt + 36
            return $"{name} {surname} ({(chief ? "vedoucí" : "zaměstnanec")}) [{workedHours}h]";
        }
    }
}
