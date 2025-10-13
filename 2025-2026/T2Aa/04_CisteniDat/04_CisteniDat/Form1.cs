namespace _04_CisteniDat
{
    public partial class Form1 : Form
    {
        // pomocný øetìzec, který je použit pokud uživatel nezadá nic na vstup
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
            string[] splitted = parcedString.Replace(",", " ").Replace("\n", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> words = new List<string>();
            List<int> numbers = new List<int>();
            for (int i = 0; i < splitted.Length; i++)
            {
                try
                {
                    int num = int.Parse(splitted[i].Trim());
                    numbers.Add(num);
                }
                catch (FormatException ex)
                {
                    string word = splitted[i].Trim();
                    string editedWord = word.Substring(0,1).ToUpper() + word.Substring(1).ToLower();
                    words.Add(editedWord);
                }
            }
            LblResult.Text = $"JMÉNA: {string.Join(" - ",words)}{Environment.NewLine}ÈÍSLA: {string.Join(", ",numbers)}";
        }
    }
}
