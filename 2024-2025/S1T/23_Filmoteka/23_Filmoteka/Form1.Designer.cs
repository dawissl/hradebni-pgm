namespace _23_Filmoteka
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
            FilmList = new ListBox();
            TxtNazev = new TextBox();
            TxtRezie = new TextBox();
            NumHodnocení = new NumericUpDown();
            label1 = new Label();
            BtnPridat = new Button();
            ComboKategorie = new ComboBox();
            label2 = new Label();
            BtnOdstran = new Button();
            label3 = new Label();
            LblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)NumHodnocení).BeginInit();
            SuspendLayout();
            // 
            // FilmList
            // 
            FilmList.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            FilmList.FormattingEnabled = true;
            FilmList.ItemHeight = 25;
            FilmList.Location = new Point(22, 12);
            FilmList.Name = "FilmList";
            FilmList.Size = new Size(285, 404);
            FilmList.TabIndex = 0;
            FilmList.SelectedIndexChanged += FilmList_SelectedIndexChanged_1;
            // 
            // TxtNazev
            // 
            TxtNazev.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TxtNazev.Location = new Point(325, 26);
            TxtNazev.Name = "TxtNazev";
            TxtNazev.PlaceholderText = "Název";
            TxtNazev.Size = new Size(228, 39);
            TxtNazev.TabIndex = 1;
            // 
            // TxtRezie
            // 
            TxtRezie.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TxtRezie.Location = new Point(325, 86);
            TxtRezie.Name = "TxtRezie";
            TxtRezie.PlaceholderText = "Režie";
            TxtRezie.Size = new Size(228, 39);
            TxtRezie.TabIndex = 2;
            // 
            // NumHodnocení
            // 
            NumHodnocení.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NumHodnocení.Location = new Point(325, 171);
            NumHodnocení.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumHodnocení.Name = "NumHodnocení";
            NumHodnocení.Size = new Size(228, 39);
            NumHodnocení.TabIndex = 3;
            NumHodnocení.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(325, 143);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 4;
            label1.Text = "Hodnocení (%)";
            // 
            // BtnPridat
            // 
            BtnPridat.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnPridat.Location = new Point(325, 296);
            BtnPridat.Name = "BtnPridat";
            BtnPridat.Size = new Size(228, 53);
            BtnPridat.TabIndex = 5;
            BtnPridat.Text = "Přidat položku";
            BtnPridat.UseVisualStyleBackColor = true;
            BtnPridat.Click += BtnPridat_Click_1;
            // 
            // ComboKategorie
            // 
            ComboKategorie.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ComboKategorie.FormattingEnabled = true;
            ComboKategorie.Items.AddRange(new object[] { "Nezařazené", "Komedie", "Horor", "Dokument", "Sci-Fi" });
            ComboKategorie.Location = new Point(325, 241);
            ComboKategorie.Name = "ComboKategorie";
            ComboKategorie.Size = new Size(228, 40);
            ComboKategorie.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(325, 213);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 7;
            label2.Text = "Žánr";
            // 
            // BtnOdstran
            // 
            BtnOdstran.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnOdstran.Location = new Point(325, 370);
            BtnOdstran.Name = "BtnOdstran";
            BtnOdstran.Size = new Size(228, 53);
            BtnOdstran.TabIndex = 8;
            BtnOdstran.Text = "Smazat položku";
            BtnOdstran.UseVisualStyleBackColor = true;
            BtnOdstran.Click += BtnOdstran_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(568, 26);
            label3.Name = "label3";
            label3.Size = new Size(132, 25);
            label3.TabIndex = 9;
            label3.Text = "Podrobné info";
            // 
            // LblInfo
            // 
            LblInfo.BorderStyle = BorderStyle.Fixed3D;
            LblInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblInfo.Location = new Point(568, 68);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(228, 348);
            LblInfo.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 450);
            Controls.Add(LblInfo);
            Controls.Add(label3);
            Controls.Add(BtnOdstran);
            Controls.Add(label2);
            Controls.Add(ComboKategorie);
            Controls.Add(BtnPridat);
            Controls.Add(label1);
            Controls.Add(NumHodnocení);
            Controls.Add(TxtRezie);
            Controls.Add(TxtNazev);
            Controls.Add(FilmList);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumHodnocení).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox FilmList;
        private TextBox TxtNazev;
        private TextBox TxtRezie;
        private NumericUpDown NumHodnocení;
        private Label label1;
        private Button BtnPridat;
        private ComboBox ComboKategorie;
        private Label label2;
        private Button BtnOdstran;
        private Label label3;
        private Label LblInfo;
    }
}