using System.ComponentModel;

namespace _02_DnDKostky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pøidání nové kostky do seznamu (CheckedListBox).
        /// Velikost kostky se bere z TextBoxu, barva z barevného Labelu
        /// a pøípadná poznámka z TextBoxu. Pokud poznámka není zadána,
        /// použije se konstruktor bez poznámky.
        /// </summary>
        private void BtnAddDice_Click(object sender, EventArgs e)
        {
            try
            {
                int s = int.Parse(TxtSize.Text); // velikost kostky (poèet stìn)
                if (s < 4) throw new Exception("Invalid size of dice. Minimum is D4");
                Dice d;
                if (TxtNote.Text == string.Empty)
                    d = new Dice(s, LblColor.BackColor);
                else
                    d = new Dice(s, LblColor.BackColor, TxtNote.Text);

                // pøidání kostky do seznamu
                dicesList.Items.Add(d);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Chyba"); // špatnì zadané èíslo
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba"); // Porušena minimální velikost kostky

            }
        }

        /// <summary>
        /// Zmìna barvy – otevøe dialog pro výbìr barvy a nastaví ji na LblColor.
        /// </summary>
        private void LblColor_Click(object sender, EventArgs e)
        {
            if (DiceColorDialog.ShowDialog() == DialogResult.OK)
            {
                LblColor.BackColor = DiceColorDialog.Color;
            }
        }

        // pomocná kolekce s vybranými kostkami – uchovává reference,
        // které se mají aktuálnì vykreslit a pozdìji odstranit
        private List<Dice> diceListDrawed = new List<Dice>();

        /// <summary>
        /// Kliknutí na tlaèítko "Hodit kostkami".
        /// Nejprve odstraní staré Labely (RemoveDices),
        /// pak projde všechny zaškrtnuté kostky v seznamu, hodí jimi,
        /// uloží výsledky a zavolá vykreslení (DrawDices).
        /// </summary>
        private void BtnRoll_Click(object sender, EventArgs e)
        {
            RemoveDices(); // smaže staré vykreslené kostky
            string result = "";

            // projdeme všechny zaškrtnuté kostky v seznamu
            foreach (Dice d in dicesList.CheckedItems)
            {
                result += $"{d.ToString()} [{d.Roll()}]{Environment.NewLine}";
                diceListDrawed.Add(d); // uložíme do pomocného seznamu pro vykreslení
            }

            DrawDices();            // vykreslení kostek
            LblRoll.Text = result;  // výpis textového výsledku
        }

        /// <summary>
        /// Vykreslení kostek ve formì Labelù na formuláøi.
        /// Vytváøí se dynamicky Labely, které zobrazí hodnotu hodu
        /// a barvu nastavenou na kostce. Label dostane jméno podle ToString() kostky.
        /// </summary>
        private void DrawDices()
        {
            int x = 460;   // poèáteèní X souøadnice
            int y = 220;   // poèáteèní Y souøadnice
            int size = 20; // velikost ètvereèku
            int space = 10;// mezera mezi ètvereèky

            foreach (Dice d in diceListDrawed)
            {
                // pokud jsme pøesáhli šíøku, posuneme se na nový øádek
                if (x > 750)
                {
                    x = 460;
                    y += 40;
                }

                // vytvoøení labelu reprezentujícího kostku
                Label l = new Label();
                l.Location = new Point(x, y);
                l.Width = size;
                l.Height = size;
                l.Text = $"{d.Rolled}"; // hod kostkou
                x += space + size;
                l.BackColor = d.DColor; // barva kostky
                // pokud je barva v nìkterém z kanálu tmavá text bude bílý
                if (l.BackColor.R < 30 || l.BackColor.G < 30 || l.BackColor.B < 30)
                    l.ForeColor = Color.White;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Name = d.ToString().Replace(" ", "_"); // unikátní jméno pro pozdìjší odstranìní

                Controls.Add(l); // pøidání na formuláø
            }
        }

        /// <summary>
        /// Odstranìní všech vykreslených kostek (Labelù).
        /// Probíhá vyhledání podle Name, které je vytvoøeno z ToString() kostky.
        /// </summary>
        private void RemoveDices()
        {
            if (diceListDrawed.Count == 0) return;

            foreach (Dice d in diceListDrawed)
            {
                Controls.Remove(Controls[d.ToString().Replace(" ", "_")]);
            }

            // vyprázdníme pomocný seznam
            diceListDrawed = new List<Dice>();
        }

        /// <summary>
        /// Vybrat všechny kostky k hodu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dicesList.Items.Count; i++)
            {
                dicesList.SetItemChecked(i, true);
            }
        }
    }
}
