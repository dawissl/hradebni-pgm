namespace Dividers200
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
            LblDefault = new Label();
            LblSort = new Label();
            LblGroups = new Label();
            BtnSort = new Button();
            BtnGroup = new Button();
            BtnGenerate = new Button();
            SuspendLayout();
            // 
            // LblDefault
            // 
            LblDefault.BorderStyle = BorderStyle.Fixed3D;
            LblDefault.Location = new Point(21, 13);
            LblDefault.Name = "LblDefault";
            LblDefault.Size = new Size(258, 243);
            LblDefault.TabIndex = 0;
            // 
            // LblSort
            // 
            LblSort.BorderStyle = BorderStyle.Fixed3D;
            LblSort.Location = new Point(301, 13);
            LblSort.Name = "LblSort";
            LblSort.Size = new Size(258, 243);
            LblSort.TabIndex = 1;
            // 
            // LblGroups
            // 
            LblGroups.BorderStyle = BorderStyle.Fixed3D;
            LblGroups.Location = new Point(565, 24);
            LblGroups.Name = "LblGroups";
            LblGroups.Size = new Size(240, 143);
            LblGroups.TabIndex = 2;
            // 
            // BtnSort
            // 
            BtnSort.Location = new Point(565, 179);
            BtnSort.Name = "BtnSort";
            BtnSort.Size = new Size(76, 77);
            BtnSort.TabIndex = 3;
            BtnSort.Text = "Seřaď";
            BtnSort.UseVisualStyleBackColor = true;
            BtnSort.Click += BtnSort_Click;
            // 
            // BtnGroup
            // 
            BtnGroup.Location = new Point(647, 179);
            BtnGroup.Name = "BtnGroup";
            BtnGroup.Size = new Size(76, 77);
            BtnGroup.TabIndex = 4;
            BtnGroup.Text = "Seskup";
            BtnGroup.UseVisualStyleBackColor = true;
            BtnGroup.Click += BtnGroup_Click;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(729, 179);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(76, 77);
            BtnGenerate.TabIndex = 5;
            BtnGenerate.Text = "Nové generování";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 341);
            Controls.Add(BtnGenerate);
            Controls.Add(BtnGroup);
            Controls.Add(BtnSort);
            Controls.Add(LblGroups);
            Controls.Add(LblSort);
            Controls.Add(LblDefault);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
        }

        #endregion

        private Label LblDefault;
        private Label LblSort;
        private Label LblGroups;
        private Button BtnSort;
        private Button BtnGroup;
        private Button BtnGenerate;
    }
}
