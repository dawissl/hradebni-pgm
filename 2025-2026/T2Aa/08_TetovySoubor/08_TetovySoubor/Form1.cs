namespace _08_TetovySoubor
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
                sw.WriteLine(TxtFile.Text);
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

                LblFile.Text = soubor;
                sr.Close();
            }
        }
    }
}
