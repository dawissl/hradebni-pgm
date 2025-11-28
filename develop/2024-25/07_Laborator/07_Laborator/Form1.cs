namespace _07_Laborator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddSample_Click(object sender, EventArgs e)
        {
            SampleAdd sampleDialog = new SampleAdd();
            if (sampleDialog.ShowDialog() == DialogResult.OK)
            {
                //ListSamples.Items.Add(new Sample(sampleDialog.));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void TimerLab_Tick(object sender, EventArgs e)
        {

        }

        private void PanelInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
