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
            City a = new City("A", new Point(130, 300), 31, 500, false);
            City b = new City("B", new Point(300, 50), 310, 5000, true);
            City c = new City("C", new Point(100, 60), 2305, 30000, true);
            City d = new City("D", new Point(280, 400), 678, 1200, false);
            City e = new City("E", new Point(10, 10), 10, 13080, true);
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
           // TODO
        }

        private void PanelCity_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // TODO
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
