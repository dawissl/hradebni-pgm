namespace _05_Grafika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PanelDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(10, 5, 30, 30);
            g.FillRectangle(Brushes.HotPink, r);
            Pen p = new Pen(Brushes.Green, 3);
            g.DrawEllipse(p, 50, 5, 50, 20);

            Rectangle[] obdelniky = new Rectangle[10];
            Random random = new Random();
            for (int i = 0; i < obdelniky.Length; i++)
            {
                obdelniky[i] = new Rectangle(10 + 25 * i,
                    60, 20,
                    random.Next(30, 101));
                g.FillRectangle(Brushes.Navy,
                    obdelniky[i].X,
                    PanelDraw.Height - obdelniky[i].Height - 15,
                    obdelniky[i].Width,
                    obdelniky[i].Height);
            }

        }

        private void BtnDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(10, 5, 30, 30);
            g.FillRectangle(Brushes.HotPink, r);
            Pen p = new Pen(Brushes.Green, 3);
            g.DrawEllipse(p, 50, 5, 50, 20);
        }


        private void LblDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(10, 5, 30, 30);
            g.FillRectangle(Brushes.HotPink, r);
            Pen p = new Pen(Brushes.Green, 3);
            g.DrawEllipse(p, 50, 5, 50, 20);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(10, 5, 30, 30);
            g.FillRectangle(Brushes.HotPink, r);
            Pen p = new Pen(Brushes.Green, 3);
            g.DrawEllipse(p, 50, 5, 50, 20);
        }
    }
}
