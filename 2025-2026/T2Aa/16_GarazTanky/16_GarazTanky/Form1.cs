namespace _16_GarazTanky
{
    public partial class Form1 : Form
    {
        private List<Tank> tanky = new List<Tank>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tanky.Add(new Tank("Tiger", 8, "Nìmecko", "tìžký", 100, 30, 46));
            tanky.Add(new Tank("T-34", 6, "SSSR", "støední", 90, 33, 32));
            tanky.Add(new Tank("M1-Abrams", 10, "USA", "støední", 130, 29, 46));
            tanky.Add(new Tank("KWG-9", 8, "Nìmecko", "tìžký", 100, 30, 46));
            tanky.Add(new Tank("T-72", 9, "SSR", "tìžký", 180, 30, 46));

            tanky.Sort(new TankComparerPancir());

            string vystup = "";
            foreach (Tank tank in tanky)
                vystup += tank.ToString() + Environment.NewLine;

            LblOut.Text = vystup;
        }
    }
}
