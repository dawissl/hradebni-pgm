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
            pokedex.PridejPokemona(new Pokemon("Bulbasaur","travní", 100,20,8,6));
            pokedex.PridejPokemona(new Pokemon("Charizard","ohnivý", 100,20,18,56));
            pokedex.PridejPokemona(new Pokemon("Ratata","zemní", 100,7,8,6));
            pokedex.PridejPokemona(new Pokemon("Metapod","travní", 100,20,13,66));
            pokedex.PridejPokemona(new Pokemon("Squirtle","vodní", 89,17,5,16));
            pokedex.PridejPokemona(new Pokemon("Onyx","kamenný", 100,50,15,6));
            pokedex.PridejPokemona(new Pokemon("Hitmonlee","bojový", 100,2,20,6));
            pokedex.PridejPokemona(new Pokemon("Snorlax","spící", 18,2,13,76));
                        
            label1.Text = pokedex.ToString();
            label2.Text = pokedex.NejsilnejsiPokemon().ToString();
        
        }
    }
}
