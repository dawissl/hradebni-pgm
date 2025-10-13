namespace _03_ZamestanciSestavy
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
            ListEmployees = new ListBox();
            BtnGenerateRandom = new Button();
            label1 = new Label();
            LblOutput = new Label();
            BtnHours = new Button();
            BtnChiefs = new Button();
            BtnOverAverage = new Button();
            BtnOverall = new Button();
            SuspendLayout();
            // 
            // ListEmployees
            // 
            ListEmployees.FormattingEnabled = true;
            ListEmployees.ItemHeight = 15;
            ListEmployees.Location = new Point(26, 12);
            ListEmployees.Name = "ListEmployees";
            ListEmployees.Size = new Size(288, 394);
            ListEmployees.TabIndex = 0;
            // 
            // BtnGenerateRandom
            // 
            BtnGenerateRandom.Location = new Point(26, 412);
            BtnGenerateRandom.Name = "BtnGenerateRandom";
            BtnGenerateRandom.Size = new Size(203, 36);
            BtnGenerateRandom.TabIndex = 1;
            BtnGenerateRandom.Text = "Vygeneruj náhodné data";
            BtnGenerateRandom.UseVisualStyleBackColor = true;
            BtnGenerateRandom.Click += BtnGenerateRandom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(514, 14);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 2;
            label1.Text = "Výstup";
            // 
            // LblOutput
            // 
            LblOutput.BorderStyle = BorderStyle.Fixed3D;
            LblOutput.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblOutput.Location = new Point(514, 53);
            LblOutput.Name = "LblOutput";
            LblOutput.Size = new Size(350, 372);
            LblOutput.TabIndex = 3;
            // 
            // BtnHours
            // 
            BtnHours.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnHours.Location = new Point(350, 53);
            BtnHours.Name = "BtnHours";
            BtnHours.Size = new Size(143, 63);
            BtnHours.TabIndex = 4;
            BtnHours.Text = "Odpracované hodiny";
            BtnHours.UseVisualStyleBackColor = true;
            BtnHours.Click += BtnHours_Click;
            // 
            // BtnChiefs
            // 
            BtnChiefs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnChiefs.Location = new Point(350, 122);
            BtnChiefs.Name = "BtnChiefs";
            BtnChiefs.Size = new Size(143, 63);
            BtnChiefs.TabIndex = 5;
            BtnChiefs.Text = "Vedoucí pracovníci";
            BtnChiefs.UseVisualStyleBackColor = true;
            BtnChiefs.Click += BtnChiefs_Click;
            // 
            // BtnOverAverage
            // 
            BtnOverAverage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnOverAverage.Location = new Point(350, 191);
            BtnOverAverage.Name = "BtnOverAverage";
            BtnOverAverage.Size = new Size(143, 63);
            BtnOverAverage.TabIndex = 6;
            BtnOverAverage.Text = "Nadprůměrní pracovníci";
            BtnOverAverage.UseVisualStyleBackColor = true;
            BtnOverAverage.Click += BtnOverAverage_Click;
            // 
            // BtnOverall
            // 
            BtnOverall.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnOverall.Location = new Point(350, 260);
            BtnOverall.Name = "BtnOverall";
            BtnOverall.Size = new Size(143, 63);
            BtnOverall.TabIndex = 7;
            BtnOverall.Text = "Sestava souhrn";
            BtnOverall.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 479);
            Controls.Add(BtnOverall);
            Controls.Add(BtnOverAverage);
            Controls.Add(BtnChiefs);
            Controls.Add(BtnHours);
            Controls.Add(LblOutput);
            Controls.Add(label1);
            Controls.Add(BtnGenerateRandom);
            Controls.Add(ListEmployees);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListEmployees;
        private Button BtnGenerateRandom;
        private Label label1;
        private Label LblOutput;
        private Button BtnHours;
        private Button BtnChiefs;
        private Button BtnOverAverage;
        private Button BtnOverall;
    }
}
