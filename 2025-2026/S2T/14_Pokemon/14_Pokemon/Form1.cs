namespace _14_Pokemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Pokedex pokedex = new Pokedex();
        private void Form1_Load(object sender, EventArgs e)
        {
            LblPrehled.Text = pokedex.Overview();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Pokemon p = new Pokemon(TxtName.Text,
                ComboTyp.Text,
                TrackHP.Value,
                TrackRychlost.Value,
                TrackUroven.Value,
                TrackSila.Value
                );

            pokedex.PridejPokemona(p);

            LblPrehled.Text = pokedex.Overview();

        }
    }
}
