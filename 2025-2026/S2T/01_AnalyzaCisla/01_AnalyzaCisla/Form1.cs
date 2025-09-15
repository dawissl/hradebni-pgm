namespace _01_AnalyzaCisla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(TxtNum.Text);
                string vystup = "";

                vystup += KladneZaporne(num);
                vystup += SudeLiche(num);
                vystup += Prvocislo(num);
                vystup += Dokonale(num);
                vystup += Delitele(num);

                LblVystup.Text = vystup;

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Dokonale(int num)
        {
            int suma = 0;
            for (int i = 1; i < num; i++) {
                if (num % i == 0) suma += i;
            }
            if (suma == num) return $"èíslo je dokonalé{Environment.NewLine}";
            return "";
        }

        private string KladneZaporne(int num)
        {
            if (num == 0) return "";
            return $"èíslo je {(num > 0 ? "kladné" : "záporné")}{Environment.NewLine}";
        }

        private string SudeLiche(int x)
        {
            return $"èíslo je {((x % 2 == 0) ? "sudé" : "liché")}{Environment.NewLine}";
        }

        private string Delitele(int x) {
            if (x < 0)
            {
                MessageBox.Show("Dìlitelé nejsou vypisování pro záporná èísla");
            }
            string delitele = "Dìlitelé èísla: ";
            for (int i = 1; i < x; i++) { 
                if(x % i == 0) delitele += $"{i} ";
            }
            return delitele + Environment.NewLine;
        
        }

        private string Prvocislo(int x) {
            if (x < 0) return "";
            for (int i = 2; i < x / 2; i++) {
                if (x % i == 0) return "";
            }
            return $"èíslo je prvoèíslo{Environment.NewLine}";
        }
    }
}