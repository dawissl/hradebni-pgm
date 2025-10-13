namespace _03_ZamestanciSestavy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGenerateRandom_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string[] names = { "Kamil", "Petr", "Mirka", "Lucie", "Klara", "Štefan" };
            string[] surnames = { "Vomáèka", "Nový", "Svoboda", "Rychtáø", "Kalich" };

            for (int i = 0; i < 50; i++)
            {
                int hours = rnd.Next(100, 151);
                bool chief = rnd.Next(100) <= 20;
                string n = names[rnd.Next(names.Length)];
                string s = surnames[rnd.Next(surnames.Length)];
                ListEmployees.Items.Add(new Employee(n, s, hours, chief));
            }
        }

        private void BtnHours_Click(object sender, EventArgs e)
        {
            List<Employee> empl = ListEmployees.Items
                .Cast<Employee>()
                .OrderByDescending(x => x.WorkedHours)
                .Take(10)
                .ToList();

            LblOutput.Text = string.Join(Environment.NewLine, empl);
        }

        private void BtnChiefs_Click(object sender, EventArgs e)
        {
            List<string> empl = ListEmployees.Items
                .Cast<Employee>()
                .Where(x => x.Chief)
                .Select(x => $"{x.FullName}")
                .ToList();

            LblOutput.Text = string.Join(Environment.NewLine, empl);

        }

        private void BtnOverAverage_Click(object sender, EventArgs e)
        {
            double averageWorker = 0;
            foreach (Employee emp in ListEmployees.Items)
            {
                averageWorker += emp.WorkedHours;
            }
            averageWorker /= ListEmployees.Items.Count;

            List<Employee> empl = ListEmployees.Items
                .Cast<Employee>()
                .Where(x => x.WorkedHours > averageWorker)
                .ToList();

            LblOutput.Text = string.Join(Environment.NewLine, empl);

        }
    }
}
