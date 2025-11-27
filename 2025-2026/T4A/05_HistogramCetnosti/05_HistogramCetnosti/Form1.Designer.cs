namespace _05_HistogramCetnosti
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
            TxtInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            NumN = new NumericUpDown();
            BtnGenerate = new Button();
            label3 = new Label();
            LblOutput = new Label();
            PanelOutput = new Panel();
            BtnCompute = new Button();
            ((System.ComponentModel.ISupportInitialize)NumN).BeginInit();
            SuspendLayout();
            // 
            // TxtInput
            // 
            TxtInput.Font = new Font("Segoe UI", 15.75F);
            TxtInput.Location = new Point(183, 6);
            TxtInput.Name = "TxtInput";
            TxtInput.Size = new Size(466, 35);
            TxtInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(165, 30);
            label1.TabIndex = 1;
            label1.Text = "Vstupní hodnoty";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(273, 30);
            label2.TabIndex = 2;
            label2.Text = "Počet generovaných hodnot";
            // 
            // NumN
            // 
            NumN.Font = new Font("Segoe UI", 15.75F);
            NumN.Location = new Point(293, 51);
            NumN.Name = "NumN";
            NumN.Size = new Size(120, 35);
            NumN.TabIndex = 3;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Font = new Font("Segoe UI", 15.75F);
            BtnGenerate.Location = new Point(419, 50);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(230, 37);
            BtnGenerate.TabIndex = 4;
            BtnGenerate.Text = "Generuj vstup";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(12, 171);
            label3.Name = "label3";
            label3.Size = new Size(158, 30);
            label3.TabIndex = 5;
            label3.Text = "Četnost výskytů";
            // 
            // LblOutput
            // 
            LblOutput.BorderStyle = BorderStyle.Fixed3D;
            LblOutput.Font = new Font("Segoe UI", 15.75F);
            LblOutput.Location = new Point(12, 211);
            LblOutput.Name = "LblOutput";
            LblOutput.Size = new Size(252, 271);
            LblOutput.TabIndex = 6;
            // 
            // PanelOutput
            // 
            PanelOutput.BackColor = Color.White;
            PanelOutput.BorderStyle = BorderStyle.Fixed3D;
            PanelOutput.Location = new Point(270, 211);
            PanelOutput.Name = "PanelOutput";
            PanelOutput.Size = new Size(429, 271);
            PanelOutput.TabIndex = 7;
            PanelOutput.Paint += PanelOutput_Paint;
            // 
            // BtnCompute
            // 
            BtnCompute.Font = new Font("Segoe UI", 15.75F);
            BtnCompute.Location = new Point(12, 107);
            BtnCompute.Name = "BtnCompute";
            BtnCompute.Size = new Size(252, 47);
            BtnCompute.TabIndex = 8;
            BtnCompute.Text = "Urči četnost";
            BtnCompute.UseVisualStyleBackColor = true;
            BtnCompute.Click += BtnCompute_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 512);
            Controls.Add(BtnCompute);
            Controls.Add(PanelOutput);
            Controls.Add(LblOutput);
            Controls.Add(label3);
            Controls.Add(BtnGenerate);
            Controls.Add(NumN);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtInput);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtInput;
        private Label label1;
        private Label label2;
        private NumericUpDown NumN;
        private Button BtnGenerate;
        private Label label3;
        private Label LblOutput;
        private Panel PanelOutput;
        private Button BtnCompute;
    }
}
