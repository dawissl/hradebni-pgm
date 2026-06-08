namespace _19_DenniAktivity
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
            panelPie = new Panel();
            barvaAktivity = new ColorDialog();
            SuspendLayout();
            // 
            // panelPie
            // 
            panelPie.BackColor = SystemColors.ActiveCaption;
            panelPie.Location = new Point(370, 36);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(400, 400);
            panelPie.TabIndex = 0;
            panelPie.Paint += panelPie_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelPie);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPie;
        private ColorDialog barvaAktivity;
    }
}
