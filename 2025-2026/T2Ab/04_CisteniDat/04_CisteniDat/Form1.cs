namespace _04_CisteniDat
{
    public partial class Form1 : Form
    {
        private string dummy = "  jana,  Petr  18, tomas,24, eva  30  , marek  ,  1 , 5, lucie  ";

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnParse_Click(object sender, EventArgs e)
        {
            // vypsání akutálního èasu 
            LblDateTime.Text = DateTime.Now.ToString();

            // pokud uživatel nezadá vstupní text, využije se cvièný text
            string parcedString = (TxtInput.Text == string.Empty) ? dummy : TxtInput.Text;
            // pøipravené kolekce pro uložení konkrétních èástí vstupu
            List<int> numbers = new List<int>();
            List<string> names = new List<string>();
            // postupné nahrazení èárek za mezery a odsazení za mezery 
            // pøi dìlení jsou vyøazeny øetìzce, které jsou prázdné - StringSplitOptions
            string[] splitted = parcedString.Replace(",", " ").Replace("\n", " ").Split(" ",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitted.Length; i++)
            {
                try
                {
                    //pokus o parsování èísla
                    int x = int.Parse(splitted[i].Trim());
                    numbers.Add(x);
                }
                catch (FormatException ex)
                {
                    // výjimka vznikne v momentì, kdy parsovací funkce selže
                    string word = splitted[i].Trim();
                    string edittedWord = word.Substring(0,1).ToUpper() + word.Substring(1).ToLower();
                    names.Add(edittedWord);
                }

            }
            LblResult.Text= $"Jména: {string.Join("-",names)}{Environment.NewLine}Èísla: {string.Join(", ", numbers)}";

        }
    }
}
