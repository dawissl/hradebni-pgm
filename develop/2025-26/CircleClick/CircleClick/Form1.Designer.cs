namespace CircleClick
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
            PanelCircle = new Panel();
            label1 = new Label();
            LblInfo = new Label();
            BtnGenerate = new Button();
            SuspendLayout();
            // 
            // PanelCircle
            // 
            PanelCircle.BackColor = SystemColors.ControlLightLight;
            PanelCircle.Location = new Point(25, 25);
            PanelCircle.Name = "PanelCircle";
            PanelCircle.Size = new Size(400, 400);
            PanelCircle.TabIndex = 0;
            PanelCircle.Paint += PanelCircle_Paint;
            PanelCircle.MouseDown += PanelCircle_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(453, 208);
            label1.Name = "label1";
            label1.Size = new Size(50, 30);
            label1.TabIndex = 1;
            label1.Text = "Info";
            // 
            // LblInfo
            // 
            LblInfo.BorderStyle = BorderStyle.Fixed3D;
            LblInfo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo.Location = new Point(453, 246);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(226, 179);
            LblInfo.TabIndex = 2;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnGenerate.Location = new Point(481, 50);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(200, 76);
            BtnGenerate.TabIndex = 3;
            BtnGenerate.Text = "Vykresli kolečka";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnGenerate);
            Controls.Add(LblInfo);
            Controls.Add(label1);
            Controls.Add(PanelCircle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelCircle;
        private Label label1;
        private Label LblInfo;
        private Button BtnGenerate;
    }
}