namespace _19_DenniAktivity
{
    public partial class Form1 : Form
    {
        private List<Aktivita> aktivity = new List<Aktivita>();
        public Form1()
        {
            InitializeComponent();
            aktivity.Add(new Aktivita("X", Color.Red, 60));
            aktivity.Add(new Aktivita("y", Color.Blue, 160));
            aktivity.Add(new Aktivita("z", Color.Green, 260));
            aktivity.Add(new Aktivita("w", Color.Yellow, 400));
        }

        private void panelPie_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Vykreslovani.VytvorGraf(g, panelPie.Width, panelPie.Height, aktivity);
            Vykreslovani.VytvorLegendu(g, aktivity);
        }

    }
}
