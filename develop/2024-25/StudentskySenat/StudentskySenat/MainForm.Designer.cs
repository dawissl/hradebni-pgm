namespace StudentskySenat
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuLoadFile;
        private ToolStripMenuItem menuReset;
        private ToolStripMenuItem menuAbout;
        private Label lblResults;
        private Label lblChart;
        private Panel panelChart;
        private Label lblCoalition;
        private Button btnExport;

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuLoadFile = new ToolStripMenuItem();
            menuReset = new ToolStripMenuItem();
            menuAbout = new ToolStripMenuItem();
            lblResults = new Label();
            lblChart = new Label();
            panelChart = new Panel();
            lblCoalition = new Label();
            btnExport = new Button();
            BtnManualAdd = new Button();
            TxtSpolek = new TextBox();
            TxtHlasy = new TextBox();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuFile });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(725, 24);
            menuStrip.TabIndex = 0;
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuLoadFile, menuReset, menuAbout });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(50, 20);
            menuFile.Text = "Menu";
            // 
            // menuLoadFile
            // 
            menuLoadFile.Name = "menuLoadFile";
            menuLoadFile.Size = new Size(180, 22);
            menuLoadFile.Text = "Načíst soubor";
            menuLoadFile.Click += menuLoadFile_Click;
            // 
            // menuReset
            // 
            menuReset.Name = "menuReset";
            menuReset.Size = new Size(180, 22);
            menuReset.Text = "Resetovat";
            menuReset.Click += menuReset_Click;
            // 
            // menuAbout
            // 
            menuAbout.Name = "menuAbout";
            menuAbout.Size = new Size(180, 22);
            menuAbout.Text = "O aplikaci";
            // 
            // lblResults
            // 
            lblResults.BorderStyle = BorderStyle.Fixed3D;
            lblResults.Location = new Point(20, 80);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(368, 200);
            lblResults.TabIndex = 1;
            lblResults.Text = "Výsledky voleb budou zde.";
            // 
            // lblChart
            // 
            lblChart.Location = new Point(411, 55);
            lblChart.Name = "lblChart";
            lblChart.Size = new Size(100, 23);
            lblChart.TabIndex = 2;
            lblChart.Text = "Graf výsledků";
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.White;
            panelChart.BorderStyle = BorderStyle.FixedSingle;
            panelChart.Location = new Point(411, 80);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(300, 200);
            panelChart.TabIndex = 3;
            panelChart.Paint += panelChart_Paint;
            // 
            // lblCoalition
            // 
            lblCoalition.BorderStyle = BorderStyle.Fixed3D;
            lblCoalition.Location = new Point(20, 300);
            lblCoalition.Name = "lblCoalition";
            lblCoalition.Size = new Size(368, 50);
            lblCoalition.TabIndex = 4;
            lblCoalition.Text = "Navržená koalice bude zobrazena zde.";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(411, 300);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 5;
            btnExport.Text = "Exportovat výsledky";
            // 
            // BtnManualAdd
            // 
            BtnManualAdd.Location = new Point(280, 39);
            BtnManualAdd.Name = "BtnManualAdd";
            BtnManualAdd.Size = new Size(108, 29);
            BtnManualAdd.TabIndex = 6;
            BtnManualAdd.Text = "Vložit hlasy";
            BtnManualAdd.UseVisualStyleBackColor = true;
            BtnManualAdd.Click += BtnManualAdd_Click;
            // 
            // TxtSpolek
            // 
            TxtSpolek.Location = new Point(20, 43);
            TxtSpolek.Name = "TxtSpolek";
            TxtSpolek.PlaceholderText = "Název spolku";
            TxtSpolek.Size = new Size(112, 23);
            TxtSpolek.TabIndex = 7;
            // 
            // TxtHlasy
            // 
            TxtHlasy.Location = new Point(147, 43);
            TxtHlasy.Name = "TxtHlasy";
            TxtHlasy.PlaceholderText = "Obdržené hlasy";
            TxtHlasy.Size = new Size(112, 23);
            TxtHlasy.TabIndex = 8;
            // 
            // MainForm
            // 
            ClientSize = new Size(725, 361);
            Controls.Add(TxtHlasy);
            Controls.Add(TxtSpolek);
            Controls.Add(BtnManualAdd);
            Controls.Add(menuStrip);
            Controls.Add(lblResults);
            Controls.Add(lblChart);
            Controls.Add(panelChart);
            Controls.Add(lblCoalition);
            Controls.Add(btnExport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Analýza volebních výsledků";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BtnManualAdd;
        private TextBox TxtSpolek;
        private TextBox TxtHlasy;
    }
}