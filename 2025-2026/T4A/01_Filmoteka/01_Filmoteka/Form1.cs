namespace _01_Filmoteka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // instance pro pøipravená dialogová okna, kter jsou atributy hlavního formuláøe
        private Form2 dialogoveOkno;
        private EditFilm editaceFilmu;

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
                // vytvoøení a pøidání filmu do Listbox bez vynuceného vypsání øazených položek
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

        /// <summary>
        /// Editace vybraného filmu z dané kolekce. Editace probíhá pøes dialogové okno editaceFilmut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // v pøípadì, že není vybrána položka je v SelectedIndex -1 a chceme zabránit
            // dalšímmu provádìní kódu
            if (kolekceFilmu.SelectedIndex == -1)
            {
                MessageBox.Show("Je tøeba vybrat film");
                return;
            }
            else
            {
                // vytvoøení nové èisté instance dialogu pro editaci
                editaceFilmu = new EditFilm();
                if (editaceFilmu.ShowDialog() == DialogResult.OK) // editace probìhne jen pøi validním zavøení
                {
                    // Vytažení zvolené položky do doèasné promìnné umožòjící následnou editaci
                    // (Film) ekxplicitní pøetypování, abychom získali možnost volat metody dané tøídy
                    Film f = (Film)kolekceFilmu.Items[kolekceFilmu.SelectedIndex]; 
                    // pøístup k properties filmu a jejich editace
                    f.Rating = editaceFilmu.Rating;
                    f.Note = editaceFilmu.Note;
                    // nahrazení editovaného do pùvodní kolekce
                    kolekceFilmu.Items[kolekceFilmu.SelectedIndex] = f;
                }
            }
        }

        private void kolekceFilmu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kolekceFilmu_DoubleClick(object sender, EventArgs e)
        {
            // nekontrolujeme vybrání položky, mùže zpùsobit výjimku za bìhu
            Film f = (Film)kolekceFilmu.Items[kolekceFilmu.SelectedIndex];
            // výpis do label komponenty informace o zvoleném filmu
            lblInfo.Text = $"Název: {f.Name}{Environment.NewLine}" +
                $"Rating:{f.Rating}{Environment.NewLine}";
        }
    }
}
