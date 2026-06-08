using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _21_DenniAktivity
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
            chartPanel = new Panel();
            colorDialog1 = new ColorDialog();
            addActitvity = new Button();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            menuStrip1 = new MenuStrip();
            resetToolStripMenuItem = new ToolStripMenuItem();
            autorToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
            lblMost = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // chartPanel
            // 
            chartPanel.BackColor = SystemColors.AppWorkspace;
            chartPanel.Location = new Point(346, 60);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(420, 420);
            chartPanel.TabIndex = 0;
            chartPanel.Paint += chartPanel_Paint_1;
            chartPanel.MouseClick += chartPanel_MouseClick;
            // 
            // addActitvity
            // 
            addActitvity.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            addActitvity.Location = new Point(25, 240);
            addActitvity.Name = "addActitvity";
            addActitvity.Size = new Size(168, 106);
            addActitvity.TabIndex = 1;
            addActitvity.Text = "Přidat aktivitu";
            addActitvity.UseVisualStyleBackColor = true;
            addActitvity.Click += addActitvity_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            textBox1.Location = new Point(100, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 35);
            textBox1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            numericUpDown1.Location = new Point(100, 116);
            numericUpDown1.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(227, 35);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label1.Location = new Point(12, 178);
            label1.Name = "label1";
            label1.Size = new Size(64, 30);
            label1.TabIndex = 4;
            label1.Text = "Barva";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(82, 30);
            label2.TabIndex = 5;
            label2.Text = "Aktivita";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label3.Location = new Point(12, 121);
            label3.Name = "label3";
            label3.Size = new Size(46, 30);
            label3.TabIndex = 6;
            label3.Text = "Čas";
            // 
            // label4
            // 
            label4.BackColor = Color.Black;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label4.Location = new Point(100, 178);
            label4.Name = "label4";
            label4.Size = new Size(227, 30);
            label4.TabIndex = 7;
            label4.Click += label4_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            menuStrip1.Items.AddRange(new ToolStripItem[] { resetToolStripMenuItem, autorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(797, 38);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(75, 34);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // autorToolStripMenuItem
            // 
            autorToolStripMenuItem.Name = "autorToolStripMenuItem";
            autorToolStripMenuItem.Size = new Size(77, 34);
            autorToolStripMenuItem.Text = "Autor";
            autorToolStripMenuItem.Click += autorToolStripMenuItem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label5.Location = new Point(12, 365);
            label5.Name = "label5";
            label5.Size = new Size(237, 30);
            label5.TabIndex = 9;
            label5.Text = "Nejvíce stráveného času";
            // 
            // lblMost
            // 
            lblMost.AutoSize = true;
            lblMost.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblMost.Location = new Point(12, 411);
            lblMost.Name = "lblMost";
            lblMost.Size = new Size(0, 30);
            lblMost.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 504);
            Controls.Add(lblMost);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(addActitvity);
            Controls.Add(chartPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel chartPanel;
        private ColorDialog colorDialog1;
        private Button addActitvity;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem autorToolStripMenuItem;
        private Label label5;
        private Label lblMost;
    }
}