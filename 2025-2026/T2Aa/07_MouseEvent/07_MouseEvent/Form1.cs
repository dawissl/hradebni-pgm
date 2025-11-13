namespace _07_MouseEvent
{
    public partial class Form1 : Form
    {
        private List<Point> body = new List<Point>();
        private bool polygon = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void PanelPolygon_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (body.Count < 2)
            {
                PanelPolygon.BackColor = Color.White;
                return;
            }
            if (!polygon)
            {
                g.DrawLines(Pens.Red, body.ToArray());
                foreach (Point p in body)
                    g.FillRectangle(Brushes.HotPink, p.X - 2, p.Y - 2, 4, 4);
            }
            if (body.Count >= 3 && polygon)
            { // nejmenší polygon je trojúhelník
                SolidBrush stetec = new SolidBrush(Color.HotPink);

                g.FillPolygon(stetec, body.ToArray());

            }

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            body = new List<Point>();
            PanelPolygon.Refresh();
            polygon = false;
        }

        private void PanelPolygon_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            body.Add(p);
            PanelPolygon.Refresh();

        }

        private void PanelPolygon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            body.Add(p);
            polygon = true;
            PanelPolygon.Refresh();
        }
    }
}