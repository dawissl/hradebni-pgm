using System.Drawing.Drawing2D;
using System.IO;
using System.Xml.Linq;

namespace StudentskySenat
{
    public partial class MainForm : Form
    {
        private double kompletniHlasy; // Celkový poèet hlasù
        private List<Spolek> spolky = new List<Spolek>(); // Seznam spolkù
        private bool draw = false; // Urèuje, zda má být graf vykreslen

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pøidá ruènì zadaný spolek a jeho hlasy do seznamu.
        /// Pokud již existuje, pøiète mu hlasy.
        /// </summary>
        private void BtnManualAdd_Click(object sender, EventArgs e)
        {
            string name = TxtSpolek.Text.ToUpper();
            int hlasy = int.Parse(TxtHlasy.Text);
            Spolek? s = NajdiSpolek(name);
            if (s == null)
                spolky.Add(new Spolek(name, hlasy));
            else
                s.Vote += hlasy;
            kompletniHlasy += hlasy;
            UpdateVotes();
            CreateCoalition();
            panelChart.Refresh();
        }

        /// <summary>
        /// Vytvoøí koalici spolkù na základì poètu získaných køesel.
        /// </summary>
        private void CreateCoalition()
        {
            int majority = 0;
            string koalice = "Navržená koalice: ";
            for (int i = 0; i < spolky.Count; i++)
            {
                if (majority > 15) break;
                majority += spolky[i].Seats;
                koalice += $"{spolky[i].Name} [{spolky[i].Seats}], ";
            }
            koalice += $" má v držení {majority} køesel.";
            lblCoalition.Text = koalice;
        }

        /// <summary>
        /// Aktualizuje výsledky voleb - validuje spolky, pøidìluje køesla a zobrazuje výsledky.
        /// </summary>
        private void UpdateVotes()
        {
            foreach (Spolek p in spolky)
            {
                p.Seats = 0;
                p.Valid = p.Vote / kompletniHlasy >= 0.05; // 5% práh
                p.Percents = p.Vote / kompletniHlasy;
            }
            spolky.Sort();

            // Vytvoøení seznamu dìlitelù pro výpoèet køesel
            List<Delitel> dividers = new List<Delitel>();
            foreach (Spolek p in spolky)
            {
                if (p.Valid)
                {
                    for (double i = 1; i <= 30; i++)
                    {
                        dividers.Add(new Delitel(p.Name, p.Vote / i));
                    }
                }
            }
            dividers.Sort();

            // Pøidìlení prvních 30 køesel podle nejvyšších hodnot
            for (int i = 0; i < 30; i++)
            {
                NajdiSpolek(dividers[i].Name)!.Seats++;
            }

            // Výpis výsledkù
            lblResults.Text = string.Join(Environment.NewLine, spolky);
            draw = true;
            panelChart.Refresh();
        }

        /// <summary>
        /// Vyhledá spolek podle názvu.
        /// </summary>
        private Spolek? NajdiSpolek(string name)
        {
            return spolky.FirstOrDefault(sp => sp.Name == name);
        }

        /// <summary>
        /// Resetuje všechny hodnoty a vymaže výsledky.
        /// </summary>
        private void menuReset_Click(object sender, EventArgs e)
        {
            kompletniHlasy = 0;
            spolky.Clear();
            lblResults.Text = "Výsledky voleb budou zde.";
            lblCoalition.Text = "Navržená koalice bude zobrazena zde.";
            TxtHlasy.Text = "";
            TxtSpolek.Text = "";
            draw = false;
            panelChart.Refresh();
        }

        /// <summary>
        /// Vykreslí grafické znázornìní výsledkù voleb.
        /// </summary>
        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!draw)
            {
                panelChart.BackColor = Color.White;
                return;
            }

            Color[] barvy = { Color.Blue, Color.Green, Color.Red, Color.Pink, Color.Yellow, Color.DarkGray, Color.DarkCyan, Color.LightBlue };
            double maxheight = panelChart.Height - 20;
            int width = 20;
            for (int i = 0; i < spolky.Count; i++)
            {

                int y = (int)(maxheight * spolky[i].Percents);
                if (y < maxheight * 0.75) y = (int)(y * 3);
                g.DrawString(spolky[i].Name, new Font("Arial", 12), new SolidBrush(barvy[i % barvy.Length]), new Point(30 * i, panelChart.Height - y - 20));
                g.FillRectangle(new SolidBrush(barvy[i % barvy.Length]), 30 * i, panelChart.Height - y, width, y);
            }
        }

        private void menuLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] parts = sr.ReadLine().Split(";");
                        Spolek? s = NajdiSpolek(parts[0]);
                        if (s == null)
                            spolky.Add(new Spolek(parts[0], int.Parse(parts[1])));
                        else
                            s.Vote += int.Parse(parts[1]);
                        kompletniHlasy += int.Parse(parts[1]);
                    }

                    sr.Close();
                }
                UpdateVotes();
                CreateCoalition();
                panelChart.Refresh();
            }
        }
    }
}
