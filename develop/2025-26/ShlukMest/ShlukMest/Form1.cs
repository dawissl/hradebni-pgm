using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShlukMest
{
    public partial class Form1 : Form
    {
        private List<City> allCities = new List<City>();
        private List<Group> groups = new List<Group>();
        private Group selectedGroup = null;

        public Form1()
        {
            InitializeComponent();
            UpdateMinMaxLabels();
        }

        #region Menu Handlers

        /// <summary>
        /// Načtení dat ze souboru CSV
        /// </summary>
        private void MenuNacistSoubor_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV soubory|*.csv|Všechny soubory|*.*";
            ofd.Title = "Vyberte soubor s daty měst";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadCitiesFromFile(ofd.FileName);
                    GroupCities();
                    UpdateUI();
                    MessageBox.Show($"Úspěšně načteno {allCities.Count} měst.", "Načtení dokončeno",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba při načítání souboru: {ex.Message}", "Chyba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Manuální přidání města pomocí dialogu
        /// </summary>
        private void MenuPridatMesto_Click(object sender, EventArgs e)
        {
            // Vytvoření jednoduchého formuláře pro vstup
            Form inputForm = new Form();
            inputForm.Text = "Přidat město";
            inputForm.Width = 400;
            inputForm.Height = 300;
            inputForm.StartPosition = FormStartPosition.CenterParent;

            Label lblName = new Label() { Left = 20, Top = 20, Text = "Název:", Width = 100 };
            TextBox txtName = new TextBox() { Left = 130, Top = 20, Width = 200 };

            Label lblX = new Label() { Left = 20, Top = 50, Text = "Souřadnice X:", Width = 100 };
            NumericUpDown numX = new NumericUpDown() { Left = 130, Top = 50, Width = 200, Maximum = 500, Minimum = 0 };

            Label lblY = new Label() { Left = 20, Top = 80, Text = "Souřadnice Y:", Width = 100 };
            NumericUpDown numY = new NumericUpDown() { Left = 130, Top = 80, Width = 200, Maximum = 300, Minimum = 0 };

            Label lblPop = new Label() { Left = 20, Top = 110, Text = "Populace:", Width = 100 };
            NumericUpDown numPop = new NumericUpDown() { Left = 130, Top = 110, Width = 200, Maximum = 2000000, Minimum = 100 };

            Label lblRegional = new Label() { Left = 20, Top = 140, Text = "Krajské město:", Width = 100 };
            CheckBox chkRegional = new CheckBox() { Left = 130, Top = 140, Width = 200 };

            Label lblInfected = new Label() { Left = 20, Top = 170, Text = "Počet nakažených:", Width = 100 };
            NumericUpDown numInfected = new NumericUpDown() { Left = 130, Top = 170, Width = 200, Maximum = 2000000, Minimum = 0 };

            Button btnOK = new Button() { Text = "Přidat", Left = 130, Top = 210, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Zrušit", Left = 220, Top = 210, Width = 80, DialogResult = DialogResult.Cancel };

            inputForm.Controls.Add(lblName);
            inputForm.Controls.Add(txtName);
            inputForm.Controls.Add(lblX);
            inputForm.Controls.Add(numX);
            inputForm.Controls.Add(lblY);
            inputForm.Controls.Add(numY);
            inputForm.Controls.Add(lblPop);
            inputForm.Controls.Add(numPop);
            inputForm.Controls.Add(lblRegional);
            inputForm.Controls.Add(chkRegional);
            inputForm.Controls.Add(lblInfected);
            inputForm.Controls.Add(numInfected);
            inputForm.Controls.Add(btnOK);
            inputForm.Controls.Add(btnCancel);

            inputForm.AcceptButton = btnOK;
            inputForm.CancelButton = btnCancel;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Název města nesmí být prázdný!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                City newCity = new City(
                    txtName.Text,
                    new Point((int)numX.Value, (int)numY.Value),
                    (int)numPop.Value,
                    chkRegional.Checked,
                    (int)numInfected.Value
                );

                allCities.Add(newCity);
                GroupCities();
                UpdateUI();

                MessageBox.Show($"Město {txtName.Text} bylo přidáno.", "Přidání dokončeno",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Reset aplikace - vymazání všech dat
        /// </summary>
        private void MenuReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Opravdu chcete smazat všechna data?", "Potvrzení",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                allCities.Clear();
                groups.Clear();
                selectedGroup = null;
                UpdateUI();
            }
        }

        /// <summary>
        /// Zobrazení informací o autorovi
        /// </summary>
        private void MenuOAutorovi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aplikace pro vizualizaci shluků měst ČR\n\n" +
                "Autor: [Jméno studenta]\n" +
                "Datum: Únor 2026\n" +
                "Verze: 1.0\n\n" +
                "Maturitní projekt - Programování",
                "O aplikaci",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        #endregion

        #region Data Processing

        /// <summary>
        /// Načte města ze souboru CSV
        /// Formát: Název,X,Y,Populace,JeKrajské,Nakažení
        /// </summary>
        private void LoadCitiesFromFile(string filename)
        {
            allCities.Clear();
            string[] lines = File.ReadAllLines(filename);

            // Přeskočíme hlavičku (první řádek)
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length != 6)
                {
                    throw new Exception($"Neplatný formát na řádku {i + 1}: očekáváno 6 hodnot, nalezeno {parts.Length}");
                }

                try
                {
                    string name = parts[0].Trim();
                    int x = int.Parse(parts[1].Trim());
                    int y = int.Parse(parts[2].Trim());
                    int population = int.Parse(parts[3].Trim());
                    bool isRegional = bool.Parse(parts[4].Trim());
                    int infected = int.Parse(parts[5].Trim());

                    // Validace hodnot
                    if (x < 0 || x > 500 || y < 0 || y > 300)
                    {
                        throw new Exception($"Souřadnice města {name} jsou mimo platný rozsah (0-500, 0-300)");
                    }

                    if (population <= 0)
                    {
                        throw new Exception($"Populace města {name} musí být kladné číslo");
                    }

                    if (infected < 0 || infected > population)
                    {
                        throw new Exception($"Počet nakažených v {name} musí být mezi 0 a celkovou populací");
                    }

                    City city = new City(name, new Point(x, y), population, isRegional, infected);
                    allCities.Add(city);
                }
                catch (FormatException)
                {
                    throw new Exception($"Chyba formátu dat na řádku {i + 1}");
                }
            }

            if (allCities.Count == 0)
            {
                throw new Exception("Soubor neobsahuje žádná platná data měst");
            }

            // Kontrola, zda existuje alespoň jedno krajské město
            if (!allCities.Any(c => c.IsRegional))
            {
                throw new Exception("V datech musí být alespoň jedno krajské město!");
            }
        }

        /// <summary>
        /// Provede shlukování měst podle vzdálenosti od krajských měst (centroidů)
        /// Algoritmus:
        /// 1. Vytvoří shluky pro všechna krajská města
        /// 2. Přiřadí každé nekrajské město k nejbližšímu krajskému městu
        /// </summary>
        private void GroupCities()
        {
            groups.Clear();

            // Krok 1: Vytvoření shluků pro krajská města (centroidy)
            foreach (City city in allCities)
            {
                if (city.IsRegional)
                {
                    groups.Add(new Group(city));
                }
            }

            // Krok 2: Přiřazení nekrajských měst k nejbližšímu centroidu
            foreach (City city in allCities)
            {
                if (city.IsRegional) continue; // Krajská města již jsou ve shlucích

                // Najdeme nejbližší centroid (krajské město)
                double minDistance = double.MaxValue;
                int nearestGroupIndex = 0;

                for (int i = 0; i < groups.Count; i++)
                {
                    double distance = groups[i].GetDistance(city.Center);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestGroupIndex = i;
                    }
                }

                // Přidáme město do nejbližšího shluku
                groups[nearestGroupIndex].AddCity(city);
            }
        }

        #endregion

        #region UI Updates

        /// <summary>
        /// Aktualizuje všechny komponenty UI
        /// </summary>
        private void UpdateUI()
        {
            // Aktualizace ListBoxu se shluky
            ListBoxGroups.Items.Clear();
            foreach (Group group in groups)
            {
                ListBoxGroups.Items.Add(group);
            }

            // Aktualizace min/max labelů
            UpdateMinMaxLabels();

            // Překreslení panelu
            PanelMap.Refresh();

            // Vymazání detailních informací pokud nejsou shluky
            if (groups.Count == 0)
            {
                LabelDetail.Text = "Žádná data k zobrazení.\nNačtěte soubor nebo přidejte města ručně.";
            }
        }

        /// <summary>
        /// Aktualizuje labely zobrazující oblasti s min/max procentem nakažených
        /// </summary>
        private void UpdateMinMaxLabels()
        {
            if (groups.Count == 0)
            {
                LabelMinMax.Text = "Nejnižší: ---\nNejvyšší: ---";
                return;
            }

            // Najdeme shluk s minimálním a maximálním % nakažených
            Group minGroup = groups[0];
            Group maxGroup = groups[0];

            foreach (Group group in groups)
            {
                if (group.GetInfectionRate() < minGroup.GetInfectionRate())
                    minGroup = group;
                if (group.GetInfectionRate() > maxGroup.GetInfectionRate())
                    maxGroup = group;
            }

            LabelMinMax.Text = $"Nejnižší nakažení:\n{minGroup.Cities[0].Name} ({minGroup.GetInfectionRate():F2}%)\n\n" +
                              $"Nejvyšší nakažení:\n{maxGroup.Cities[0].Name} ({maxGroup.GetInfectionRate():F2}%)";
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Vykreslení mapy se shluky
        /// </summary>
        private void PanelMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (groups.Count == 0)
            {
                // Zobrazíme info, že nejsou data
                Font font = new Font("Arial", 12);
                string message = "Žádná data k zobrazení";
                SizeF size = g.MeasureString(message, font);
                g.DrawString(message, font, Brushes.Gray,
                    (PanelMap.Width - size.Width) / 2,
                    (PanelMap.Height - size.Height) / 2);
                return;
            }

            // Vykreslení shluků jako kruhů
            foreach (Group group in groups)
            {
                SolidBrush brush = new SolidBrush(group.Color);
                g.FillEllipse(brush, group.GetArea());

                // Pokud je shluk vybraný, zvýrazníme ho černým okrajem
                if (group == selectedGroup)
                {
                    Pen highlightPen = new Pen(Color.Black, 3);
                    g.DrawEllipse(highlightPen, group.GetArea());
                }

                // Vykreslíme název krajského města uprostřed kruhu
                string label = group.Cities[0].Name;
                Font labelFont = new Font("Arial", 9, FontStyle.Bold);
                SizeF labelSize = g.MeasureString(label, labelFont);
                g.DrawString(label, labelFont, Brushes.Black,
                    group.Centroid.X - labelSize.Width / 2,
                    group.Centroid.Y - labelSize.Height / 2);
            }
        }

        /// <summary>
        /// Kliknutí na panel - výběr shluku
        /// </summary>
        private void PanelMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (groups.Count == 0) return;

            // Hledáme shluk, na který uživatel kliknul
            Group clickedGroup = null;
            foreach (Group group in groups)
            {
                if (group.IsInCluster(e.Location))
                {
                    clickedGroup = group;
                    break;
                }
            }

            if (clickedGroup != null)
            {
                selectedGroup = clickedGroup;
                LabelDetail.Text = clickedGroup.GetDetailInfo();

                // Synchronizace s ListBoxem
                ListBoxGroups.SelectedItem = clickedGroup;

                PanelMap.Refresh();
            }
            else
            {
                // Kliknutí mimo shluk - zrušení výběru
                selectedGroup = null;
                LabelDetail.Text = "Klikněte na shluk pro zobrazení detailů.";
                ListBoxGroups.SelectedIndex = -1;
                PanelMap.Refresh();
            }
        }

        /// <summary>
        /// Změna výběru v ListBoxu - zobrazení detailů a zvýraznění na mapě
        /// </summary>
        private void ListBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxGroups.SelectedIndex >= 0)
            {
                selectedGroup = (Group)ListBoxGroups.SelectedItem;
                LabelDetail.Text = selectedGroup.GetDetailInfo();
                PanelMap.Refresh();
            }
        }

        #endregion
    }
}
