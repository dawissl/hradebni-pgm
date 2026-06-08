namespace _21_NpcManager
{
    partial class NpcDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            TxtName = new TextBox();
            CheckFriendly = new CheckBox();
            NumLvl = new NumericUpDown();
            BtnExecute = new Button();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)NumLvl).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F);
            label1.Location = new Point(29, 9);
            label1.Name = "label1";
            label1.Size = new Size(199, 37);
            label1.TabIndex = 4;
            label1.Text = "Přidání postavy";
            label1.Click += label1_Click;
            // 
            // TxtName
            // 
            TxtName.Font = new Font("Segoe UI", 20.25F);
            TxtName.Location = new Point(169, 61);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(275, 43);
            TxtName.TabIndex = 5;
            // 
            // CheckFriendly
            // 
            CheckFriendly.AutoSize = true;
            CheckFriendly.Font = new Font("Segoe UI", 20.25F);
            CheckFriendly.Location = new Point(169, 183);
            CheckFriendly.Name = "CheckFriendly";
            CheckFriendly.Size = new Size(142, 41);
            CheckFriendly.TabIndex = 6;
            CheckFriendly.Text = "Přátelská";
            CheckFriendly.UseVisualStyleBackColor = true;
            // 
            // NumLvl
            // 
            NumLvl.Font = new Font("Segoe UI", 20.25F);
            NumLvl.Location = new Point(169, 114);
            NumLvl.Name = "NumLvl";
            NumLvl.Size = new Size(275, 43);
            NumLvl.TabIndex = 7;
            // 
            // BtnExecute
            // 
            BtnExecute.Font = new Font("Segoe UI", 20.25F);
            BtnExecute.Location = new Point(29, 230);
            BtnExecute.Name = "BtnExecute";
            BtnExecute.Size = new Size(415, 54);
            BtnExecute.TabIndex = 8;
            BtnExecute.Text = "Přidat postavu";
            BtnExecute.UseVisualStyleBackColor = true;
            BtnExecute.Click += BtnExecute_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F);
            label2.Location = new Point(29, 66);
            label2.Name = "label2";
            label2.Size = new Size(95, 37);
            label2.TabIndex = 9;
            label2.Text = "Jméno";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F);
            label3.Location = new Point(29, 119);
            label3.Name = "label3";
            label3.Size = new Size(103, 37);
            label3.TabIndex = 10;
            label3.Text = "Úroveň";
            // 
            // NpcDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 298);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BtnExecute);
            Controls.Add(NumLvl);
            Controls.Add(CheckFriendly);
            Controls.Add(TxtName);
            Controls.Add(label1);
            Name = "NpcDialog";
            Text = "NpcDialog";
            ((System.ComponentModel.ISupportInitialize)NumLvl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtName;
        private CheckBox CheckFriendly;
        private NumericUpDown NumLvl;
        private Button BtnExecute;
        private Label label2;
        private Label label3;
    }
}