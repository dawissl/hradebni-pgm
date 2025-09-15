namespace _00_Boiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TopnyBoiler boiler;

        private void Btn_Config_Click(object sender, EventArgs e)
        {
            try
            {
                int vol = int.Parse(TxtVolume.Text);
                // nastavení maxima odpovídající objemu boileru
                ProgVolume.Maximum = vol;
                ProgVolume.Value = vol;
                if (vol <= 0) throw new Exception("Objem musí být vìtší 0");
                boiler = new TopnyBoiler(int.Parse(TxtPower.Text), vol);
                    boiler.
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (boiler == null) return;
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            if (boiler == null)
            {
                MessageBox.Show("Nejprve inicializujete topný boiler");
                return;
            }
            if (!boiler.IsOn)
            {
                BtnControl.BackColor = Color.DarkGreen;
                BtnControl.Text = "Zapnuto";
                boiler.IsOn = true;
            }
            else
            {
                BtnControl.BackColor = Color.IndianRed;
                BtnControl.Text = "Vypnuto";
                boiler.IsOn = false;
            }
        }

        private void BtnDrain_Click(object sender, EventArgs e)
        {
            if (boiler == null) return;
            if(!boiler.Drain) {
                BtnDrain.Text = "Zavøít";
                boiler.Drain = true;    
            }
            else
            {
                BtnDrain.Text = "Vypouštìt";
                boiler.Drain = false;

            }



        }
    }
}
