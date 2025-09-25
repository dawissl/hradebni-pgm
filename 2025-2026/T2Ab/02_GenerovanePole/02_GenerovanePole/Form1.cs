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
        }

        private void ToggleButtons(bool status)
        {
            BtnSum.Enabled = status;
            BtnMul.Enabled = status;
            BtnMaxMin.Enabled = status;
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            LblResult.Text = $"Suma hodnot: {array.Sum()}";
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            int mulledNumbers = 1;
            foreach (int i in array)
            {
                mulledNumbers *= i;
            }
            LblResult.Text = $"Souèin hodnot: {mulledNumbers}";

        }

        private void BtnMaxMin_Click(object sender, EventArgs e)
        {
            LblResult.Text = $"Max: {array.Max()}, Min: {array.Min()}";

        }
    }
}
