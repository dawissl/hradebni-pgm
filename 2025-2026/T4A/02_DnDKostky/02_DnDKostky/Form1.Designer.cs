namespace _02_DnDKostky
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
            dicesList = new CheckedListBox();
            label1 = new Label();
            TxtSize = new TextBox();
            TxtNote = new TextBox();
            label2 = new Label();
            label3 = new Label();
            LblColor = new Label();
            BtnAddDice = new Button();
            BtnRoll = new Button();
            label4 = new Label();
            LblRoll = new Label();
            DiceColorDialog = new ColorDialog();
            BtnSelectAll = new Button();
            SuspendLayout();
            // 
            // dicesList
            // 
            dicesList.BackColor = SystemColors.Window;
            dicesList.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dicesList.FormattingEnabled = true;
            dicesList.Location = new Point(174, 12);
            dicesList.Name = "dicesList";
            dicesList.Size = new Size(256, 368);
            dicesList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 1;
            label1.Text = "Počet stěn";
            // 
            // TxtSize
            // 
            TxtSize.Font = new Font("Segoe UI", 14.25F);
            TxtSize.Location = new Point(12, 55);
            TxtSize.Name = "TxtSize";
            TxtSize.Size = new Size(100, 33);
            TxtSize.TabIndex = 2;
            // 
            // TxtNote
            // 
            TxtNote.Font = new Font("Segoe UI", 14.25F);
            TxtNote.Location = new Point(12, 135);
            TxtNote.Name = "TxtNote";
            TxtNote.Size = new Size(100, 33);
            TxtNote.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(12, 107);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 3;
            label2.Text = "Popisek";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(10, 183);
            label3.Name = "label3";
            label3.Size = new Size(118, 25);
            label3.TabIndex = 5;
            label3.Text = "Barva Kostky";
            // 
            // LblColor
            // 
            LblColor.BackColor = Color.Black;
            LblColor.BorderStyle = BorderStyle.Fixed3D;
            LblColor.Font = new Font("Segoe UI", 14.25F);
            LblColor.ForeColor = Color.Black;
            LblColor.Location = new Point(14, 208);
            LblColor.Name = "LblColor";
            LblColor.Size = new Size(98, 25);
            LblColor.TabIndex = 6;
            LblColor.Click += LblColor_Click;
            // 
            // BtnAddDice
            // 
            BtnAddDice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnAddDice.Location = new Point(14, 249);
            BtnAddDice.Name = "BtnAddDice";
            BtnAddDice.Size = new Size(98, 71);
            BtnAddDice.TabIndex = 7;
            BtnAddDice.Text = "Přidat";
            BtnAddDice.UseVisualStyleBackColor = true;
            BtnAddDice.Click += BtnAddDice_Click;
            // 
            // BtnRoll
            // 
            BtnRoll.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnRoll.Location = new Point(174, 400);
            BtnRoll.Name = "BtnRoll";
            BtnRoll.Size = new Size(182, 35);
            BtnRoll.TabIndex = 8;
            BtnRoll.Text = "Hod kostkami";
            BtnRoll.UseVisualStyleBackColor = true;
            BtnRoll.Click += BtnRoll_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(459, 12);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 9;
            label4.Text = "Výsledný hod";
            // 
            // LblRoll
            // 
            LblRoll.BorderStyle = BorderStyle.FixedSingle;
            LblRoll.Font = new Font("Segoe UI", 14.25F);
            LblRoll.Location = new Point(459, 55);
            LblRoll.Name = "LblRoll";
            LblRoll.Size = new Size(320, 153);
            LblRoll.TabIndex = 10;
            // 
            // DiceColorDialog
            // 
            DiceColorDialog.AllowFullOpen = false;
            DiceColorDialog.SolidColorOnly = true;
            // 
            // BtnSelectAll
            // 
            BtnSelectAll.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnSelectAll.Location = new Point(362, 400);
            BtnSelectAll.Name = "BtnSelectAll";
            BtnSelectAll.Size = new Size(68, 35);
            BtnSelectAll.TabIndex = 11;
            BtnSelectAll.Text = "Vše";
            BtnSelectAll.UseVisualStyleBackColor = true;
            BtnSelectAll.Click += BtnSelectAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnSelectAll);
            Controls.Add(LblRoll);
            Controls.Add(label4);
            Controls.Add(BtnRoll);
            Controls.Add(BtnAddDice);
            Controls.Add(LblColor);
            Controls.Add(label3);
            Controls.Add(TxtNote);
            Controls.Add(label2);
            Controls.Add(TxtSize);
            Controls.Add(label1);
            Controls.Add(dicesList);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox dicesList;
        private Label label1;
        private TextBox TxtSize;
        private TextBox TxtNote;
        private Label label2;
        private Label label3;
        private Label LblColor;
        private Button BtnAddDice;
        private Button BtnRoll;
        private Label label4;
        private Label LblRoll;
        private ColorDialog DiceColorDialog;
        private Button BtnSelectAll;
    }
}
