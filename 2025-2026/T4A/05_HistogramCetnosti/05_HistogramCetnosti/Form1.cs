namespace _05_HistogramCetnosti
{
    public partial class Form1 : Form
    {
        private int[] counts = new int[10];
        private bool draw = false;
        int maxIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private string GenerateValues(int n)
        {
            string ret = "";
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                ret += $"{r.Next(1, 11)} ";
            }
            return ret;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (NumN.Value < 1)
            {
                MessageBox.Show("Pokoušíte se vytvoøit pole o nulové velikosti");
                return;
            }
            else
            {
                TxtInput.Text = GenerateValues((int)NumN.Value);
            }
        }

        private void PanelOutput_Paint(object sender, PaintEventArgs e)
        {
            if (!draw) return;
            Rectangle[] recs = new Rectangle[10];
            // požaduji mít vykreslené sloupce pøes celou šíøku
            int columnWidth = PanelOutput.Width / 10;

            for (int i = 0; i < recs.Length; i++) {
                recs[i] = new Rectangle(i * columnWidth, PanelOutput.Height - (200 * (counts[i] / 100)), columnWidth, 200 * (counts[i] / 100));
            }
            Graphics g = e.Graphics;
            g.FillRectangles(Brushes.Green, recs);

        }

        private void BtnCompute_Click(object sender, EventArgs e)
        {
            // pøemazání pùvodních hodnot
            counts = new int[10];
            string[] values = TxtInput.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (values.Length == 0)
            {
                MessageBox.Show("Nenalezena žádná vstupní data");
                return;
            }
            try
            {
                foreach (string s in values)
                {
                    int x = int.Parse(s);
                    if (x > 10 || x < 1) throw new Exception("Neplatný rozsah hodnot. Vyžadovány hodnoty 1-10.");
                    //hodnota je o jedna vìtší než index v poli
                    counts[x - 1]++;
                }
                LblOutput.Text = WriteCounts();
                draw = true;
                PanelOutput.Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Neplatný formát vstupu. Oèekávají se èísla oddìlená mezerami.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string WriteCounts()
        {
            string s = "";
            for (int i = 0; i < counts.Length; i++)
            {
                s += $"[{i + 1}]: {counts[i]}x, ";
                if (i % 2 == 1) s += Environment.NewLine;
            }
            maxIndex = Array.IndexOf(counts, counts.Max());
            s += $"Nejpoèetnìjší èíslo: {maxIndex + 1}";
            return s;
        }
    }
}
