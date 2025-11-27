namespace _09_AnalyzaSouboru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Naètení a analýza souboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // Promìnné pro statistiky souboru
            int words = 0;       // poèet slov
            int letters = 0;     // poèet znakù bez mezer
            int characters = 0;  // poèet znakù vèetnì mezer
            int lines = 0;       // poèet øádkù

            // Otevøení souboru pro ètení
            using (StreamReader sr = new StreamReader("textovy_soubor.txt"))
            {
                // Dokud nejsme na konci souboru
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();  // naètení jednoho øádku ze souboru
                    lines++;                      // zvýšení poètu øádkù
                    characters += line.Length;    // pøiètení délky øádku k celkovým znakùm vèetnì mezer

                    // Spoèítání slov na øádku
                    // Rozdìlení podle mezer, prázdné položky ignorujeme
                    words += line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

                    // Spoèítání znakù bez mezer
                    letters += line.Replace(" ", "").Length;
                }
            }

            // Výpis výsledkù do labelu na formuláøi
            LblStats.Text = $"Analýza souboru:{Environment.NewLine}" +
                $"Poèet øádkù: {lines}{Environment.NewLine}" +
                $"Poèet slov: {words}{Environment.NewLine}" +
                $"Poèet znakù: {characters} (bez mezer {letters})";
        }

        /// <summary>
        /// Uloží statisktu souboru do souboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Otevøení souboru pro zápis (pøepíše existující obsah)
            using (StreamWriter sw = new StreamWriter("statistika.txt"))
            {
                sw.Write(LblStats.Text); // zapsání textu labelu do souboru
            }
        }
    }
}
