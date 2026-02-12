namespace _14_Pokemon
{
    public partial class Form1 : Form
    {
        private Pokedex pokedex = new Pokedex();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pokedex.PridejPokemona(new Pokemon("Bulbasour", 10, "travní", 30, 30, 20));
            pokedex.PridejPokemona(new Pokemon("Charizard", 8, "ohnivý", 38, 12, 10));
            pokedex.PridejPokemona(new Pokemon("Squirtle", 2, "vodní",10, 32, 17));
            pokedex.PridejPokemona(new Pokemon("Snorlax", 10, "spací", 3, 3, 2));
            pokedex.PridejPokemona(new Pokemon("Ratata", 6, "zemní", 9, 12, 5));
            pokedex.PridejPokemona(new Pokemon("Metapod", 6, "hmyzí", 50, 10, 24));          

            label1.Text = pokedex.ToString();
        }
    }
}
