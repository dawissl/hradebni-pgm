namespace _13_Stopky
{
    public partial class Form1 : Form
    {
        int minuty = 9, sekundy = 50, milisekundy = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TimerStopky_Tick(object sender, EventArgs e)
        {
            milisekundy += 100;
            
            if (milisekundy >= 1000)
            {
                milisekundy = 0;
                sekundy += 1;
            }
            if (sekundy >= 60)
            {
                sekundy = 0;
                minuty += 1;
            }
            string sek = (sekundy < 10) ? $"0{sekundy}" : $"{sekundy}";
            string min = (minuty < 10) ? $"0{minuty}" : $"{minuty}";
            LblTime.Text = $"{min} : {sek} : {milisekundy}";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TimerStopky.Enabled = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            TimerStopky.Enabled = false;

        }
    }
}
