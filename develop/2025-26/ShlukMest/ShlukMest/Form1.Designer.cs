namespace ShlukMest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuStrip = new MenuStrip();
            MenuSoubor = new ToolStripMenuItem();
            MenuNacistSoubor = new ToolStripMenuItem();
            MenuPridatMesto = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            MenuReset = new ToolStripMenuItem();
            MenuNapoveda = new ToolStripMenuItem();
            MenuOAutorovi = new ToolStripMenuItem();
            ListBoxGroups = new ListBox();
            PanelMap = new Panel();
            LabelDetail = new Label();
            LabelMinMax = new Label();
            GroupBoxShluky = new GroupBox();
            GroupBoxMapa = new GroupBox();
            GroupBoxDetail = new GroupBox();
            GroupBoxStatistiky = new GroupBox();
            MenuStrip.SuspendLayout();
            GroupBoxShluky.SuspendLayout();
            GroupBoxMapa.SuspendLayout();
            GroupBoxDetail.SuspendLayout();
            GroupBoxStatistiky.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { MenuSoubor, MenuNapoveda });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(970, 24);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "menuStrip1";
            // 
            // MenuSoubor
            // 
            MenuSoubor.DropDownItems.AddRange(new ToolStripItem[] { MenuNacistSoubor, MenuPridatMesto, toolStripSeparator1, MenuReset });
            MenuSoubor.Name = "MenuSoubor";
            MenuSoubor.Size = new Size(57, 20);
            MenuSoubor.Text = "Soubor";
            // 
            // MenuNacistSoubor
            // 
            MenuNacistSoubor.Name = "MenuNacistSoubor";
            MenuNacistSoubor.Size = new Size(180, 22);
            MenuNacistSoubor.Text = "Načíst soubor...";
            MenuNacistSoubor.Click += MenuNacistSoubor_Click;
            // 
            // MenuPridatMesto
            // 
            MenuPridatMesto.Name = "MenuPridatMesto";
            MenuPridatMesto.Size = new Size(180, 22);
            MenuPridatMesto.Text = "Přidat město...";
            MenuPridatMesto.Click += MenuPridatMesto_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // MenuReset
            // 
            MenuReset.Name = "MenuReset";
            MenuReset.Size = new Size(180, 22);
            MenuReset.Text = "Reset aplikace";
            MenuReset.Click += MenuReset_Click;
            // 
            // MenuNapoveda
            // 
            MenuNapoveda.DropDownItems.AddRange(new ToolStripItem[] { MenuOAutorovi });
            MenuNapoveda.Name = "MenuNapoveda";
            MenuNapoveda.Size = new Size(73, 20);
            MenuNapoveda.Text = "Nápověda";
            // 
            // MenuOAutorovi
            // 
            MenuOAutorovi.Name = "MenuOAutorovi";
            MenuOAutorovi.Size = new Size(180, 22);
            MenuOAutorovi.Text = "O autorovi";
            MenuOAutorovi.Click += MenuOAutorovi_Click;
            // 
            // ListBoxGroups
            // 
            ListBoxGroups.Dock = DockStyle.Fill;
            ListBoxGroups.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ListBoxGroups.FormattingEnabled = true;
            ListBoxGroups.ItemHeight = 16;
            ListBoxGroups.Location = new Point(3, 19);
            ListBoxGroups.Name = "ListBoxGroups";
            ListBoxGroups.Size = new Size(294, 296);
            ListBoxGroups.TabIndex = 1;
            ListBoxGroups.SelectedIndexChanged += ListBoxGroups_SelectedIndexChanged;
            // 
            // PanelMap
            // 
            PanelMap.BackColor = Color.White;
            PanelMap.BorderStyle = BorderStyle.FixedSingle;
            PanelMap.Dock = DockStyle.Fill;
            PanelMap.Location = new Point(3, 19);
            PanelMap.Name = "PanelMap";
            PanelMap.Size = new Size(634, 296);
            PanelMap.TabIndex = 2;
            PanelMap.Paint += PanelMap_Paint;
            PanelMap.MouseDown += PanelMap_MouseDown;
            // 
            // LabelDetail
            // 
            LabelDetail.Dock = DockStyle.Fill;
            LabelDetail.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LabelDetail.Location = new Point(3, 19);
            LabelDetail.Name = "LabelDetail";
            LabelDetail.Size = new Size(634, 205);
            LabelDetail.TabIndex = 3;
            LabelDetail.Text = "Klikněte na shluk pro zobrazení detailů.";
            // 
            // LabelMinMax
            // 
            LabelMinMax.Dock = DockStyle.Fill;
            LabelMinMax.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LabelMinMax.Location = new Point(3, 19);
            LabelMinMax.Name = "LabelMinMax";
            LabelMinMax.Size = new Size(294, 208);
            LabelMinMax.TabIndex = 4;
            LabelMinMax.Text = "Nejnižší: ---\r\nNejvyšší: ---";
            // 
            // GroupBoxShluky
            // 
            GroupBoxShluky.Controls.Add(ListBoxGroups);
            GroupBoxShluky.Location = new Point(12, 37);
            GroupBoxShluky.Name = "GroupBoxShluky";
            GroupBoxShluky.Size = new Size(300, 318);
            GroupBoxShluky.TabIndex = 5;
            GroupBoxShluky.TabStop = false;
            GroupBoxShluky.Text = "Shluky měst";
            // 
            // GroupBoxMapa
            // 
            GroupBoxMapa.Controls.Add(PanelMap);
            GroupBoxMapa.Location = new Point(318, 37);
            GroupBoxMapa.Name = "GroupBoxMapa";
            GroupBoxMapa.Size = new Size(640, 318);
            GroupBoxMapa.TabIndex = 6;
            GroupBoxMapa.TabStop = false;
            GroupBoxMapa.Text = "Mapa shluků (500 × 300 px)";
            // 
            // GroupBoxDetail
            // 
            GroupBoxDetail.Controls.Add(LabelDetail);
            GroupBoxDetail.Location = new Point(318, 361);
            GroupBoxDetail.Name = "GroupBoxDetail";
            GroupBoxDetail.Size = new Size(640, 227);
            GroupBoxDetail.TabIndex = 7;
            GroupBoxDetail.TabStop = false;
            GroupBoxDetail.Text = "Detail vybraného shluku";
            // 
            // GroupBoxStatistiky
            // 
            GroupBoxStatistiky.Controls.Add(LabelMinMax);
            GroupBoxStatistiky.Location = new Point(9, 361);
            GroupBoxStatistiky.Name = "GroupBoxStatistiky";
            GroupBoxStatistiky.Size = new Size(300, 230);
            GroupBoxStatistiky.TabIndex = 8;
            GroupBoxStatistiky.TabStop = false;
            GroupBoxStatistiky.Text = "Statistiky nakažení";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 603);
            Controls.Add(GroupBoxStatistiky);
            Controls.Add(GroupBoxDetail);
            Controls.Add(GroupBoxMapa);
            Controls.Add(GroupBoxShluky);
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vizualizace shluků měst České republiky";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            GroupBoxShluky.ResumeLayout(false);
            GroupBoxMapa.ResumeLayout(false);
            GroupBoxDetail.ResumeLayout(false);
            GroupBoxStatistiky.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem MenuSoubor;
        private ToolStripMenuItem MenuNacistSoubor;
        private ToolStripMenuItem MenuPridatMesto;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem MenuReset;
        private ToolStripMenuItem MenuNapoveda;
        private ToolStripMenuItem MenuOAutorovi;
        private ListBox ListBoxGroups;
        private Panel PanelMap;
        private Label LabelDetail;
        private Label LabelMinMax;
        private GroupBox GroupBoxShluky;
        private GroupBox GroupBoxMapa;
        private GroupBox GroupBoxDetail;
        private GroupBox GroupBoxStatistiky;
    }
}
