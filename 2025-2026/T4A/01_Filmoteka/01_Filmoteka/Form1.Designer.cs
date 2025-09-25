namespace _01_Filmoteka
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
            Btn_AddFilm = new Button();
            kolekceFilmu = new ListBox();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtDirector = new TextBox();
            label3 = new Label();
            lblInfo = new Label();
            BtnAddDialog = new Button();
            button1 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            BtnEdit = new Button();
            SuspendLayout();
            // 
            // Btn_AddFilm
            // 
            Btn_AddFilm.Location = new Point(57, 44);
            Btn_AddFilm.Name = "Btn_AddFilm";
            Btn_AddFilm.Size = new Size(136, 51);
            Btn_AddFilm.TabIndex = 0;
            Btn_AddFilm.Text = "Přidat film";
            Btn_AddFilm.UseVisualStyleBackColor = true;
            Btn_AddFilm.Click += Btn_AddFilm_Click;
            // 
            // kolekceFilmu
            // 
            kolekceFilmu.FormattingEnabled = true;
            kolekceFilmu.ItemHeight = 15;
            kolekceFilmu.Location = new Point(300, 46);
            kolekceFilmu.Name = "kolekceFilmu";
            kolekceFilmu.Size = new Size(165, 379);
            kolekceFilmu.TabIndex = 1;
            kolekceFilmu.SelectedIndexChanged += kolekceFilmu_SelectedIndexChanged;
            kolekceFilmu.DoubleClick += kolekceFilmu_DoubleClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(47, 161);
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 23);
            txtName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 125);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 3;
            label1.Text = "nazev";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 214);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "režiser";
            // 
            // txtDirector
            // 
            txtDirector.Location = new Point(47, 250);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(169, 23);
            txtDirector.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(520, 51);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 6;
            label3.Text = "Info";
            // 
            // lblInfo
            // 
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblInfo.Location = new Point(520, 80);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(166, 333);
            lblInfo.TabIndex = 7;
            // 
            // BtnAddDialog
            // 
            BtnAddDialog.Location = new Point(34, 301);
            BtnAddDialog.Name = "BtnAddDialog";
            BtnAddDialog.Size = new Size(136, 51);
            BtnAddDialog.TabIndex = 8;
            BtnAddDialog.Text = "Dialo přidání";
            BtnAddDialog.UseVisualStyleBackColor = true;
            BtnAddDialog.Click += BtnAddDialog_Click;
            // 
            // button1
            // 
            button1.Location = new Point(34, 358);
            button1.Name = "button1";
            button1.Size = new Size(136, 51);
            button1.TabIndex = 9;
            button1.Text = "Vypsat do souboru";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(300, 431);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(162, 70);
            BtnEdit.TabIndex = 10;
            BtnEdit.Text = "EditaceFilmu";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 543);
            Controls.Add(BtnEdit);
            Controls.Add(button1);
            Controls.Add(BtnAddDialog);
            Controls.Add(lblInfo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDirector);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(kolekceFilmu);
            Controls.Add(Btn_AddFilm);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_AddFilm;
        private ListBox kolekceFilmu;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtDirector;
        private Label label3;
        private Label lblInfo;
        private Button BtnAddDialog;
        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Button BtnEdit;
    }
}
