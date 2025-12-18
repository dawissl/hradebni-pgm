namespace _07_Laborator
{
    public partial class Form1 : Form
    {
        private List<Point> allTest = new List<Point>();
        private List<Point> successTest = new List<Point>();
        private List<Point> failTest = new List<Point>();
        private int xTime = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddSample_Click(object sender, EventArgs e)
        {
            SampleAdd sampleDialog = new SampleAdd();
            if (sampleDialog.ShowDialog() == DialogResult.OK)
            {
                ListSamples.Items.Add(new Sample(sampleDialog.Name,sampleDialog.Type));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestDefinitionAdd testDeffDialog = new TestDefinitionAdd();
            if(testDeffDialog.ShowDialog() == DialogResult.OK){
                ListTests.Items.Add(new TestDefinition(testDeffDialog.Name, testDeffDialog.Type, testDeffDialog.Time, testDeffDialog.Threashold));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ListSamples.SelectedIndex != -1 && ListTests.SelectedIndex != -1) {
                Sample s = (Sample) ListSamples.Items[ListSamples.SelectedIndex];
                TestDefinition t = (TestDefinition) ListTests.Items[ListTests.SelectedIndex];
                if(s.Type != t.SampleType) {
                    MessageBox.Show("Test nelze provést na tomto typu vzorku");
                    return;
                }

                ListRequests.Items.Add(new TestRequest(s,t));

            } else {
                MessageBox.Show("Nebyl zvolen vzorek nebo test");
            }
        }

        private void TimerLab_Tick(object sender, EventArgs e)
        {
            xTime++;
            if(ListRequests.Items.Count == 0) return;

            TestRequest tr = (TestRequest) ListRequests.Items[0];
            tr.Time -= TimerLab.Interval;
            if(tr.Time <= 0) {
                TestResult resolved = LabController.ResolveTest(tr);
                ListResults.Items.Add(resolved);
                allTest.Add(new Point(xTime, PanelInfo.Height - allTest.Count * 5));
                successTest.Add(new Point(xTime, PanelInfo.Height - successTest.Count * 5));
                failTest.Add(new Point(xTime, PanelInfo.Height - failTest.Count * 5));
                ListRequests.Items.RemoveAt(0);
                PanelInfo.Refresh();
            }


        }

        private void PanelInfo_Paint(object sender, PaintEventArgs e)
        {
            
            if(allTest.Count == 0) return;

            Graphics grf = e.Graphics;

            if (allTest.Count > 1)
                grf.DrawLines(Pens.Blue,allTest.ToArray());
            if (successTest.Count > 1)
                grf.DrawLines(Pens.Green,successTest.ToArray());
            if (failTest.Count > 1)
                grf.DrawLines(Pens.Red,failTest.ToArray());

            Font f = new Font("Arial",12);

            grf.DrawString($"Počet vykonaných testů: {allTest.Count}", f, Brushes.Blue, 5, 5);    
            grf.DrawString($"Počet pozitivních testů: {successTest.Count}", f, Brushes.Green, 5, 25);    
            grf.DrawString($"Počet negativních testů: {failTest.Count}", f, Brushes.Red, 5, 45);    

        }
    }
}
