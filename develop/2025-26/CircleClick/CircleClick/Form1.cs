namespace CircleClick
{
    public partial class Form1 : Form
    {
        private Circle[] circles;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void PanelCircle_Paint(object sender, PaintEventArgs e)
        {
            if (circles == null) return;
            Graphics g = e.Graphics;
            foreach (Circle circle in circles)
            {
                SolidBrush s = new SolidBrush(circle.Color);
                g.FillEllipse(s, circle.GetArea());
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            circles = new Circle[10];
            for (int i = 0; i < circles.Length; i++)
            {
                Color c = Color.FromArgb(150,rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
                Point p = new Point(rnd.Next(0, PanelCircle.Width), rnd.Next(0, PanelCircle.Height));
                int value = rnd.Next(500, 1000001);
                circles[i] = new Circle(p, c, value);
            }
            PanelCircle.Refresh();
        }

        private void PanelCircle_MouseDown(object sender, MouseEventArgs e)
        {
            if (circles == null) return;
            Circle clicked = null;
            int index = 0;
            for (; index < circles.Length; index++)
            {
                if (circles[index].IsInCircle(new Point(e.X, e.Y)))
                {
                    clicked = circles[index];
                    break;
                }
            }
            if (clicked != null)
            {
                LblInfo.Text = clicked.ToString();
                LblInfo.BackColor = clicked.Color;
                circles[index].Color = Color.Black;
                PanelCircle.Refresh();
            }
            else
            {
                LblInfo.Text = "mimo";
            }
        }
    }
}