namespace _21_NpcManager
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
            NpcList = new ListBox();
            BtnDialog = new Button();
            LblInfo = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // NpcList
            // 
            NpcList.Font = new Font("Segoe UI", 15.75F);
            NpcList.FormattingEnabled = true;
            NpcList.ItemHeight = 30;
            NpcList.Location = new Point(12, 12);
            NpcList.Name = "NpcList";
            NpcList.Size = new Size(324, 424);
            NpcList.TabIndex = 0;
            NpcList.SelectedIndexChanged += NpcList_SelectedIndexChanged;
            // 
            // BtnDialog
            // 
            BtnDialog.Font = new Font("Segoe UI", 15.75F);
            BtnDialog.Location = new Point(358, 197);
            BtnDialog.Name = "BtnDialog";
            BtnDialog.Size = new Size(183, 80);
            BtnDialog.TabIndex = 1;
            BtnDialog.Text = "Přidat postavu";
            BtnDialog.UseVisualStyleBackColor = true;
            BtnDialog.Click += BtnDialog_Click;
            // 
            // LblInfo
            // 
            LblInfo.BorderStyle = BorderStyle.Fixed3D;
            LblInfo.Font = new Font("Segoe UI", 15.75F);
            LblInfo.Location = new Point(358, 54);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(406, 127);
            LblInfo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(358, 12);
            label1.Name = "label1";
            label1.Size = new Size(203, 30);
            label1.TabIndex = 3;
            label1.Text = "Informace o postavě";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(LblInfo);
            Controls.Add(BtnDialog);
            Controls.Add(NpcList);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox NpcList;
        private Button BtnDialog;
        private Label LblInfo;
        private Label label1;
    }
}
