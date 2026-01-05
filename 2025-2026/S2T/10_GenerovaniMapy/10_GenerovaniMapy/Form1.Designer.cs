using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using Font = System.Drawing.Font;

namespace _10_GenerovaniMapy
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
            NumHeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            NumWidth = new NumericUpDown();
            LblMap = new Label();
            label7 = new Label();
            PanelMap = new Panel();
            label8 = new Label();
            BtnGenerateMap = new Button();
            NumWater = new NumericUpDown();
            label4 = new Label();
            LblMapType = new Label();
            NumGrass = new NumericUpDown();
            label6 = new Label();
            BtnSaveMap = new Button();
            NumTileSite = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)NumHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumWater).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumGrass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTileSite).BeginInit();
            SuspendLayout();
            // 
            // NumHeight
            // 
            NumHeight.Font = new Font("Segoe UI", 15.75F);
            NumHeight.Location = new Point(197, 51);
            NumHeight.Name = "NumHeight";
            NumHeight.Size = new Size(120, 35);
            NumHeight.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(26, 52);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 1;
            label1.Text = "Výška";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(24, 146);
            label2.Name = "label2";
            label2.Size = new Size(157, 30);
            label2.TabIndex = 3;
            label2.Text = "Výskyt vody (%)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(26, 98);
            label3.Name = "label3";
            label3.Size = new Size(57, 30);
            label3.TabIndex = 5;
            label3.Text = "Šířka";
            // 
            // NumWidth
            // 
            NumWidth.Font = new Font("Segoe UI", 15.75F);
            NumWidth.Location = new Point(197, 97);
            NumWidth.Name = "NumWidth";
            NumWidth.Size = new Size(120, 35);
            NumWidth.TabIndex = 4;
            // 
            // LblMap
            // 
            LblMap.BackColor = SystemColors.Window;
            LblMap.BorderStyle = BorderStyle.Fixed3D;
            LblMap.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblMap.Location = new Point(378, 53);
            LblMap.Name = "LblMap";
            LblMap.Size = new Size(250, 250);
            LblMap.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F);
            label7.Location = new Point(378, 324);
            label7.Name = "label7";
            label7.Size = new Size(102, 30);
            label7.TabIndex = 8;
            label7.Text = "Typ mapy";
            // 
            // PanelMap
            // 
            PanelMap.BorderStyle = BorderStyle.Fixed3D;
            PanelMap.Font = new Font("Segoe UI", 15.75F);
            PanelMap.Location = new Point(654, 53);
            PanelMap.Name = "PanelMap";
            PanelMap.Size = new Size(250, 250);
            PanelMap.TabIndex = 10;
            PanelMap.Paint += PanelMap_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15.75F);
            label8.Location = new Point(378, 9);
            label8.Name = "label8";
            label8.Size = new Size(66, 30);
            label8.TabIndex = 11;
            label8.Text = "Mapa";
            // 
            // BtnGenerateMap
            // 
            BtnGenerateMap.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnGenerateMap.Location = new Point(26, 310);
            BtnGenerateMap.Name = "BtnGenerateMap";
            BtnGenerateMap.Size = new Size(245, 43);
            BtnGenerateMap.TabIndex = 12;
            BtnGenerateMap.Text = "Vygeneruj mapu";
            BtnGenerateMap.UseVisualStyleBackColor = true;
            BtnGenerateMap.Click += BtnGenerateMap_Click;
            // 
            // NumWater
            // 
            NumWater.Font = new Font("Segoe UI", 15.75F);
            NumWater.Location = new Point(197, 144);
            NumWater.Name = "NumWater";
            NumWater.Size = new Size(120, 35);
            NumWater.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.Location = new Point(24, 9);
            label4.Name = "label4";
            label4.Size = new Size(163, 30);
            label4.TabIndex = 14;
            label4.Text = "Parametry mapy";
            // 
            // LblMapType
            // 
            LblMapType.BorderStyle = BorderStyle.Fixed3D;
            LblMapType.Font = new Font("Segoe UI", 15.75F);
            LblMapType.Location = new Point(499, 323);
            LblMapType.Name = "LblMapType";
            LblMapType.Size = new Size(302, 38);
            LblMapType.TabIndex = 15;
            // 
            // NumGrass
            // 
            NumGrass.Font = new Font("Segoe UI", 15.75F);
            NumGrass.Location = new Point(197, 198);
            NumGrass.Name = "NumGrass";
            NumGrass.Size = new Size(120, 35);
            NumGrass.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F);
            label6.Location = new Point(24, 200);
            label6.Name = "label6";
            label6.Size = new Size(158, 30);
            label6.TabIndex = 16;
            label6.Text = "Výskyt trávy (%)";
            // 
            // BtnSaveMap
            // 
            BtnSaveMap.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnSaveMap.Location = new Point(26, 359);
            BtnSaveMap.Name = "BtnSaveMap";
            BtnSaveMap.Size = new Size(245, 43);
            BtnSaveMap.TabIndex = 18;
            BtnSaveMap.Text = "Uložit mapu";
            BtnSaveMap.UseVisualStyleBackColor = true;
            BtnSaveMap.Click += BtnSaveMap_Click;
            // 
            // NumTileSite
            // 
            NumTileSite.Font = new Font("Segoe UI", 15.75F);
            NumTileSite.Location = new Point(196, 245);
            NumTileSite.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            NumTileSite.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            NumTileSite.Name = "NumTileSite";
            NumTileSite.Size = new Size(120, 35);
            NumTileSite.TabIndex = 20;
            NumTileSite.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F);
            label5.Location = new Point(23, 247);
            label5.Name = "label5";
            label5.Size = new Size(166, 30);
            label5.TabIndex = 19;
            label5.Text = "Velikost dlaždice";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 450);
            Controls.Add(NumTileSite);
            Controls.Add(label5);
            Controls.Add(BtnSaveMap);
            Controls.Add(NumGrass);
            Controls.Add(label6);
            Controls.Add(LblMapType);
            Controls.Add(label4);
            Controls.Add(NumWater);
            Controls.Add(BtnGenerateMap);
            Controls.Add(label8);
            Controls.Add(PanelMap);
            Controls.Add(LblMap);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(NumWidth);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NumHeight);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumWater).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumGrass).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTileSite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown NumHeight;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private NumericUpDown NumWidth;
        private Label label5;
        private Label LblMap;
        private Label label7;
        private Panel PanelMap;
        private Label label8;
        private Button BtnGenerateMap;
        private NumericUpDown NumWater;
        private Label label4;
        private Label LblMapType;
        private NumericUpDown NumGrass;
        private Label label6;
        private Button BtnSaveMap;
        private NumericUpDown NumTileSite;
    }
}