namespace _07_TextovySoubor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                sw.Write(TxtFile.Text);
                sw.Close();
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("soubor.txt"))
            {
                string soubor = string.Empty;
                while (!sr.EndOfStream)
                {

                    soubor += sr.ReadLine() + Environment.NewLine;
                }
                sr.Close();
                LblFile.Text = soubor.ToUpper();
            }
        }
    }
}
