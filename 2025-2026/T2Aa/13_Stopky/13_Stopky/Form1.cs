namespace _13_Stopky
{
    public partial class Form1 : Form
    {
        int cas =0;
        public Form1()
        {
            InitializeComponent();
        }

        private void TimerStopky_Tick(object sender, EventArgs e)
        {
            cas += TimerStopky.Interval;
            int minuty = cas / 60000;
            int sekundy = cas % 60000 / 1000;
            int milisekundy = cas % 1000;

            string sMinuty = (minuty < 10) ? $"0{minuty}" : $"{minuty}";

            LblTime.Text = $"{sMinuty} : {sekundy:D2} : {milisekundy}";
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
