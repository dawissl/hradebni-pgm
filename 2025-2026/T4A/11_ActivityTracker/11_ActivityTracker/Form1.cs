namespace _11_ActivityTracker
{
    public partial class Form1 : Form
    {
        private List<Athlete> _athletes = new List<Athlete>();
        private List<TrainingView> _trainingViews = new List<TrainingView>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Vyber CSV soubor";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _athletes.Clear();
                _trainingViews.Clear();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName))
                {
                    // Pøeèteme hlavièku a pøeskoèíme ji
                    string headerLine = sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = line.Split(',');
                        if (parts.Length != 6)
                            continue;

                        string athleteName = parts[0];
                        string club = parts[1];
                        string activityName = parts[2];
                        DateTime date = DateTime.Parse(parts[3]);
                        int durationMinutes = Int32.Parse(parts[4]);
                        int calories = Int32.Parse(parts[5]);

                        // Hledáme existujícího atleta
                        Athlete athlete = null;
                        foreach (Athlete a in _athletes)
                        {
                            if (a.Name == athleteName && a.Club == club)
                            {
                                athlete = a;
                                break;
                            }
                        }

                        if (athlete == null)
                        {
                            athlete = new Athlete();
                            athlete.Name = athleteName;
                            athlete.Club = club;
                            _athletes.Add(athlete);
                        }

                        // Vytvoøení tréninku
                        Training training = new Training();
                        training.ActivityName = activityName;
                        training.Date = date;
                        training.DurationMinutes = durationMinutes;
                        training.Calories = calories;

                        athlete.Trainings.Add(training);

                        // Vytvoøení TrainingView
                        TrainingView trainingView = new TrainingView(training, athlete);
                        _trainingViews.Add(trainingView);
                    }
                }
            }
            // Naplníme ComboBox a DataGridView
            PopulateActivities();
            PopulateDataGridView();
            UpdateTopAthletes();

        }

        // Naplnìní ComboBoxu unikátními aktivitami
        private void PopulateActivities()
        {
            List<string> activities = StatsHelper.GetAllActivities(_athletes);
            cmbActivities.Items.Clear();

            foreach (string activity in activities)
            {
                cmbActivities.Items.Add(activity);
            }

            if (cmbActivities.Items.Count > 0)
                cmbActivities.SelectedIndex = 0;
        }

        // Naplnìní DataGridView podle vybrané aktivity
        private void PopulateDataGridView()
        {
            string selectedActivity = "";

            if (cmbActivities.SelectedItem != null)
                selectedActivity = cmbActivities.SelectedItem.ToString();

            List<TrainingView> filtered = new List<TrainingView>();

            foreach (TrainingView tv in _trainingViews)
            {
                if (tv.ActivityName == selectedActivity)
                {
                    filtered.Add(tv);
                }
            }

            dgvTrainings.DataSource = null;
            dgvTrainings.DataSource = filtered;
        }

        // Aktualizace top 5 atletù pro vybranou aktivitu
        private void UpdateTopAthletes()
        {
            string selectedActivity = "";

            if (cmbActivities.SelectedItem != null)
                selectedActivity = cmbActivities.SelectedItem.ToString();

            List<AthleteSummary> topAthletes = StatsHelper.TopAthletesByActivity(_athletes, selectedActivity, 5);

            lstTopAthletes.Items.Clear();
            foreach (AthleteSummary summary in topAthletes)
            {
                lstTopAthletes.Items.Add($"{summary.Name} ({summary.Club}) - {summary.TotalDuration} min");
            }

            UpdateTopAthleteDay();
        }


        private void cmbActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDataGridView();
            UpdateTopAthletes();
        }

        // Aktualizace nejaktivnìjšího atleta konkrétního dne
        private void UpdateTopAthleteDay()
        {
            DateTime selectedDay = dtpSpecificDay.Value.Date;
            AthleteSummary topDay = StatsHelper.TopAthleteByDay(_athletes, selectedDay);

            if (topDay != null)
                txtTopAthleteDay.Text = $"{topDay.Name} ({topDay.Club}) - {topDay.TotalDuration} min";
            else
                txtTopAthleteDay.Text = "Žádná aktivita";
        }

        private void dtpSpecificDay_ValueChanged(object sender, EventArgs e)
        {
            UpdateTopAthleteDay();
        }
    }
}
