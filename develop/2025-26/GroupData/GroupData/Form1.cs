namespace GroupData
{
    public partial class Form1 : Form
    {
        private List<Group> groups = new List<Group>();
        public Form1()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            City a = new City("A", new Point(50, 50), 31, 500, false);
            City b = new City("B", new Point(300, 50), 310, 5000, true);
            City c = new City("C", new Point(100, 60), 2305, 30000, true);
            City d = new City("D", new Point(280, 400), 678, 1200, false);
            City e = new City("E", new Point(0, 0), 10, 13080, true);
            ListCity.Items.Add(a);
            ListCity.Items.Add(b);
            ListCity.Items.Add(c);
            ListCity.Items.Add(d);
            ListCity.Items.Add(e);
            GroupCity();
            foreach(Group g in groups)
            {
                ListGroup.Items.Add(g);
            }
            PanelCity.Refresh();
        }

        private void GroupCity()
        {
            // vytvoøení skupin, centroidy oblastí jsou pouze krajská mìsta
            foreach (City c in ListCity.Items)
            {
                if (c.IsCounty) groups.Add(new Group(c));
            }
            foreach (City c in ListCity.Items)
            {
                if (c.IsCounty) continue; // pokud je krajské, již existuje v nìjaké skupinì
                double dist = groups[0].GetDistance(c.Center); // vezememe vzdálenost od prvního centroidu ve skupinách
                int groupIndex = 0;
                for (int i = 0; i < groups.Count; i++)
                {
                    double d = groups[i].GetDistance(c.Center);
                    if (d < dist)
                    {
                        groupIndex = i;
                        dist = d;
                    }
                }
                groups[groupIndex].AddCity(c);
            }
        }

        private void PanelCity_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Group gr in groups) { 
                SolidBrush sb = new SolidBrush(gr.Color);
                g.FillEllipse(sb,gr.GetArea());
                g.DrawString(gr.Info(), new Font("Arial", 14), Brushes.Black, gr.Centroid);
            }
            foreach (City c in ListCity.Items) {
                g.FillEllipse(Brushes.Blue, c.GetCityArea());
                g.DrawString(c.Name, new Font("Arial", 14), Brushes.Black, c.Center);

            }
        }

        private void PanelCity_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ListGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblDetail.Text = groups[ListGroup.SelectedIndex].Info();
        }
    }
}
