namespace _01_Filmoteka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Film> filmoteka = new List<Film>();
            Film f1 = new Film("Abc", "def");
            Film f2 = new Film("AbcX", "def");
            Film f3 = new Film("XX", "daasdf");
            Film f4 = new Film("Abc", "sss");

            f2.Note = "moje super poznámka";
            f3.Rating = 60;
            filmoteka.Add(f1);
            filmoteka.Add(f2);
            filmoteka.Add(f3);
            filmoteka.Add(f4);

            string vystup = string.Empty;

            foreach (Film film in filmoteka)
            {
                vystup += film;
                vystup += $"[{film.Info()}]";
                vystup += Environment.NewLine;
            }
            LblOut.Text = vystup;
        }
    }
}
