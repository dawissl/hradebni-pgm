namespace _05_Grafika
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
            BtnDraw = new Button();
            LblDraw = new Label();
            PanelDraw = new Panel();
            SuspendLayout();
            // 
            // BtnDraw
            // 
            BtnDraw.Location = new Point(193, 254);
            BtnDraw.Name = "BtnDraw";
            BtnDraw.Size = new Size(335, 52);
            BtnDraw.TabIndex = 0;
            BtnDraw.Text = "Kresli";
            BtnDraw.UseVisualStyleBackColor = true;
            BtnDraw.Click += BtnDraw_Click;
            BtnDraw.Paint += BtnDraw_Paint;
            // 
            // LblDraw
            // 
            LblDraw.BorderStyle = BorderStyle.Fixed3D;
            LblDraw.Location = new Point(193, 309);
            LblDraw.Name = "LblDraw";
            LblDraw.Size = new Size(335, 96);
            LblDraw.TabIndex = 1;
            LblDraw.Paint += LblDraw_Paint;
            // 
            // PanelDraw
            // 
            PanelDraw.BackColor = Color.White;
            PanelDraw.Location = new Point(193, 15);
            PanelDraw.Name = "PanelDraw";
            PanelDraw.Size = new Size(335, 226);
            PanelDraw.TabIndex = 2;
            PanelDraw.Paint += PanelDraw_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 432);
            Controls.Add(PanelDraw);
            Controls.Add(LblDraw);
            Controls.Add(BtnDraw);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnDraw;
        private Label LblDraw;
        private Panel PanelDraw;
    }
}
