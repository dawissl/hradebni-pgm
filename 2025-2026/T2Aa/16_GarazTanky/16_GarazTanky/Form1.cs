namespace _16_GarazTanky
{
    public partial class Form1 : Form
    {
        private Garaz garaz = new Garaz();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            garaz.PridejTank(new Tank("Tiger", 8, "Nìmecko", "tìžký", 100, 30, 46));
            garaz.PridejTank(new Tank("T-34", 6, "SSSR", "støední", 90, 33, 32));
            garaz.PridejTank(new Tank("M1-Abrams", 10, "USA", "støední", 130, 29, 46));
            garaz.PridejTank(new Tank("KWG-9", 8, "Nìmecko", "tìžký", 100, 30, 46));
            garaz.PridejTank(new Tank("T-72", 9, "SSR", "tìžký", 180, 30, 46));

            LblPancir.Text = garaz.NejsilnejsiPancirGaraze().ToString();
            LblOut.Text = garaz.ToString();
        }
    }
}
