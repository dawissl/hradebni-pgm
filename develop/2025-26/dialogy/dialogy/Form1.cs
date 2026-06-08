namespace dialogy
{
    public partial class Form1 : Form
    {
        Film film;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFilm addFilm = new AddFilm();

            if (addFilm.ShowDialog() == DialogResult.OK)
            {
                film = addFilm.GetFilm;
                string x = film.Title;
                film.Title = "New Title";
                if (film != null)
                    label1.Text = film.ToString();
            }
            else
            {
                MessageBox.Show("Film was not added.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                film.Director = "abcXXX";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label1.Text = film.ToString();
            Barva b = Barva.Green;

        }


    }

    enum Barva
    {
        Red,
        Green=5,
        Blue,
        LightBlue = 6,
        Yellow
    }
}
