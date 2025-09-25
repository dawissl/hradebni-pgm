namespace _02_GenerovanePole
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
            NumArrSize = new NumericUpDown();
            label1 = new Label();
            BtnGenerate = new Button();
            label2 = new Label();
            LblArray = new Label();
            LblResult = new Label();
            label4 = new Label();
            BtnSum = new Button();
            BtnMul = new Button();
            BtnMaxMin = new Button();
            ((System.ComponentModel.ISupportInitialize)NumArrSize).BeginInit();
            SuspendLayout();
            // 
            // NumArrSize
            // 
            NumArrSize.Font = new Font("Segoe UI", 15.75F);
            NumArrSize.Location = new Point(169, 28);
            NumArrSize.Name = "NumArrSize";
            NumArrSize.Size = new Size(120, 35);
            NumArrSize.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(130, 30);
            label1.TabIndex = 1;
            label1.Text = "Velikost pole";
            // 
            // BtnGenerate
            // 
            BtnGenerate.Font = new Font("Segoe UI", 15.75F);
            BtnGenerate.Location = new Point(33, 69);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(245, 64);
            BtnGenerate.TabIndex = 2;
            BtnGenerate.Text = "Generuj pole";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(33, 151);
            label2.Name = "label2";
            label2.Size = new Size(191, 30);
            label2.TabIndex = 3;
            label2.Text = "Vygenerované pole";
            // 
            // LblArray
            // 
            LblArray.BorderStyle = BorderStyle.Fixed3D;
            LblArray.Font = new Font("Segoe UI", 15.75F);
            LblArray.Location = new Point(34, 199);
            LblArray.Name = "LblArray";
            LblArray.Size = new Size(244, 64);
            LblArray.TabIndex = 4;
            // 
            // LblResult
            // 
            LblResult.BorderStyle = BorderStyle.Fixed3D;
            LblResult.Font = new Font("Segoe UI", 15.75F);
            LblResult.Location = new Point(357, 263);
            LblResult.Name = "LblResult";
            LblResult.Size = new Size(244, 64);
            LblResult.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.Location = new Point(356, 233);
            label4.Name = "label4";
            label4.Size = new Size(76, 30);
            label4.TabIndex = 5;
            label4.Text = "Výstup";
            // 
            // BtnSum
            // 
            BtnSum.Enabled = false;
            BtnSum.Font = new Font("Segoe UI", 15.75F);
            BtnSum.Location = new Point(356, 11);
            BtnSum.Name = "BtnSum";
            BtnSum.Size = new Size(245, 64);
            BtnSum.TabIndex = 7;
            BtnSum.Text = "Suma hodnot";
            BtnSum.UseVisualStyleBackColor = true;
            BtnSum.Click += BtnSum_Click;
            // 
            // BtnMul
            // 
            BtnMul.Enabled = false;
            BtnMul.Font = new Font("Segoe UI", 15.75F);
            BtnMul.Location = new Point(356, 81);
            BtnMul.Name = "BtnMul";
            BtnMul.Size = new Size(245, 64);
            BtnMul.TabIndex = 8;
            BtnMul.Text = "Součin hodnot";
            BtnMul.UseVisualStyleBackColor = true;
            BtnMul.Click += BtnMul_Click;
            // 
            // BtnMaxMin
            // 
            BtnMaxMin.Enabled = false;
            BtnMaxMin.Font = new Font("Segoe UI", 15.75F);
            BtnMaxMin.Location = new Point(356, 151);
            BtnMaxMin.Name = "BtnMaxMin";
            BtnMaxMin.Size = new Size(245, 64);
            BtnMaxMin.TabIndex = 9;
            BtnMaxMin.Text = "Maximum a minimum";
            BtnMaxMin.UseVisualStyleBackColor = true;
            BtnMaxMin.Click += BtnMaxMin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 348);
            Controls.Add(BtnMaxMin);
            Controls.Add(BtnMul);
            Controls.Add(BtnSum);
            Controls.Add(LblResult);
            Controls.Add(label4);
            Controls.Add(LblArray);
            Controls.Add(label2);
            Controls.Add(BtnGenerate);
            Controls.Add(label1);
            Controls.Add(NumArrSize);
            Name = "Form1";
            Text = "02_GenerovanePole";
            ((System.ComponentModel.ISupportInitialize)NumArrSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown NumArrSize;
        private Label label1;
        private Button BtnGenerate;
        private Label label2;
        private Label LblArray;
        private Label LblResult;
        private Label label4;
        private Button BtnSum;
        private Button BtnMul;
        private Button BtnMaxMin;
    }
}