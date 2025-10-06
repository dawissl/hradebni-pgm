namespace _03_CisteniDat
{
    public partial class Form1 : Form
    {
        private string dummy = "  jana,  Petr  18, tomas,24, eva  30  , marek  ,  1 , 5, lucie  ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnParse_Click(object sender, EventArgs e)
        {
            // vypsání akutálního èasu 
            LblDateTime.Text = DateTime.Now.ToString();

            // pokud uživatel nezadá vstupní text, využije se cvièný text
            string parcedString = (TxtInput.Text == string.Empty) ? dummy : TxtInput.Text;
            // pøed rozdìlením nahradíme všechny èárky mezerami
            // použití více oddìlovaèù a ignorování vzniklých prázdných øetìzcù
            string[] splitted = parcedString.Replace(",", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // pøipravení kolekcí pro ukládání èísel a slov
            List<int> cisla = new List<int>();
            List<string> slova = new List<string>();
            // projdeme celé novì vzniklé pole øetìzcù
            for (int i = 0; i < splitted.Length; i++)
            {
                try
                {
                    // pokud selže parsovací funkce, jedná se o slovo
                    int cislo = int.Parse(splitted[i].Trim());
                    cisla.Add(cislo);
                }
                catch (FormatException ex)
                {
                    // jakmile se objeví výjimka, jedna se o slovo a dále tak s ním pracujeme
                    string slovo = splitted[i].Trim();
                    string upraveneSlovo = slovo.Substring(0, 1).ToUpper() + slovo.Substring(1, slovo.Length - 1).ToLower();
                    slova.Add(upraveneSlovo);
                }
            }
            // vypsání jednotlivých kolekcí slov a èísel
            LblResult.Text = $"Jména: {string.Join(", ", slova)}{Environment.NewLine}Èísla: {string.Join(", ", cisla)}";


        }
    }
}
