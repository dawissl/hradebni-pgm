namespace _01_AnalyzaCisla
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
            TxtNum = new TextBox();
            label1 = new Label();
            BtnAnalyze = new Button();
            label2 = new Label();
            LblVystup = new Label();
            SuspendLayout();
            // 
            // TxtNum
            // 
            TxtNum.Font = new Font("Segoe UI", 18F);
            TxtNum.Location = new Point(187, 14);
            TxtNum.Name = "TxtNum";
            TxtNum.Size = new Size(100, 39);
            TxtNum.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(148, 32);
            label1.TabIndex = 1;
            label1.Text = "Vstupní číslo";
            // 
            // BtnAnalyze
            // 
            BtnAnalyze.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnAnalyze.Location = new Point(22, 75);
            BtnAnalyze.Name = "BtnAnalyze";
            BtnAnalyze.Size = new Size(265, 52);
            BtnAnalyze.TabIndex = 2;
            BtnAnalyze.Text = "Analyzuj";
            BtnAnalyze.UseVisualStyleBackColor = true;
            BtnAnalyze.Click += BtnAnalyze_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(22, 141);
            label2.Name = "label2";
            label2.Size = new Size(101, 32);
            label2.TabIndex = 3;
            label2.Text = "Analýza:";
            // 
            // LblVystup
            // 
            LblVystup.BorderStyle = BorderStyle.Fixed3D;
            LblVystup.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblVystup.Location = new Point(22, 185);
            LblVystup.Name = "LblVystup";
            LblVystup.Size = new Size(265, 215);
            LblVystup.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 450);
            Controls.Add(LblVystup);
            Controls.Add(label2);
            Controls.Add(BtnAnalyze);
            Controls.Add(label1);
            Controls.Add(TxtNum);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtNum;
        private Label label1;
        private Button BtnAnalyze;
        private Label label2;
        private Label LblVystup;
    }
}