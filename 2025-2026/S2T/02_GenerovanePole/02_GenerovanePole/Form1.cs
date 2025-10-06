namespace _02_GenerovanePole
{
    public partial class Form1 : Form
    {
        private int[] array;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            array = null;
            ToggleButtons(false);
            int size = (int)NumArrSize.Value;
            LblResult.Text = string.Empty;
            LblArray.Text = string.Empty;

            if (size < 2 || size > 20)
            {
                MessageBox.Show("Velikost pole musí být v rozsahu 2 - 20 hodnot.");
                return;
            }
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 51);
            }
            LblArray.Text = string.Join(", ", array);
            if (array != null)
                ToggleButtons(true);

            string oo = $"{array.Max()},{array.Min()},{array.Sum()}";
            MessageBox.Show(oo);
        }

        private void ToggleButtons(bool status)
        {
            BtnSum.Enabled = status;
            BtnMul.Enabled = status;
            BtnMaxMin.Enabled = status;
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            int suma = 0;
            // souèet pomocí for cyklu
            for (int i = 0; i < array.Length; i++)
            {
                suma += array[i];
            }
            LblResult.Text = $"Suma je {suma}";

            // souèet foreach
            int suma2 = 0;
            foreach (int x in array)
            {
                suma2 += x;
            }
            LblResult.Text = $"Suma je {suma2}";

        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            int suma = 1;
            for (int i = 0; i < array.Length; i++)
                suma *= array[i];
            LblResult.Text = $"Souèin je {suma}";

        }

        private void BtnMaxMin_Click(object sender, EventArgs e)
        {
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if(array[i] > max) max = array[i];
                if(array[i] < min) min = array[i];

            }

            LblResult.Text = $"'Max {max}, Min {min}";


        }
    }
}
