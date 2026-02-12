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
            tanky.Add(new Tank("T-34", 2, "lehký", "èssr", 10, 22, 31));
            tanky.Add(new Tank("T-38", 10, "lehký", "èssr", 11, 12, 23));
            tanky.Add(new Tank("T-37", 3, "lehký", "èssr", 18, 29, 33));
            tanky.Add(new Tank("T-35", 3, "lehký", "èssr", 17, 52, 53));
            tanky.Add(new Tank("T-90", 8, "lehký", "èssr", 8, 32, 13));

            tanky.Sort(new TankComparatorPancir());

            string vystup = "";
            foreach (Tank t in tanky)
            {
                vystup += t.ToString() + Environment.NewLine;
            }
            LblOut.Text = vystup;

        }
    }
}
