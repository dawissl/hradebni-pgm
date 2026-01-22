using System.CodeDom.Compiler;

namespace Dividers200
{
    public partial class Form1 : Form
    {
        private List<Group> groups = new List<Group>();
        public Form1()
        {
            InitializeComponent();

            Generate();
        }
        private void Generate()
        {
            groups = new List<Group>();
            Group g1 = new Group("ODS", Color.Blue);
            Group g2 = new Group("TOP09", Color.Purple);
            Group g3 = new Group("PIR", Color.Black);
            Group g4 = new Group("STAN", Color.Pink);
            Group g5 = new Group("KDU", Color.Yellow);
            Group g6 = new Group("KSÈ", Color.Red);
            Group g7 = new Group("VV", Color.Green);
            Random rnd = new Random();
            g1.Count = rnd.Next(70000, 100000);
            g2.Count = rnd.Next(500, 50000);
            g3.Count = rnd.Next(500, 40000);
            g4.Count = rnd.Next(500, 30000);
            g5.Count = rnd.Next(500, 20000);
            g6.Count = rnd.Next(500, 10000);
            g7.Count = rnd.Next(500, 1000);
            groups.Add(g1);
            groups.Add(g2);
            groups.Add(g3);
            groups.Add(g4);
            groups.Add(g5);
            groups.Add(g6);
            groups.Add(g7);
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            string seznam = "";
            double sum = 0;
            foreach (Group g in groups)
            {
                seznam += $"{g}{Environment.NewLine}{Environment.NewLine}";
                sum += g.Count;
            }
            LblDefault.Text = seznam;
            seznam = "";
            groups.Sort();
            foreach (Group g in groups)
            {
                if (g.Count / sum >= 0.05) g.Valid = true;
                seznam += $"{g}{Environment.NewLine}{Environment.NewLine}";

            }
            LblSort.Text = seznam;
            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i < groups.Count; i++)
            {
                SolidBrush b = new SolidBrush(groups[i].Badge);
                graphics.FillRectangle(b, 20 + i * 30, 350, 25 , 25 + groups[i].Count/10000);
            }
        }

        private void BtnGroup_Click(object sender, EventArgs e)
        {
            foreach (Group g in groups)
            {
                if (g.Valid)
                {
                    for (double i = 1; i <= 200; i++)
                    {
                        dividers.Add(new Divider(g.Name, g.Count / i));
                    }
                }
            }
            dividers.Sort();
            for (int i = 0; i < 200; i++)
            {
                foreach (Group g in groups)
                {
                    if (g.Name == dividers[i].Name)
                    {
                        g.Leaders++;
                        break;
                    }
                }
            }

            string text = "";
            foreach (Group g in groups)
            {
                if (g.Valid)
                {
                    text += $"{g}{Environment.NewLine}";
                }
            }
            LblGroups.Text = text;

        }
        private List<Divider> dividers = new List<Divider>();
        class Divider : IComparable<Divider>
        {
            private string name;
            private double div;
            public string Name { get { return name; } }
            public double Div { get { return div; } }

            public Divider(string name, double div)
            {
                this.name = name;
                this.div = div;
            }

            public int CompareTo(Divider? other)
            {
                return other.Div.CompareTo(div);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }
    }
}
