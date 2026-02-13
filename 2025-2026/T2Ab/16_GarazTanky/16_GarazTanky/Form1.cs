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
            Tank t = hangar.NejsilnejsiPancirVHangaru();
            string pancir = "";
            if (t != null)
                pancir = t.ToString() + Environment.NewLine;
            LblPrehled.Text = hangar.ToString() 
                + Environment.NewLine 
                + pancir;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tank novyTank = new Tank(TxtName.Text,
                TrackUroven.Value,
                ComboTyp.Text,
                ComboNarod.Text,
                TrackPancir.Value,
                TrackRychlost.Value,
                TrackKanon.Value);
            hangar.PridejTank(novyTank);

            Tank t = hangar.NejsilnejsiPancirVHangaru();
            string pancir = "";
            if (t != null)
                pancir = t.ToString() + Environment.NewLine;
            LblPrehled.Text = hangar.ToString()
                + Environment.NewLine
                + pancir;
        }
    }
}
