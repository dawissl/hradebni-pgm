namespace _06_ObrazoveUpravy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PicDefault = new PictureBox();
            PicEdit = new PictureBox();
            menuStrip1 = new MenuStrip();
            souborToolStripMenuItem = new ToolStripMenuItem();
            otevřítToolStripMenuItem = new ToolStripMenuItem();
            uložitToolStripMenuItem = new ToolStripMenuItem();
            konecToolStripMenuItem = new ToolStripMenuItem();
            přemístitToolStripMenuItem = new ToolStripMenuItem();
            editaceToolStripMenuItem = new ToolStripMenuItem();
            prahováníToolStripMenuItem = new ToolStripMenuItem();
            šumSůlAPepřToolStripMenuItem = new ToolStripMenuItem();
            mediánovýFiltrToolStripMenuItem = new ToolStripMenuItem();
            zesvětlitztmavitToolStripMenuItem = new ToolStripMenuItem();
            obarvitToolStripMenuItem = new ToolStripMenuItem();
            rotaceToolStripMenuItem = new ToolStripMenuItem();
            gaussůvFiltrToolStripMenuItem = new ToolStripMenuItem();
            detekceHranToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)PicDefault).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicEdit).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // PicDefault
            // 
            PicDefault.Location = new Point(12, 58);
            PicDefault.Name = "PicDefault";
            PicDefault.Size = new Size(380, 380);
            PicDefault.TabIndex = 1;
            PicDefault.TabStop = false;
            // 
            // PicEdit
            // 
            PicEdit.Location = new Point(408, 58);
            PicEdit.Name = "PicEdit";
            PicEdit.Size = new Size(380, 380);
            PicEdit.TabIndex = 2;
            PicEdit.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            menuStrip1.Items.AddRange(new ToolStripItem[] { souborToolStripMenuItem, editaceToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 38);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            souborToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { otevřítToolStripMenuItem, uložitToolStripMenuItem, konecToolStripMenuItem, přemístitToolStripMenuItem });
            souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            souborToolStripMenuItem.Size = new Size(91, 34);
            souborToolStripMenuItem.Text = "Soubor";
            // 
            // otevřítToolStripMenuItem
            // 
            otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            otevřítToolStripMenuItem.Size = new Size(167, 34);
            otevřítToolStripMenuItem.Text = "Otevřít";
            otevřítToolStripMenuItem.Click += otevřítToolStripMenuItem_Click;
            // 
            // uložitToolStripMenuItem
            // 
            uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
            uložitToolStripMenuItem.Size = new Size(167, 34);
            uložitToolStripMenuItem.Text = "Uložit";
            uložitToolStripMenuItem.Click += uložitToolStripMenuItem_Click;
            // 
            // konecToolStripMenuItem
            // 
            konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            konecToolStripMenuItem.Size = new Size(167, 34);
            konecToolStripMenuItem.Text = "Konec";
            // 
            // přemístitToolStripMenuItem
            // 
            přemístitToolStripMenuItem.Name = "přemístitToolStripMenuItem";
            přemístitToolStripMenuItem.Size = new Size(167, 34);
            přemístitToolStripMenuItem.Text = "Přemístit";
            přemístitToolStripMenuItem.Click += přemístitToolStripMenuItem_Click;
            // 
            // editaceToolStripMenuItem
            // 
            editaceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prahováníToolStripMenuItem, šumSůlAPepřToolStripMenuItem, mediánovýFiltrToolStripMenuItem, zesvětlitztmavitToolStripMenuItem, obarvitToolStripMenuItem, rotaceToolStripMenuItem, gaussůvFiltrToolStripMenuItem, detekceHranToolStripMenuItem });
            editaceToolStripMenuItem.Name = "editaceToolStripMenuItem";
            editaceToolStripMenuItem.Size = new Size(92, 34);
            editaceToolStripMenuItem.Text = "Editace";
            // 
            // prahováníToolStripMenuItem
            // 
            prahováníToolStripMenuItem.Name = "prahováníToolStripMenuItem";
            prahováníToolStripMenuItem.Size = new Size(239, 34);
            prahováníToolStripMenuItem.Text = "Prahování";
            prahováníToolStripMenuItem.Click += prahováníToolStripMenuItem_Click;
            // 
            // šumSůlAPepřToolStripMenuItem
            // 
            šumSůlAPepřToolStripMenuItem.Name = "šumSůlAPepřToolStripMenuItem";
            šumSůlAPepřToolStripMenuItem.Size = new Size(239, 34);
            šumSůlAPepřToolStripMenuItem.Text = "Šum sůl a pepř";
            šumSůlAPepřToolStripMenuItem.Click += šumSůlAPepřToolStripMenuItem_Click;
            // 
            // mediánovýFiltrToolStripMenuItem
            // 
            mediánovýFiltrToolStripMenuItem.Name = "mediánovýFiltrToolStripMenuItem";
            mediánovýFiltrToolStripMenuItem.Size = new Size(239, 34);
            mediánovýFiltrToolStripMenuItem.Text = "Mediánový filtr";
            mediánovýFiltrToolStripMenuItem.Click += mediánovýFiltrToolStripMenuItem_Click;
            // 
            // zesvětlitztmavitToolStripMenuItem
            // 
            zesvětlitztmavitToolStripMenuItem.Name = "zesvětlitztmavitToolStripMenuItem";
            zesvětlitztmavitToolStripMenuItem.Size = new Size(239, 34);
            zesvětlitztmavitToolStripMenuItem.Text = "Zesvětlit/ztmavit";
            zesvětlitztmavitToolStripMenuItem.Click += zesvětlitztmavitToolStripMenuItem_Click;
            // 
            // obarvitToolStripMenuItem
            // 
            obarvitToolStripMenuItem.Name = "obarvitToolStripMenuItem";
            obarvitToolStripMenuItem.Size = new Size(239, 34);
            obarvitToolStripMenuItem.Text = "Odbarvit";
            obarvitToolStripMenuItem.Click += obarvitToolStripMenuItem_Click;
            // 
            // rotaceToolStripMenuItem
            // 
            rotaceToolStripMenuItem.Name = "rotaceToolStripMenuItem";
            rotaceToolStripMenuItem.Size = new Size(239, 34);
            rotaceToolStripMenuItem.Text = "Rotace";
            rotaceToolStripMenuItem.Click += rotaceToolStripMenuItem_Click;
            // 
            // gaussůvFiltrToolStripMenuItem
            // 
            gaussůvFiltrToolStripMenuItem.Name = "gaussůvFiltrToolStripMenuItem";
            gaussůvFiltrToolStripMenuItem.Size = new Size(239, 34);
            gaussůvFiltrToolStripMenuItem.Text = "Gaussův filtr";
            gaussůvFiltrToolStripMenuItem.Click += gaussůvFiltrToolStripMenuItem_Click;
            // 
            // detekceHranToolStripMenuItem
            // 
            detekceHranToolStripMenuItem.Name = "detekceHranToolStripMenuItem";
            detekceHranToolStripMenuItem.Size = new Size(239, 34);
            detekceHranToolStripMenuItem.Text = "Detekce hran";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PicEdit);
            Controls.Add(PicDefault);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PicDefault).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicEdit).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PicDefault;
        private PictureBox PicEdit;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem souborToolStripMenuItem;
        private ToolStripMenuItem otevřítToolStripMenuItem;
        private ToolStripMenuItem uložitToolStripMenuItem;
        private ToolStripMenuItem konecToolStripMenuItem;
        private ToolStripMenuItem editaceToolStripMenuItem;
        private ToolStripMenuItem prahováníToolStripMenuItem;
        private ToolStripMenuItem šumSůlAPepřToolStripMenuItem;
        private ToolStripMenuItem mediánovýFiltrToolStripMenuItem;
        private ToolStripMenuItem zesvětlitztmavitToolStripMenuItem;
        private ToolStripMenuItem obarvitToolStripMenuItem;
        private ToolStripMenuItem přemístitToolStripMenuItem;
        private ToolStripMenuItem rotaceToolStripMenuItem;
        private ToolStripMenuItem gaussůvFiltrToolStripMenuItem;
        private ToolStripMenuItem detekceHranToolStripMenuItem;
    }
}
