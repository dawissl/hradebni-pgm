namespace _16_GarazTanky
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
            LblOut = new Label();
            LblPancir = new Label();
            SuspendLayout();
            // 
            // LblOut
            // 
            LblOut.AutoSize = true;
            LblOut.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblOut.Location = new Point(68, 76);
            LblOut.Name = "LblOut";
            LblOut.Size = new Size(78, 32);
            LblOut.TabIndex = 0;
            LblOut.Text = "label1";
            // 
            // LblPancir
            // 
            LblPancir.AutoSize = true;
            LblPancir.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblPancir.Location = new Point(68, 25);
            LblPancir.Name = "LblPancir";
            LblPancir.Size = new Size(78, 32);
            LblPancir.TabIndex = 1;
            LblPancir.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LblPancir);
            Controls.Add(LblOut);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblOut;
        private Label LblPancir;
    }
}
