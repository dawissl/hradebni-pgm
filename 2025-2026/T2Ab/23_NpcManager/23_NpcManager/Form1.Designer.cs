using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _23_NpcManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstNpc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRaceTitle;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.Label lblLevelTitle;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblHostileTitle;
        private System.Windows.Forms.Label lblHostile;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.TextBox txtDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lstNpc = new ListBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            grpDetail = new GroupBox();
            lblNameTitle = new Label();
            lblName = new Label();
            lblRaceTitle = new Label();
            lblRace = new Label();
            lblLevelTitle = new Label();
            lblLevel = new Label();
            lblHostileTitle = new Label();
            lblHostile = new Label();
            lblDescriptionTitle = new Label();
            txtDescription = new TextBox();
            grpDetail.SuspendLayout();
            SuspendLayout();
            // 
            // lstNpc
            // 
            lstNpc.FormattingEnabled = true;
            lstNpc.Location = new Point(21, 18);
            lstNpc.Margin = new Padding(3, 2, 3, 2);
            lstNpc.Name = "lstNpc";
            lstNpc.Size = new Size(263, 274);
            lstNpc.TabIndex = 0;
            lstNpc.SelectedIndexChanged += lstNpc_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(21, 304);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 28);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Přidat";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(112, 304);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 28);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Upravit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(203, 304);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 28);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Smazat";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(lblNameTitle);
            grpDetail.Controls.Add(lblName);
            grpDetail.Controls.Add(lblRaceTitle);
            grpDetail.Controls.Add(lblRace);
            grpDetail.Controls.Add(lblLevelTitle);
            grpDetail.Controls.Add(lblLevel);
            grpDetail.Controls.Add(lblHostileTitle);
            grpDetail.Controls.Add(lblHostile);
            grpDetail.Controls.Add(lblDescriptionTitle);
            grpDetail.Controls.Add(txtDescription);
            grpDetail.Location = new Point(308, 18);
            grpDetail.Margin = new Padding(3, 2, 3, 2);
            grpDetail.Name = "grpDetail";
            grpDetail.Padding = new Padding(3, 2, 3, 2);
            grpDetail.Size = new Size(364, 315);
            grpDetail.TabIndex = 4;
            grpDetail.TabStop = false;
            grpDetail.Text = "Detail NPC postavy";
            // 
            // lblNameTitle
            // 
            lblNameTitle.AutoSize = true;
            lblNameTitle.Location = new Point(21, 32);
            lblNameTitle.Name = "lblNameTitle";
            lblNameTitle.Size = new Size(45, 15);
            lblNameTitle.TabIndex = 0;
            lblNameTitle.Text = "Jméno:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(131, 32);
            lblName.Name = "lblName";
            lblName.Size = new Size(12, 15);
            lblName.TabIndex = 1;
            lblName.Text = "-";
            // 
            // lblRaceTitle
            // 
            lblRaceTitle.AutoSize = true;
            lblRaceTitle.Location = new Point(21, 62);
            lblRaceTitle.Name = "lblRaceTitle";
            lblRaceTitle.Size = new Size(34, 15);
            lblRaceTitle.TabIndex = 2;
            lblRaceTitle.Text = "Rasa:";
            // 
            // lblRace
            // 
            lblRace.AutoSize = true;
            lblRace.Location = new Point(131, 62);
            lblRace.Name = "lblRace";
            lblRace.Size = new Size(12, 15);
            lblRace.TabIndex = 3;
            lblRace.Text = "-";
            // 
            // lblLevelTitle
            // 
            lblLevelTitle.AutoSize = true;
            lblLevelTitle.Location = new Point(21, 92);
            lblLevelTitle.Name = "lblLevelTitle";
            lblLevelTitle.Size = new Size(48, 15);
            lblLevelTitle.TabIndex = 4;
            lblLevelTitle.Text = "Úroveň:";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(131, 92);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(12, 15);
            lblLevel.TabIndex = 5;
            lblLevel.Text = "-";
            // 
            // lblHostileTitle
            // 
            lblHostileTitle.AutoSize = true;
            lblHostileTitle.Location = new Point(21, 122);
            lblHostileTitle.Name = "lblHostileTitle";
            lblHostileTitle.Size = new Size(72, 15);
            lblHostileTitle.TabIndex = 6;
            lblHostileTitle.Text = "Nepřátelská:";
            // 
            // lblHostile
            // 
            lblHostile.AutoSize = true;
            lblHostile.Location = new Point(131, 122);
            lblHostile.Name = "lblHostile";
            lblHostile.Size = new Size(12, 15);
            lblHostile.TabIndex = 7;
            lblHostile.Text = "-";
            // 
            // lblDescriptionTitle
            // 
            lblDescriptionTitle.AutoSize = true;
            lblDescriptionTitle.Location = new Point(21, 156);
            lblDescriptionTitle.Name = "lblDescriptionTitle";
            lblDescriptionTitle.Size = new Size(39, 15);
            lblDescriptionTitle.TabIndex = 8;
            lblDescriptionTitle.Text = "Popis:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(21, 177);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(316, 110);
            txtDescription.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 352);
            Controls.Add(grpDetail);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lstNpc);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Správa NPC postav";
            grpDetail.ResumeLayout(false);
            grpDetail.PerformLayout();
            ResumeLayout(false);
        }
    }
}