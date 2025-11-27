namespace _08_TextovySoubor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // využití instance tøídy StreamReader, který formuje datový
            // proud na textový formát

            using (StreamReader sr = new StreamReader("soubor.txt"))
            {
                string vystup = string.Empty;
                // dotaz na konec souboru
                while (!sr.EndOfStream)
                {
                    vystup += sr.ReadLine() + Environment.NewLine;
                }
                LblFile.Text = vystup;
                sr.Close(); // explicitni zavøení proudu
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // využití instance tøídy StreamWriter, který formuje datový
            // proud na textový formát
            using (StreamWriter sw = new StreamWriter("vystup.txt"))
            {
                sw.WriteLine(TxtFile.Text);
                sw.Close(); // explicitni zavøení proudu
            }
        }
    }
}
