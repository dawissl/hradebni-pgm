namespace _07_MouseEvent
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
            PanelPolygon = new Panel();
            BtnReset = new Button();
            SuspendLayout();
            // 
            // PanelPolygon
            // 
            PanelPolygon.BackColor = Color.White;
            PanelPolygon.BorderStyle = BorderStyle.Fixed3D;
            PanelPolygon.Location = new Point(20, 10);
            PanelPolygon.Name = "PanelPolygon";
            PanelPolygon.Size = new Size(452, 410);
            PanelPolygon.TabIndex = 0;
            PanelPolygon.Paint += PanelPolygon_Paint;
            PanelPolygon.MouseClick += PanelPolygon_MouseClick;
            PanelPolygon.MouseDoubleClick += PanelPolygon_MouseDoubleClick;
            // 
            // BtnReset
            // 
            BtnReset.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnReset.Location = new Point(497, 22);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(188, 59);
            BtnReset.TabIndex = 1;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnReset);
            Controls.Add(PanelPolygon);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPolygon;
        private Button BtnReset;
    }
}
