namespace _01_Filmoteka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Form2 dialogoveOkno;

        /// <summary>
        /// Pøidáme film do kolekce a do labelu vypíšeme všchny filmy seøazené lexikograficky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddFilm_Click(object sender, EventArgs e)
        {
            Film f = new Film(txtName.Text, txtDirector.Text);

            kolekceFilmu.Items.Add(f);
            f.Info();

            string serazene = string.Empty;
            // pøevedení filmù z kolekce v listboxu do interního listu Filmù
            List<Film> listFilmu = new List<Film>();
            for (int i = 0; i < kolekceFilmu.Items.Count; i++)
            {
                // pøetypování obecného Object uloženého v listbox na Film
                listFilmu.Add((Film)kolekceFilmu.Items[i]);
            }

            // seøazení, využití IComparable<Film>
            listFilmu.Sort();
            lblInfo.Text = string.Join(Environment.NewLine, listFilmu);

        }

        /// <summary>
        /// Pøidání nového filmu skrze dialogové okno. Nedochází k následnému øazení
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDialog_Click(object sender, EventArgs e)
        {
            dialogoveOkno = new Form2();
            // následná práce s hodnotami z dialogového okna je podmínìna
            // úspìšným uzavøením v opaèném pøípadì se nic nevykoná
            if (dialogoveOkno.ShowDialog() == DialogResult.OK)
            {

                Film f = new Film(dialogoveOkno.MovieName, dialogoveOkno.MovieDirector);
                kolekceFilmu.Items.Add(f);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Uložení seznamu filmù do zvoleného výstupního souboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // ukladani je podmínìno volbou souboru
       
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ustanovení proudo pro zápis
                // saveFileDialog1.FileName = absolutní cesta k vytváøenému souboru
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    // výpis stringu na øádek s odsazením na další øádek
                    sw.WriteLine("NAZEV;REZISER;HODNOCENI;POZNAMKA");

                    //sw.Write("xxxx); napíše øetìzec na øádek bez odsazení

                    foreach (Film f in kolekceFilmu.Items)
                    {
                        sw.WriteLine(f.ToCsv());
                    }
                    // uzavøení proudu a tudíž i uložení souboru
                    sw.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    // ètení dokud nenarazíme na konec souboru
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();  // vyètení jednoho øádku
                        MessageBox.Show(line); // zobrazení naèteného øádku
                    }
                    sr.Close();
                }
            }
        }
    }
}
