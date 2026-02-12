namespace _16_GarazTanky
{
    public partial class Form1 : Form
    {
       private Hangar hangar = new Hangar();    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hangar.PridejTank(new Tank("T-34", 2, "lehký", "èssr", 10, 22, 31));
            hangar.PridejTank(new Tank("T-38", 10, "lehký", "èssr", 11, 12, 23));
            hangar.PridejTank(new Tank("T-37", 3, "lehký", "èssr", 18, 29, 33));
            hangar.PridejTank(new Tank("T-35", 3, "lehký", "èssr", 17, 52, 53));
            hangar.PridejTank(new Tank("T-90", 8, "lehký", "èssr", 8, 32, 13));

           
            LblOut.Text = hangar.ToString();
            label1.Text = hangar.NejsilnejsiPancirVHangaru().ToString();

        }
    }
}
