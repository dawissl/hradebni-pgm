namespace _05_Grafika
{
    public partial class Form1 : Form
    {
        private Rectangle[] superobdelnik;
        private bool kresli = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void PanelDraw_Paint(object sender, PaintEventArgs e)
        {
            // získání grafiky dané komponenty
            Graphics g = e.Graphics;
            //if (!kresli) return; // využití pomocné promìnné, která zemezí kreslení

            Rectangle r = new Rectangle(20, 20, 50, 50);
            g.FillRectangle(Brushes.DeepPink, r);

            Pen p = new Pen(Brushes.DarkGreen, 3);
            g.DrawEllipse(p, 20, 70, 30, 10);

            Rectangle[] obdelniky = new Rectangle[5];

            Random random = new Random();
            for (int i = 0; i < obdelniky.Length; i++)
            {
                obdelniky[i] = new Rectangle(10 + 20 * i, 60, 18, random.Next(50, 101));
                g.FillRectangle(Brushes.Red,
                    obdelniky[i].X,
                    //kvùji obrácené projekci je tøeba pøepoèet 0,0 je horní levý roh
                    PanelDraw.Height - obdelniky[i].Height - 15,
                    obdelniky[i].Width,
                    obdelniky[i].Height);
            }
            // využití informace o nedefinovanosti pole, abychom zabranili padu aplikace
            if (superobdelnik == null) return;
            for (int i = 0; i < superobdelnik.Length; i++)
            {
                g.FillRectangle(Brushes.Blue, superobdelnik[i]);
            }
        }

        private void BtnDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(20, 20, 50, 50);
            g.FillRectangle(Brushes.DeepPink, r);

            Pen p = new Pen(Brushes.DarkGreen, 3);
            g.DrawEllipse(p, 20, 70, 30, 10);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(20, 20, 50, 50);
            g.FillRectangle(Brushes.DeepPink, r);

            Pen p = new Pen(Brushes.DarkGreen, 3);
            g.DrawEllipse(p, 20, 70, 30, 10);
        }

        private void LblDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(20, 20, 50, 50);
            g.FillRectangle(Brushes.DeepPink, r);

            Pen p = new Pen(Brushes.DarkGreen, 3);
            g.DrawEllipse(p, 20, 70, 30, 10);
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            superobdelnik = new Rectangle[1];
            superobdelnik[0] = new Rectangle(10, 10, 200, 400);
            // vynucení pøekreslení dané komponenty
            PanelDraw.Refresh();
        }
    }
}
