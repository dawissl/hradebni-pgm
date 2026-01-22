using System.Diagnostics;

namespace ClanManagerWFA
{
    public partial class MainForm : Form
    {
        List<Klan> klany = new List<Klan>();

        ListBox lstKlany;
        TextBox txtNazev, txtPechota, txtJizda, txtArtilerie, txtR, txtG, txtB;
        ComboBox cmbFrakce;
        Button btnAdd, btnRemove, btnLoad, btnSave, btnStrongest, btnRefreshDraw;
        Label lblCount, lblHordaUnits, lblAlianceUnits, lblRatio;
        Panel pnlGraphic;

        public MainForm()
        {
            Text = "Správa klanù – Simulátor frakcí";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;

            InitControls();
            UpdateListBox();
            UpdateStats();
        }

        void InitControls()
        {
            // ListBox
            lstKlany = new ListBox { Location = new Point(10, 10), Size = new Size(450, 480) };
            Controls.Add(lstKlany);

            // Group - vstupy
            var grp = new GroupBox { Text = "Pøidat klan (ruènì)", Location = new Point(470, 10), Size = new Size(500, 220) };
            Controls.Add(grp);

            int labelX = 10, inputX = 120, rowY = 25, step = 30;

            grp.Controls.Add(new Label { Text = "Název:", Location = new Point(labelX, rowY), AutoSize = true });
            txtNazev = new TextBox { Location = new Point(inputX, rowY - 3), Width = 200 }; rowY += step;

            grp.Controls.Add(new Label { Text = "Frakce:", Location = new Point(labelX, rowY), AutoSize = true });
            cmbFrakce = new ComboBox { Location = new Point(inputX, rowY - 3), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFrakce.Items.AddRange(new[] { "Horda", "Aliance" }); cmbFrakce.SelectedIndex = 0; rowY += step;

            grp.Controls.Add(new Label { Text = "Pìchota:", Location = new Point(labelX, rowY), AutoSize = true });
            txtPechota = new TextBox { Location = new Point(inputX, rowY - 3), Width = 80 }; rowY += step;

            grp.Controls.Add(new Label { Text = "Jízda:", Location = new Point(labelX, rowY), AutoSize = true });
            txtJizda = new TextBox { Location = new Point(inputX, rowY - 3), Width = 80 }; rowY += step;

            grp.Controls.Add(new Label { Text = "Artilerie:", Location = new Point(labelX, rowY), AutoSize = true });
            txtArtilerie = new TextBox { Location = new Point(inputX, rowY - 3), Width = 80 }; rowY += step;

            grp.Controls.Add(new Label { Text = "Barva (R-G-B):", Location = new Point(labelX, rowY), AutoSize = true });
            txtR = new TextBox { Location = new Point(inputX, rowY - 3), Width = 45 };
            txtG = new TextBox { Location = new Point(inputX + 50, rowY - 3), Width = 45 };
            txtB = new TextBox { Location = new Point(inputX + 100, rowY - 3), Width = 45 };
            rowY += step;

            btnAdd = new Button { Text = "Pøidat klan", Location = new Point(inputX, rowY - 3), Width = 120 };
            btnAdd.Click += BtnAdd_Click;
            grp.Controls.AddRange(new Control[] { txtNazev, cmbFrakce, txtPechota, txtJizda, txtArtilerie, txtR, txtG, txtB, btnAdd });

            // Buttons pro naèítání/ukládání/mazání
            btnLoad = new Button { Text = "Naèíst CSV...", Location = new Point(470, 240), Size = new Size(150, 30) };
            btnLoad.Click += BtnLoad_Click;
            btnSave = new Button { Text = "Uložit CSV...", Location = new Point(630, 240), Size = new Size(150, 30) };
            btnSave.Click += BtnSave_Click;
            btnRemove = new Button { Text = "Odstranit vybraný", Location = new Point(470, 280), Size = new Size(150, 30) };
            btnRemove.Click += BtnRemove_Click;
            btnStrongest = new Button { Text = "Nejsilnìjší klan (H/A)", Location = new Point(630, 280), Size = new Size(150, 30) };
            btnStrongest.Click += BtnStrongest_Click;
            btnRefreshDraw = new Button { Text = "Obnovit graf", Location = new Point(790, 240), Size = new Size(150, 70) };
            btnRefreshDraw.Click += (s, e) => pnlGraphic.Invalidate();

            Controls.AddRange(new Control[] { btnLoad, btnSave, btnRemove, btnStrongest, btnRefreshDraw });

            // Statistiky
            lblCount = new Label { Text = "Celkem klanù: 0", Location = new Point(470, 330), AutoSize = true };
            lblHordaUnits = new Label { Text = "Jednotky Horda: 0", Location = new Point(470, 360), AutoSize = true };
            lblAlianceUnits = new Label { Text = "Jednotky Aliance: 0", Location = new Point(470, 390), AutoSize = true };
            lblRatio = new Label { Text = "Pomìr (Horda : Aliance) 0 : 0", Location = new Point(470, 420), AutoSize = true };
            Controls.AddRange(new Control[] { lblCount, lblHordaUnits, lblAlianceUnits, lblRatio });

            // Grafické zobrazení
            var grpGraf = new GroupBox { Text = "Grafické znázornìní (stacked bars)", Location = new Point(470, 460), Size = new Size(500, 170) };
            pnlGraphic = new Panel { Dock = DockStyle.Fill };
            pnlGraphic.Paint += PnlGraphic_Paint;
            grpGraf.Controls.Add(pnlGraphic);
            Controls.Add(grpGraf);

            // Double-click naèíst editaci
            lstKlany.DoubleClick += LstKlany_DoubleClick;
        }

        private void LstKlany_DoubleClick(object sender, EventArgs e)
        {
            if (lstKlany.SelectedIndex < 0) return;
            var k = klany[lstKlany.SelectedIndex];
            // Naplnit formuláø pro rychlou editaci (uživatel mùže zmìnit a znovu kliknout Pøidat -> pøidá novou položku)
            txtNazev.Text = k.Nazev;
            cmbFrakce.SelectedItem = k.Frakce == Frakce.Horda ? "Horda" : "Aliance";
            txtPechota.Text = k.Pechota.ToString();
            txtJizda.Text = k.Jizda.ToString();
            txtArtilerie.Text = k.Artilerie.ToString();
            txtR.Text = k.Barva.R.ToString();
            txtG.Text = k.Barva.G.ToString();
            txtB.Text = k.Barva.B.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Validace a pøidání
            string name = (txtNazev.Text ?? "").Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Název klanu nemùže být prázdný.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPechota.Text.Trim(), out int pechota) || pechota < 0)
            {
                MessageBox.Show("Pìchota musí být celé nezáporné èíslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtJizda.Text.Trim(), out int jizda) || jizda < 0)
            {
                MessageBox.Show("Jízda musí být celé nezáporné èíslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtArtilerie.Text.Trim(), out int artilerie) || artilerie < 0)
            {
                MessageBox.Show("Artilerie musí být celé nezáporné èíslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtR.Text.Trim(), out int r) || r < 0 || r > 255 ||
                !int.TryParse(txtG.Text.Trim(), out int g) || g < 0 || g > 255 ||
                !int.TryParse(txtB.Text.Trim(), out int b) || b < 0 || b > 255)
            {
                MessageBox.Show("Barva musí být 0–255 pro každý kanál R, G i B.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Frakce fr = cmbFrakce.SelectedItem.ToString() == "Horda" ? Frakce.Horda : Frakce.Aliance;

            var k = new Klan
            {
                Nazev = name,
                Frakce = fr,
                Pechota = pechota,
                Jizda = jizda,
                Artilerie = artilerie,
                Barva = Color.FromArgb(r, g, b)
            };

            klany.Add(k);
            UpdateListBox();
            UpdateStats();
            pnlGraphic.Invalidate();

            // Vyèistit pole (nepovinné)
            txtNazev.Clear(); txtPechota.Clear(); txtJizda.Clear(); txtArtilerie.Clear();
            // txtR/G/B ponechat
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int idx = lstKlany.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show("Vyberte nejprve klan v seznamu k odstranìní.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Odstraní pøesnì tu položku, na kterou uživatel klikl
            klany.RemoveAt(idx);
            UpdateListBox();
            UpdateStats();
            pnlGraphic.Invalidate();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "CSV soubor|*.csv;*.txt|Vše|*.*" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    var lines = File.ReadAllLines(ofd.FileName);
                    if (lines.Length == 0) { MessageBox.Show("Soubor je prázdný."); return; }
                    // Oèekáváme záhlaví: Nazev;Frakce;Pechota;Jizda;Artilerie;Barva
                    bool firstIsHeader = lines[0].ToLower().Contains("nazev") && lines[0].Contains(";");
                    int start = firstIsHeader ? 1 : 0;
                    int loaded = 0;
                    for (int i = start; i < lines.Length; i++)
                    {
                        var ln = lines[i].Trim();
                        if (string.IsNullOrEmpty(ln)) continue;
                        var parts = ln.Split(';');
                        if (parts.Length < 6) continue; // pøeskoèit špatné øádky

                        string naz = parts[0].Trim();
                        string frStr = parts[1].Trim();
                        if (!Enum.TryParse<Frakce>(frStr, true, out var fr)) // ignoruje velikost písmen
                        {
                            // pokusíme-li se mapovat "Horda"/"Aliance" (èesky)
                            fr = frStr.Equals("Horda", StringComparison.OrdinalIgnoreCase) ? Frakce.Horda :
                                 frStr.Equals("Aliance", StringComparison.OrdinalIgnoreCase) ? Frakce.Aliance : Frakce.Horda;
                        }
                        if (!int.TryParse(parts[2].Trim(), out int p)) p = 0;
                        if (!int.TryParse(parts[3].Trim(), out int j)) j = 0;
                        if (!int.TryParse(parts[4].Trim(), out int a)) a = 0;

                        // Barva: "R-G-B"
                        var colorPart = parts[5].Trim();
                        Color col = Color.Gray;
                        var colorParts = colorPart.Split('-', StringSplitOptions.RemoveEmptyEntries);
                        if (colorParts.Length == 3 &&
                            int.TryParse(colorParts[0], out int rr) &&
                            int.TryParse(colorParts[1], out int gg) &&
                            int.TryParse(colorParts[2], out int bb) &&
                            rr >= 0 && rr <= 255 && gg >= 0 && gg <= 255 && bb >= 0 && bb <= 255)
                        {
                            col = Color.FromArgb(rr, gg, bb);
                        }

                        var k = new Klan { Nazev = naz, Frakce = fr, Pechota = p, Jizda = j, Artilerie = a, Barva = col };
                        klany.Add(k);
                        loaded++;
                    }
                    UpdateListBox();
                    UpdateStats();
                    pnlGraphic.Invalidate();
                    MessageBox.Show($"Naèteno {loaded} klanù.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chyba pøi naèítání souboru: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV soubor|*.csv", FileName = "klany.csv" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("Nazev;Frakce;Pechota;Jizda;Artilerie;Barva");
                        foreach (var k in klany)
                        {
                            sw.WriteLine($"{k.Nazev};{k.Frakce};{k.Pechota};{k.Jizda};{k.Artilerie};{k.Barva.R}-{k.Barva.G}-{k.Barva.B}");
                        }
                    }
                    MessageBox.Show("Uloženo.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chyba pøi ukládání: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnStrongest_Click(object sender, EventArgs e)
        {
            var horda = klany.Where(k => k.Frakce == Frakce.Horda).ToList();
            var aliance = klany.Where(k => k.Frakce == Frakce.Aliance).ToList();

            string msg = "";
            if (horda.Count == 0) msg += "Horda: žádné klany.\n";
            else
            {
                var maxH = horda.OrderByDescending(k => k.CelkemJednotek).First();
                msg += $"Horda: {maxH.Nazev} ({maxH.CelkemJednotek} jednotek)\n";
            }
            if (aliance.Count == 0) msg += "Aliance: žádné klany.\n";
            else
            {
                var maxA = aliance.OrderByDescending(k => k.CelkemJednotek).First();
                msg += $"Aliance: {maxA.Nazev} ({maxA.CelkemJednotek} jednotek)\n";
            }

            MessageBox.Show(msg, "Nejsilnìjší klany", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateListBox()
        {
            lstKlany.BeginUpdate();
            lstKlany.Items.Clear();
            foreach (var k in klany)
            {
                lstKlany.Items.Add(k.ToString());
            }
            lstKlany.EndUpdate();
        }

        private void UpdateStats()
        {
            lblCount.Text = $"Celkem klanù: {klany.Count}";
            int hordaUnits = klany.Where(k => k.Frakce == Frakce.Horda).Sum(k => k.CelkemJednotek);
            int alianceUnits = klany.Where(k => k.Frakce == Frakce.Aliance).Sum(k => k.CelkemJednotek);
            lblHordaUnits.Text = $"Jednotky Horda: {hordaUnits}";
            lblAlianceUnits.Text = $"Jednotky Aliance: {alianceUnits}";
            lblRatio.Text = $"Pomìr (Horda : Aliance) {hordaUnits} : {alianceUnits}";
        }

        public enum Frakce { Horda, Aliance }

        public class Klan
        {
            public string Nazev { get; set; }
            public Frakce Frakce { get; set; }
            public int Pechota { get; set; }
            public int Jizda { get; set; }
            public int Artilerie { get; set; }
            public Color Barva { get; set; }

            public int CelkemJednotek => Pechota + Jizda + Artilerie;

            public override string ToString()
            {
                return $"{Nazev} ({Frakce}) – {CelkemJednotek} – {Barva.R}-{Barva.G}-{Barva.B}";
            }
        }
        private void PnlGraphic_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            // Rozmìry sloupcù
            int margin = 30;
            int colWidth = 120;
            int gap = 80;
            int xHorda = margin;
            int xAliance = margin + colWidth + gap;
            int top = 20;
            int heightAvailable = pnlGraphic.Height - 2 * top;

            int totalHorda = klany.Where(k => k.Frakce == Frakce.Horda).Sum(k => k.CelkemJednotek);
            int totalAliance = klany.Where(k => k.Frakce == Frakce.Aliance).Sum(k => k.CelkemJednotek);
            int maxTotal = Math.Max(totalHorda, totalAliance);
            if (maxTotal == 0)
            {
                g.DrawString("Žádné jednotky ke zobrazení.", this.Font, Brushes.Black, new PointF(10, 10));
                return;
            }

            // Vykreslíme osu a titulky
            g.DrawString($"Horda ({totalHorda})", this.Font, Brushes.Black, new PointF(xHorda, top + heightAvailable + 5));
            g.DrawString($"Aliance ({totalAliance})", this.Font, Brushes.Black, new PointF(xAliance, top + heightAvailable + 5));

            // Funkce pro vykreslení sloupce: naskládat klany ve frakci
            void DrawStacked(int x, Frakce fr, int totalUnits)
            {
                // poøadí mùže být libovolné; použijeme poøadí v seznamu klanù, filtrace podle frakce
                var frList = klany.Where(k => k.Frakce == fr).ToList();
                int y = top + heightAvailable; // zaèneme ze dna smìrem nahoru
                foreach (var k in frList)
                {
                    int units = k.CelkemJednotek;
                    if (units <= 0) continue;
                    // výška segmentu = pomìr jednotek / maxTotal * heightAvailable (nebo / totalUnits aby bylo relativní vùèi frakci)
                    // lepší: výška podle pomìru vùèi frakci => zobrazí 100% výšku sloupce pro frakci
                    float fractionInFaction = totalUnits == 0 ? 0f : (float)units / totalUnits;
                    int segH = (int)Math.Round(fractionInFaction * heightAvailable);
                    // minimální výška pro viditelnost
                    if (segH < 2) segH = 2;
                    Rectangle segRect = new Rectangle(x, y - segH, colWidth, segH);
                    using (var brush = new SolidBrush(k.Barva))
                    {
                        g.FillRectangle(brush, segRect);
                    }
                    g.DrawRectangle(Pens.Black, segRect);

                    // malý text s názvem klanu pokud se vejde
                    var text = $"{k.Nazev} ({k.CelkemJednotek})";
                    var size = g.MeasureString(text, this.Font);
                    if (size.Height < segRect.Height && size.Width < segRect.Width - 4)
                    {
                        g.DrawString(text, this.Font, Brushes.Black, segRect.X + 4, segRect.Y + 1);
                    }

                    y -= segH;
                }

                // pokud frakce nemá klany, vykreslíme prázdný rámeèek
                if (!frList.Any())
                {
                    Rectangle emptyRect = new Rectangle(x, top, colWidth, heightAvailable);
                    g.DrawRectangle(Pens.Gray, emptyRect);
                    g.DrawString("Žádné klany", this.Font, Brushes.Gray, x + 5, top + heightAvailable / 2 - 8);
                }
            }

            DrawStacked(xHorda, Frakce.Horda, totalHorda);
            DrawStacked(xAliance, Frakce.Aliance, totalAliance);
        }
    }
}
