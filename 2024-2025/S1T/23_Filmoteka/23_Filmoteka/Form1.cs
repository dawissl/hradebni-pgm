using System.Text;

namespace _23_Filmoteka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        private void FilmList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (FilmList.SelectedIndex == -1) return;
            if (FilmList.Items[FilmList.SelectedIndex] is Horor)
                LblInfo.Text = "hsrasdgsdfg";
            else
                LblInfo.Text = (FilmList.Items[FilmList.SelectedIndex] as Film).Info();
        }

        private void BtnPridat_Click_1(object sender, EventArgs e)
        {
            Film f;
            switch (ComboKategorie.Text)
            {
                case "Komedie":
                    f = new Komedie(TxtNazev.Text, TxtRezie.Text, (int)NumHodnocení.Value, "nej hlasky");
                    break;
                case "Horor":
                    f = new Horor(TxtNazev.Text, TxtRezie.Text, (int)NumHodnocení.Value, false);
                    break;
                case "Dokument":
                    f = new Dokument(TxtNazev.Text, TxtRezie.Text, (int)NumHodnocení.Value, 2024);
                    break;
                case "Sci-Fi":
                    f = new Scifi(TxtNazev.Text, TxtRezie.Text, (int)NumHodnocení.Value, "Frodo");
                    break;
                default:
                    f = new Film(TxtNazev.Text, TxtRezie.Text, (int)NumHodnocení.Value);
                    break;
            }
            FilmList.Items.Add(f);
        }

        private void BtnOdstran_Click_1(object sender, EventArgs e)
        {
            FilmList.Items.RemoveAt(FilmList.SelectedIndex);
        }
    }
}