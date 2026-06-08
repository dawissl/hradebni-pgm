using _21_DenniAktivity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace _21_DenniAktivity
{
    public partial class Form1 : Form
    {
        private List<Activity> acitivities = new List<Activity>();
        private bool paint = false;
        private int restTime = 1440;
        public Form1()
        {
            InitializeComponent();
        }


        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint = false;
            acitivities = new List<Activity>();
            lblMost.Text = string.Empty;
            chartPanel.Invalidate();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("David Sládeèek, 2025-2026");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.BackColor = colorDialog1.Color;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chartPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // víme, že ètvereèek je velký 20x20 px
            int xField = 20;
            int yField = 20 * acitivities.Count;
            if (e.X < 0 || e.Y < 0 || e.X > xField || e.Y > yField)
            {
                // kliknuli jsme mimo oblast, kde je legenda
                return;
            }
            int activityIndex = e.Y / 20;
            Activity a = acitivities[activityIndex];
            MessageBox.Show(a.ToString());
            chartPanel.Invalidate();
        }

        private void addActitvity_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Chybí název aktivity");
                return;
            }
            if (restTime - numericUpDown1.Value < 0)
            {
                MessageBox.Show("Nedostateèná kapacita pro novou aktivitu");
                return;
            }
            restTime -= (int)numericUpDown1.Value;
            acitivities.Add(new Activity(textBox1.Text, label4.BackColor, (int)numericUpDown1.Value));
            paint = true;
            chartPanel.Invalidate();
            Activity most = acitivities.MaxBy(x => x.Time);
            if (most != null) { lblMost.Text = most.ToString(); }
        }

        private void chartPanel_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                ChartRender.DrawChart(g, chartPanel.Width, chartPanel.Height, acitivities);
                ChartRender.DrawLegend(g, acitivities);
            }
        }

        private void chartPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // víme, že ètvereèek je velký 20x20 px
            int xField = 20;
            int yField = 20 * acitivities.Count;
            if (e.X < 0 || e.Y < 0 || e.X > xField || e.Y > yField)
            {
                // kliknuli jsme mimo oblast, kde je legenda
                return;
            }
            int activityIndex = e.Y / 20;
            Activity a = acitivities[activityIndex];
            MessageBox.Show(a.ToString());
            chartPanel.Invalidate();
        }
    }
}