namespace _11_Stopky
{
    public partial class Form1 : Form
    {
        private int time = 51000;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TimerTime.Enabled = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            TimerTime.Enabled = false;

        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            time += 100;

            int sekundy = time / 1000;
            int minuty = sekundy / 60;

            string sminuty = "";
            string ssekundy = "";
            if (sekundy < 10)
                ssekundy = $"0{sekundy % 60}";
            else
                ssekundy = $"{sekundy % 60}";
            if (minuty < 10)
                sminuty = $"0{minuty}";
            else
                sminuty = $"{minuty}";
            LblTime.Text = $"{sminuty} : {(sekundy % 60):D2} : {time % 1000:D3}";
        }
    }
}
