using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _08_AnalyzaSouboru
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
            BtnLoad = new Button();
            BtnSave = new Button();
            label1 = new Label();
            LblStats = new Label();
            SuspendLayout();
            // 
            // BtnLoad
            // 
            BtnLoad.Font = new System.Drawing.Font("Segoe UI", 18F);
            BtnLoad.Location = new Point(62, 12);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(200, 40);
            BtnLoad.TabIndex = 0;
            BtnLoad.Text = "Analyzuj soubor";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnSave
            // 
            BtnSave.Font = new System.Drawing.Font("Segoe UI", 18F);
            BtnSave.Location = new Point(62, 398);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(200, 40);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "Ulož statistiku";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            label1.Location = new Point(28, 73);
            label1.Name = "label1";
            label1.Size = new Size(203, 32);
            label1.TabIndex = 2;
            label1.Text = "Statistika souboru";
            // 
            // LblStats
            // 
            LblStats.BorderStyle = BorderStyle.FixedSingle;
            LblStats.Font = new System.Drawing.Font("Segoe UI", 18F);
            LblStats.Location = new Point(28, 105);
            LblStats.Name = "LblStats";
            LblStats.Size = new Size(281, 278);
            LblStats.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 450);
            Controls.Add(LblStats);
            Controls.Add(label1);
            Controls.Add(BtnSave);
            Controls.Add(BtnLoad);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnLoad;
        private Button BtnSave;
        private Label label1;
        private Label LblStats;
    }
}