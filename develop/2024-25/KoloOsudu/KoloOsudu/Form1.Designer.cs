namespace KoloOsudu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstStudenti;
        private System.Windows.Forms.Button btnSpustit;
        private System.Windows.Forms.Button btnNacist;
        private System.Windows.Forms.Label lblVybrany;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkOdebrat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lstStudenti = new ListBox();
            btnSpustit = new Button();
            btnNacist = new Button();
            lblVybrany = new Label();
            timer = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();
            chkOdebrat = new CheckBox();
            SuspendLayout();
            // 
            // lstStudenti
            // 
            lstStudenti.FormattingEnabled = true;
            lstStudenti.ItemHeight = 15;
            lstStudenti.Location = new Point(22, 19);
            lstStudenti.Margin = new Padding(3, 2, 3, 2);
            lstStudenti.Name = "lstStudenti";
            lstStudenti.Size = new Size(176, 214);
            lstStudenti.TabIndex = 0;
            // 
            // btnSpustit
            // 
            btnSpustit.Location = new Point(114, 240);
            btnSpustit.Margin = new Padding(3, 2, 3, 2);
            btnSpustit.Name = "btnSpustit";
            btnSpustit.Size = new Size(83, 22);
            btnSpustit.TabIndex = 2;
            btnSpustit.Text = "Spustit los";
            btnSpustit.UseVisualStyleBackColor = true;
            btnSpustit.Click += btnSpustit_Click;
            // 
            // btnNacist
            // 
            btnNacist.Location = new Point(22, 240);
            btnNacist.Margin = new Padding(3, 2, 3, 2);
            btnNacist.Name = "btnNacist";
            btnNacist.Size = new Size(83, 22);
            btnNacist.TabIndex = 1;
            btnNacist.Text = "Načíst TXT";
            btnNacist.UseVisualStyleBackColor = true;
            btnNacist.Click += btnNacist_Click;
            // 
            // lblVybrany
            // 
            lblVybrany.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVybrany.ForeColor = Color.DarkBlue;
            lblVybrany.Location = new Point(219, 38);
            lblVybrany.Name = "lblVybrany";
            lblVybrany.Size = new Size(350, 60);
            lblVybrany.TabIndex = 3;
            lblVybrany.Text = "Jméno";
            lblVybrany.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Textové soubory|*.txt";
            openFileDialog1.Title = "Vyber soubor se seznamem studentů";
            // 
            // chkOdebrat
            // 
            chkOdebrat.AutoSize = true;
            chkOdebrat.Location = new Point(219, 112);
            chkOdebrat.Margin = new Padding(3, 2, 3, 2);
            chkOdebrat.Name = "chkOdebrat";
            chkOdebrat.Size = new Size(125, 19);
            chkOdebrat.TabIndex = 4;
            chkOdebrat.Text = "Odebrat po výběru";
            chkOdebrat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 286);
            Controls.Add(chkOdebrat);
            Controls.Add(lblVybrany);
            Controls.Add(btnSpustit);
            Controls.Add(btnNacist);
            Controls.Add(lstStudenti);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "🎡 Kolo osudu – Výběr studenta";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
