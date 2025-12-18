namespace _08_AnalyzaSouboru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using(StreamReader sr = new StreamReader("textovy_soubor.txt"))
            {
                int words = 0;
                int chars_no_space = 0;
                int chars = 0;
                int lines = 0;
                // využijeme cyklus na dotázání, zda jsme na konci datového proudu
                while (!sr.EndOfStream)
                {
                    // pøeètení jednoho øádku
                    string radek = sr.ReadLine();
                    lines++;
                    chars += radek.Length;
                    string[] rozdelene = radek.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                    words += rozdelene.Length;
                    chars_no_space += radek.Replace(" ","").Length;
                }
                LblStats.Text = $"Statistika souboru: {Environment.NewLine}" +
                    $"Poèet øádkù {lines}{Environment.NewLine}" +
                    $"Poèet slov {words}{Environment.NewLine}" +
                    $"Poèet znakù s mezerami {chars}{Environment.NewLine}" +
                    $"Poèet znakù bez mezer {chars_no_space}{Environment.NewLine}";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using(StreamWriter sw = new StreamWriter("statistika.txt"))
            {
                sw.Write(LblStats.Text);
                sw.Close();
            }
        }

        /// <summary>
        /// Rozcvièka 8.12.2025 Detekce palindromu
        /// </summary>
        /// <param name="vstup">Vstupní øetìzec pro ovìøení, zda je palindrom</param>
        /// <returns>true pokud je palindrom</returns>
        public bool isPalindrom(string vstup)
        {
            for(int i = 0; i < vstup.Length / 2; i++)
            {
                if (vstup[i] != vstup[vstup.Length - i - 1])
                    return false;
            }

            return true;
        }
    }
}
