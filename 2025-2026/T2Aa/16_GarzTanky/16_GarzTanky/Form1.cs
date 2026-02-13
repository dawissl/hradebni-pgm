namespace _16_GarzTanky
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
            string pancir = "";
            Tank t = garaz.NejsilnejsiPancirGaraze();
            if (t != null)
            {
                pancir = Environment.NewLine+"Nejsilnìjší pancíø:"+ Environment.NewLine+ t.ToString();
            }
            LblPrehled.Text = garaz.ToString()+pancir;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tank t = new Tank(TxtName.Text,
                TrackUroven.Value,
                ComboNarod.Text,
                ComboTyp.Text,
                TrackPancir.Value,
                TrackRychlost.Value,
                TrackKanon.Value);

            garaz.PridejTank(t);
            string pancir = "";
            t = garaz.NejsilnejsiPancirGaraze();
            if (t != null)
            {
                pancir = Environment.NewLine + "Nejsilnìjší pancíø:" + Environment.NewLine + t.ToString();
            }
            LblPrehled.Text = garaz.ToString() + pancir;
        }
    }
}
