namespace _05_Obrazce
{
    public partial class Form1 : Form
    {
        // Souøadnice levého horního rohu obrazce (kliknutím do panelu se nastaví)
        private int xAxe = 0, yAxe = 0;

        // Urèuje, zda se má pøi pøekreslení panelu nìco vykreslit
        private bool draw = false;

        public Form1()
        {
            InitializeComponent();

            // Nastavení poèáteèních hodnot textového popisku souøadnic
            LblLocation.Text = $"[{xAxe}, {yAxe}]";

            // Nastavení vıchozí hodnoty pro tloušku pera a barvu (první poloka z ComboBoxu)
            ComboPen.SelectedIndex = 0;
            ComboColor.SelectedIndex = 0;
        }

        // Událost se spustí, kdy uivatel klikne myší do panelu (PanelImages)
        private void PanelImages_MouseDown(object sender, MouseEventArgs e)
        {
            // Uloení souøadnic kliknutí
            xAxe = e.X;
            yAxe = e.Y;

            // Zobrazení souøadnic v popisku
            LblLocation.Text = $"[{xAxe}, {yAxe}]";
        }

        // Kliknutí na tlaèítko "Vykresli" (BtnDraw)
        private void BtnDraw_Click(object sender, EventArgs e)
        {
            // Kontrola, zda nìkterı z rozmìrù není nulovı
            if (NumWidth.Value == 0 || NumHeight.Value == 0)
                MessageBox.Show("Jeden z rozmìrù je nulovı, obrazec nepùjde vidìt.");

            // Nastavení pøíznaku pro vykreslení
            draw = true;

            // Vyvolá pøekreslení panelu => spustí se metoda PanelImages_Paint
            PanelImages.Refresh();
        }

        // Událost pøekreslení panelu (automaticky volaná napø. pøi Refresh)
        private void PanelImages_Paint(object sender, PaintEventArgs e)
        {
            // Pokud není zapnutı reim vykreslování, ukonèí se
            if (!draw) return;

            // Objekt pro kreslení
            Graphics g = e.Graphics;

            // Vytvoøení štìtce (Brush) podle vybrané barvy
            SolidBrush b;
            switch (ComboColor.Text)
            {
                case "RED":
                    b = new SolidBrush(Color.Red);
                    break;
                case "BLUE":
                    b = new SolidBrush(Color.Blue);
                    break;
                case "GREEN":
                    b = new SolidBrush(Color.Green);
                    break;
                default:
                    b = new SolidBrush(Color.Black);
                    break;
            }

            // Vytvoøení pera (Pen) se zvolenou tlouškou, barva pera vychází z ji vytvoøeného štìtce
            Pen p = new Pen(b, float.Parse(ComboPen.Text));

            // Definice oblasti, ve které se obrazec vykreslí
            Rectangle rec = new Rectangle(xAxe, yAxe, (int)NumWidth.Value, (int)NumHeight.Value);

            // Rozhodnutí podle checkboxu, zda se má tvar vyplnit nebo jen obkreslit
            if (CheckFill.Checked)
            {
                // Vıplò elipsy nebo obdélníku
                if (RadEllipse.Checked)
                    g.FillEllipse(b, rec);
                else
                    g.FillRectangle(b, rec);
            }
            else
            {
                // Pouze obrys elipsy nebo obdélníku
                if (RadEllipse.Checked)
                    g.DrawEllipse(p, rec);
                else
                    g.DrawRectangle(p, rec);
            }
        }

        // Zmìna stavu checkboxu „Vyplnit obrazec“
        private void CheckFill_CheckedChanged(object sender, EventArgs e)
        {
            // Pokud je zaškrtnuto, vypneme monost volby tloušky pera (není potøeba pøi vıplni)
            if (CheckFill.Checked)
            {
                ComboPen.Enabled = false;
            }
            else
            {
                ComboPen.Enabled = true;
            }
        }
    }
}
