using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _08_TetovySoubor
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
            label1 = new Label();
            LblFile = new Label();
            label2 = new Label();
            TxtFile = new TextBox();
            BtnSave = new Button();
            BtnLoad = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            label1.Location = new Point(315, 31);
            label1.Name = "label1";
            label1.Size = new Size(145, 25);
            label1.TabIndex = 0;
            label1.Text = "Načtený soubor";
            // 
            // LblFile
            // 
            LblFile.BorderStyle = BorderStyle.Fixed3D;
            LblFile.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            LblFile.Location = new Point(315, 58);
            LblFile.Name = "LblFile";
            LblFile.Size = new Size(233, 292);
            LblFile.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            label2.Location = new Point(25, 31);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 2;
            label2.Text = "Vstup do souboru";
            // 
            // TxtFile
            // 
            TxtFile.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            TxtFile.Location = new Point(25, 56);
            TxtFile.Multiline = true;
            TxtFile.Name = "TxtFile";
            TxtFile.Size = new Size(233, 294);
            TxtFile.TabIndex = 3;
            // 
            // BtnSave
            // 
            BtnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            BtnSave.Location = new Point(25, 365);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(233, 42);
            BtnSave.TabIndex = 4;
            BtnSave.Text = "Uložit do souboru";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            BtnLoad.Location = new Point(315, 365);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(233, 42);
            BtnLoad.TabIndex = 5;
            BtnLoad.Text = "Načíst ze souboru";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 450);
            Controls.Add(BtnLoad);
            Controls.Add(BtnSave);
            Controls.Add(TxtFile);
            Controls.Add(label2);
            Controls.Add(LblFile);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label LblFile;
        private Label label2;
        private TextBox TxtFile;
        private Button BtnSave;
        private Button BtnLoad;
    }
}
