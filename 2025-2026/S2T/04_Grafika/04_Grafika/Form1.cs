namespace _04_Grafika
{
    public partial class Form1 : Form
    {
        bool drawInPanel = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void PanelDraw_Paint(object sender, PaintEventArgs e)
        {
            // ziskani grafiky komponenty
            Graphics g = e.Graphics;
            // zadefinovaní vlastního štìtce pro výplnì
            SolidBrush sb = new SolidBrush(Color.Violet);

            // struct Rectagnle, definujici oblast pro vykreslování
            Rectangle[] obdelniky = new Rectangle[10];
            Random r = new Random();
            for (int i = 0; i < obdelniky.Length; i++)
            {
                obdelniky[i] = new Rectangle(10 + i * 30, 50, 20, r.Next(50, 201));
                // odeètení velikosto obdelniku od velikosti panelu
                // zajisti, že se vykreslují pro nás chápatelném
                // smìru, kde 0,0 je v levem dolnim rohu
                g.DrawRectangle(Pens.Blue,
                    obdelniky[i].X,
                    PanelDraw.Height - obdelniky[i].Height - 50,
                    obdelniky[i].Width,
                    obdelniky[i].Height);
            }

            // lze aplikovat poznatky z døívìjška
            for (int i = 0; i < 10; i++)
            {
                g.FillRectangle(sb, 10 + i * 30, 10, 20, 20);
            }

            // definice vlastního pera s danou šíøkou, výchozí hodnota je 1
            Pen p = new Pen(Brushes.HotPink, 3);
            g.DrawRectangle(p, 10, 10, 80, 80);

            // vykreslení pokud platí daná podmínka
            if (drawInPanel)
            {
                g.FillEllipse(Brushes.Yellow, 120, 50, 60, 80);
            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.Green, 10, 10, 80, 80);

            Pen p = new Pen(Brushes.HotPink, 3);
            g.DrawRectangle(p, 10, 10, 80, 80);


        }

        private void BtnDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.Green, 10, 10, 80, 80);

            Pen p = new Pen(Brushes.HotPink, 3);
            g.DrawRectangle(p, 10, 10, 80, 80);
        }

        private void LblInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.Green, 10, 10, 80, 80);

            Pen p = new Pen(Brushes.HotPink, 3);
            g.DrawRectangle(p, 10, 10, 80, 80);
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            drawInPanel = !drawInPanel;
            // vynucení pøekreslení komponenty panel
            PanelDraw.Refresh();
        }
    }
}
