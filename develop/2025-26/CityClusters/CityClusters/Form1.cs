using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace CityClusters
{
    public partial class MainForm : Form
    {
        private List<City> cities = new List<City>();
        private List<Cluster> clusters = new List<Cluster>();


        private ListBox clusterList = new ListBox();
        private Panel canvas = new Panel();
        private Label stats = new Label();


        public MainForm()
        {
            Text = "Shluky mìst";
            Width = 900;
            Height = 500;


            var menu = new MenuStrip();
            var file = new ToolStripMenuItem("Menu");
            file.DropDownItems.Add("Naèíst CSV", null, LoadCsv);
            file.DropDownItems.Add("Pøidat mìsto", null, AddCity);
            file.DropDownItems.Add("Reset", null, ResetApp);
            file.DropDownItems.Add("Autor", null, (_, __) => MessageBox.Show("Autor: Student"));
            menu.Items.Add(file);


            clusterList.Width = 250;
            clusterList.Dock = DockStyle.Left;
            clusterList.SelectedIndexChanged += (_, __) => canvas.Invalidate();


            canvas.Dock = DockStyle.Fill;
            canvas.BackColor = Color.White;
            canvas.Paint += Canvas_Paint;
            canvas.MouseClick += Canvas_MouseClick;


            stats.Dock = DockStyle.Bottom;
            stats.Height = 40;


            Controls.Add(canvas);
            Controls.Add(clusterList);
            Controls.Add(stats);
            Controls.Add(menu);
            MainMenuStrip = menu;
        }


        private void AddCity(object sender, EventArgs e)
        {
            var form = new AddCityForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                cities.Add(form.CreatedCity);
                RecalculateClusters();
            }
        }


        private void LoadCsv(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;


            try
            {
                foreach (var line in File.ReadAllLines(dlg.FileName).Skip(1))
                {
                    var parts = line.Split(',');


                    cities.Add(new City
                    {
                        Name = parts[0],
                        X = int.Parse(parts[1]),
                        Y = int.Parse(parts[2]),
                        Population = int.Parse(parts[3]),
                        IsCapital = bool.Parse(parts[4]),
                        Infected = int.Parse(parts[5])
                    });
                }


                RecalculateClusters();
            }
            catch
            {
                MessageBox.Show("Chyba pøi naèítání CSV.");
            }
        }


        private void ResetApp(object sender, EventArgs e)
        {
            cities.Clear();
            clusters.Clear();
            clusterList.Items.Clear();
            canvas.Invalidate();
            stats.Text = "";
        }


        private void RecalculateClusters()
        {
            clusters.Clear();


            var capitals = cities.Where(c => c.IsCapital).ToList();
            foreach (var cap in capitals)
            {
                clusters.Add(new Cluster { Centroid = cap });
            }


            foreach (var city in cities)
            {
                var nearest = clusters
                .OrderBy(c => city.DistanceTo(c.Centroid))
                .FirstOrDefault();


                nearest?.Cities.Add(city);
            }


            clusterList.Items.Clear();
            clusterList.Items.AddRange(clusters.ToArray());


            UpdateStats();
            canvas.Invalidate();
        }


        private void UpdateStats()
        {
            if (!clusters.Any()) return;


            var max = clusters.OrderByDescending(c => c.InfectionRate).First();
            var min = clusters.OrderBy(c => c.InfectionRate).First();


            stats.Text = $"Nejvyšší: {max.Centroid.Name} ({max.InfectionRate:F2}%) | Nejnižší: {min.Centroid.Name} ({min.InfectionRate:F2}%)";
        }


        private Color GetColor(double rate)
        {
            if (rate > 90) return Color.Red;
            if (rate > 80) return Color.Orange;
            if (rate > 70) return Color.Yellow;
            return Color.LightGreen;
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cluster in clusters)
            {
                int size = Math.Min(100, cluster.TotalPopulation / 20000);
                var brush = new SolidBrush(GetColor(cluster.InfectionRate));


                var rect = new Rectangle(
                cluster.Centroid.X - size / 2,
                cluster.Centroid.Y - size / 2,
                size,
                size);


                e.Graphics.FillEllipse(brush, rect);


                if (clusterList.SelectedItem == cluster)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), rect);
                }
            }
        }


        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var cluster in clusters)
            {
                int size = Math.Max(20, cluster.TotalPopulation / 2000);
                var rect = new Rectangle(
                cluster.Centroid.X - size / 2,
                cluster.Centroid.Y - size / 2,
                size,
                size);


                if (rect.Contains(e.Location))
                {
                    clusterList.SelectedItem = cluster;
                    MessageBox.Show(string.Join("\n",
                    cluster.Cities.Select(c => $"{c.Name} - {c.Population}")) +
                    $"\n\nNakažení: {cluster.InfectionRate:F2}%");
                    break;
                }
            }
        }
    }
}