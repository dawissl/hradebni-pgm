namespace _04_StatistickeGrafy
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
            PanelGraph = new Panel();
            BtnGenerate = new Button();
            SuspendLayout();
            // 
            // PanelGraph
            // 
            PanelGraph.BackColor = Color.White;
            PanelGraph.Location = new Point(26, 35);
            PanelGraph.Name = "PanelGraph";
            PanelGraph.Size = new Size(442, 352);
            PanelGraph.TabIndex = 0;
            PanelGraph.Paint += PanelGraph_Paint;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnGenerate.Location = new Point(491, 55);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(189, 77);
            BtnGenerate.TabIndex = 1;
            BtnGenerate.Text = "Generuj data";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnGenerate);
            Controls.Add(PanelGraph);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelGraph;
        private Button BtnGenerate;
    }
}
