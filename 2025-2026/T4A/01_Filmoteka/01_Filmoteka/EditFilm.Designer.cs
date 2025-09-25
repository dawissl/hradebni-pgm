namespace _01_Filmoteka
{
    partial class EditFilm
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
            BtnSave = new Button();
            TxtRating = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtNote = new TextBox();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.Font = new Font("Segoe UI", 18F);
            BtnSave.Location = new Point(58, 168);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(169, 75);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "Uložit";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // TxtRating
            // 
            TxtRating.Font = new Font("Segoe UI", 18F);
            TxtRating.Location = new Point(217, 48);
            TxtRating.Name = "TxtRating";
            TxtRating.Size = new Size(100, 39);
            TxtRating.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(58, 55);
            label1.Name = "label1";
            label1.Size = new Size(131, 32);
            label1.TabIndex = 2;
            label1.Text = "Hodnocení";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(58, 106);
            label2.Name = "label2";
            label2.Size = new Size(124, 32);
            label2.TabIndex = 4;
            label2.Text = "poznámka";
            // 
            // TxtNote
            // 
            TxtNote.Font = new Font("Segoe UI", 18F);
            TxtNote.Location = new Point(201, 99);
            TxtNote.Name = "TxtNote";
            TxtNote.Size = new Size(561, 39);
            TxtNote.TabIndex = 3;
            // 
            // EditFilm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 268);
            Controls.Add(label2);
            Controls.Add(TxtNote);
            Controls.Add(label1);
            Controls.Add(TxtRating);
            Controls.Add(BtnSave);
            Name = "EditFilm";
            Text = "EditFilm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSave;
        private TextBox TxtRating;
        private Label label1;
        private Label label2;
        private TextBox TxtNote;
    }
}