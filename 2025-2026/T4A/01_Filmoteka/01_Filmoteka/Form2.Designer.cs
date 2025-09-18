namespace _01_Filmoteka
{
    partial class Form2
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
            label2 = new Label();
            txtDirectorDialog = new TextBox();
            label1 = new Label();
            txtNameDialog = new TextBox();
            Btn_AddFilm = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 206);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 10;
            label2.Text = "režiser";
            // 
            // txtDirectorDialog
            // 
            txtDirectorDialog.Location = new Point(106, 242);
            txtDirectorDialog.Name = "txtDirectorDialog";
            txtDirectorDialog.Size = new Size(169, 23);
            txtDirectorDialog.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 117);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 8;
            label1.Text = "nazev";
            // 
            // txtNameDialog
            // 
            txtNameDialog.Location = new Point(106, 153);
            txtNameDialog.Name = "txtNameDialog";
            txtNameDialog.Size = new Size(169, 23);
            txtNameDialog.TabIndex = 7;
            // 
            // Btn_AddFilm
            // 
            Btn_AddFilm.Location = new Point(106, 313);
            Btn_AddFilm.Name = "Btn_AddFilm";
            Btn_AddFilm.Size = new Size(136, 51);
            Btn_AddFilm.TabIndex = 6;
            Btn_AddFilm.Text = "Přidat film";
            Btn_AddFilm.UseVisualStyleBackColor = true;
            Btn_AddFilm.Click += Btn_AddFilm_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 395);
            Controls.Add(label2);
            Controls.Add(txtDirectorDialog);
            Controls.Add(label1);
            Controls.Add(txtNameDialog);
            Controls.Add(Btn_AddFilm);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtDirectorDialog;
        private Label label1;
        private TextBox txtNameDialog;
        private Button Btn_AddFilm;
    }
}