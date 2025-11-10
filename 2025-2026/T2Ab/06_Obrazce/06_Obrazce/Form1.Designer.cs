namespace _06_Obrazce
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
            PanelImages = new Panel();
            RadEllipse = new RadioButton();
            RadRectangle = new RadioButton();
            NumHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            NumWidth = new NumericUpDown();
            CheckFill = new CheckBox();
            BtnDraw = new Button();
            label3 = new Label();
            LblLocation = new Label();
            ComboColor = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            ComboPen = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)NumHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumWidth).BeginInit();
            SuspendLayout();
            // 
            // PanelImages
            // 
            PanelImages.BorderStyle = BorderStyle.Fixed3D;
            PanelImages.Location = new Point(12, 12);
            PanelImages.Name = "PanelImages";
            PanelImages.Size = new Size(367, 582);
            PanelImages.TabIndex = 0;
            PanelImages.Paint += PanelImages_Paint;
            PanelImages.MouseDown += PanelImages_MouseDown;
            // 
            // RadEllipse
            // 
            RadEllipse.AutoSize = true;
            RadEllipse.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            RadEllipse.Location = new Point(418, 134);
            RadEllipse.Name = "RadEllipse";
            RadEllipse.Size = new Size(84, 34);
            RadEllipse.TabIndex = 1;
            RadEllipse.TabStop = true;
            RadEllipse.Text = "Elipsa";
            RadEllipse.UseVisualStyleBackColor = true;
            // 
            // RadRectangle
            // 
            RadRectangle.AutoSize = true;
            RadRectangle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            RadRectangle.Location = new Point(530, 134);
            RadRectangle.Name = "RadRectangle";
            RadRectangle.Size = new Size(114, 34);
            RadRectangle.TabIndex = 2;
            RadRectangle.TabStop = true;
            RadRectangle.Text = "Obdélník";
            RadRectangle.UseVisualStyleBackColor = true;
            // 
            // NumHeight
            // 
            NumHeight.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NumHeight.Location = new Point(418, 70);
            NumHeight.Name = "NumHeight";
            NumHeight.Size = new Size(122, 35);
            NumHeight.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(414, 25);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 4;
            label1.Text = "Výška";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(561, 25);
            label2.Name = "label2";
            label2.Size = new Size(57, 30);
            label2.TabIndex = 6;
            label2.Text = "Šířka";
            // 
            // NumWidth
            // 
            NumWidth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NumWidth.Location = new Point(565, 70);
            NumWidth.Name = "NumWidth";
            NumWidth.Size = new Size(122, 35);
            NumWidth.TabIndex = 5;
            // 
            // CheckFill
            // 
            CheckFill.AutoSize = true;
            CheckFill.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            CheckFill.Location = new Point(418, 195);
            CheckFill.Name = "CheckFill";
            CheckFill.Size = new Size(84, 34);
            CheckFill.TabIndex = 8;
            CheckFill.Text = "Výplň";
            CheckFill.UseVisualStyleBackColor = true;
            CheckFill.CheckedChanged += CheckFill_CheckedChanged;
            // 
            // BtnDraw
            // 
            BtnDraw.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnDraw.Location = new Point(405, 352);
            BtnDraw.Name = "BtnDraw";
            BtnDraw.Size = new Size(282, 79);
            BtnDraw.TabIndex = 9;
            BtnDraw.Text = "Vykresli";
            BtnDraw.UseVisualStyleBackColor = true;
            BtnDraw.Click += BtnDraw_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(405, 445);
            label3.Name = "label3";
            label3.Size = new Size(116, 30);
            label3.TabIndex = 10;
            label3.Text = "Souřadnice";
            // 
            // LblLocation
            // 
            LblLocation.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblLocation.Location = new Point(405, 490);
            LblLocation.Name = "LblLocation";
            LblLocation.Size = new Size(262, 61);
            LblLocation.TabIndex = 11;
            // 
            // ComboColor
            // 
            ComboColor.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ComboColor.FormattingEnabled = true;
            ComboColor.Items.AddRange(new object[] { "RED", "GREEN", "BLUE" });
            ComboColor.Location = new Point(535, 239);
            ComboColor.Name = "ComboColor";
            ComboColor.Size = new Size(152, 38);
            ComboColor.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(413, 247);
            label4.Name = "label4";
            label4.Size = new Size(64, 30);
            label4.TabIndex = 13;
            label4.Text = "Barva";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(413, 300);
            label5.Name = "label5";
            label5.Size = new Size(105, 30);
            label5.TabIndex = 15;
            label5.Text = "Šířka tahu";
            // 
            // ComboPen
            // 
            ComboPen.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ComboPen.FormattingEnabled = true;
            ComboPen.Items.AddRange(new object[] { "1", "3", "5" });
            ComboPen.Location = new Point(535, 292);
            ComboPen.Name = "ComboPen";
            ComboPen.Size = new Size(152, 38);
            ComboPen.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 605);
            Controls.Add(label5);
            Controls.Add(ComboPen);
            Controls.Add(label4);
            Controls.Add(ComboColor);
            Controls.Add(LblLocation);
            Controls.Add(label3);
            Controls.Add(BtnDraw);
            Controls.Add(CheckFill);
            Controls.Add(label2);
            Controls.Add(NumWidth);
            Controls.Add(label1);
            Controls.Add(NumHeight);
            Controls.Add(RadRectangle);
            Controls.Add(RadEllipse);
            Controls.Add(PanelImages);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelImages;
        private RadioButton RadEllipse;
        private RadioButton RadRectangle;
        private NumericUpDown NumHeight;
        private Label label1;
        private Label label2;
        private NumericUpDown NumWidth;
        private CheckBox CheckFill;
        private Button BtnDraw;
        private Label label3;
        private Label LblLocation;
        private ComboBox ComboColor;
        private Label label4;
        private Label label5;
        private ComboBox ComboPen;
    }
}
