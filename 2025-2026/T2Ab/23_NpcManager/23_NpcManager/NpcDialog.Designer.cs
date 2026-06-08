namespace _23_NpcManager
{
    partial class NpcDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.CheckBox chkHostile;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblRace = new Label();
            cmbRace = new ComboBox();
            lblLevel = new Label();
            nudLevel = new NumericUpDown();
            chkHostile = new CheckBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudLevel).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(21, 21);
            lblName.Name = "lblName";
            lblName.Size = new Size(45, 15);
            lblName.TabIndex = 10;
            lblName.Text = "Jméno:";
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 19);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(219, 23);
            txtName.TabIndex = 0;
            // 
            // lblRace
            // 
            lblRace.AutoSize = true;
            lblRace.Location = new Point(21, 54);
            lblRace.Name = "lblRace";
            lblRace.Size = new Size(34, 15);
            lblRace.TabIndex = 9;
            lblRace.Text = "Rasa:";
            // 
            // cmbRace
            // 
            cmbRace.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRace.FormattingEnabled = true;
            cmbRace.Items.AddRange(new object[] { "Člověk", "Elf", "Trpaslík", "Ork", "Goblin", "Nemrtvý", "Démon", "Jiná" });
            cmbRace.Location = new Point(131, 52);
            cmbRace.Margin = new Padding(3, 2, 3, 2);
            cmbRace.Name = "cmbRace";
            cmbRace.Size = new Size(219, 23);
            cmbRace.TabIndex = 1;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(21, 88);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(48, 15);
            lblLevel.TabIndex = 8;
            lblLevel.Text = "Úroveň:";
            // 
            // nudLevel
            // 
            nudLevel.Location = new Point(131, 87);
            nudLevel.Margin = new Padding(3, 2, 3, 2);
            nudLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLevel.Name = "nudLevel";
            nudLevel.Size = new Size(105, 23);
            nudLevel.TabIndex = 2;
            nudLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkHostile
            // 
            chkHostile.AutoSize = true;
            chkHostile.Location = new Point(131, 120);
            chkHostile.Margin = new Padding(3, 2, 3, 2);
            chkHostile.Name = "chkHostile";
            chkHostile.Size = new Size(115, 19);
            chkHostile.TabIndex = 3;
            chkHostile.Text = "Nepřátelská NPC";
            chkHostile.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(21, 154);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(39, 15);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Popis:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(131, 152);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(219, 91);
            txtDescription.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(177, 261);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 27);
            btnSave.TabIndex = 5;
            btnSave.Text = "Uložit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(268, 261);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 27);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NpcDialog
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(378, 306);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(chkHostile);
            Controls.Add(nudLevel);
            Controls.Add(lblLevel);
            Controls.Add(cmbRace);
            Controls.Add(lblRace);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NpcDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NPC postava";
            ((System.ComponentModel.ISupportInitialize)nudLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}