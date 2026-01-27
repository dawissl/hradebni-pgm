namespace _11_ActivityTracker
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
        private System.Windows.Forms.Button btnLoadCsv;
        private System.Windows.Forms.ComboBox cmbActivities;
        private System.Windows.Forms.DataGridView dgvTrainings;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblTopAthletes;
        private System.Windows.Forms.ListBox lstTopAthletes;
        private System.Windows.Forms.Label lblTopAthleteDay;
        private System.Windows.Forms.DateTimePicker dtpSpecificDay;
        private System.Windows.Forms.TextBox txtTopAthleteDay;

        private void InitializeComponent()
        {
            btnLoadCsv = new Button();
            cmbActivities = new ComboBox();
            dgvTrainings = new DataGridView();
            panelStats = new Panel();
            lblTopAthletes = new Label();
            lstTopAthletes = new ListBox();
            lblTopAthleteDay = new Label();
            dtpSpecificDay = new DateTimePicker();
            txtTopAthleteDay = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).BeginInit();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadCsv
            // 
            btnLoadCsv.Location = new Point(12, 12);
            btnLoadCsv.Name = "btnLoadCsv";
            btnLoadCsv.Size = new Size(100, 30);
            btnLoadCsv.TabIndex = 0;
            btnLoadCsv.Text = "Načíst CSV";
            btnLoadCsv.UseVisualStyleBackColor = true;
            btnLoadCsv.Click += btnLoadCsv_Click;
            // 
            // cmbActivities
            // 
            cmbActivities.Location = new Point(130, 12);
            cmbActivities.Name = "cmbActivities";
            cmbActivities.Size = new Size(200, 23);
            cmbActivities.TabIndex = 1;
            cmbActivities.SelectedIndexChanged += cmbActivities_SelectedIndexChanged;
            // 
            // dgvTrainings
            // 
            dgvTrainings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainings.Location = new Point(12, 50);
            dgvTrainings.Name = "dgvTrainings";
            dgvTrainings.Size = new Size(694, 234);
            dgvTrainings.TabIndex = 2;
            // 
            // panelStats
            // 
            panelStats.Controls.Add(lblTopAthletes);
            panelStats.Controls.Add(lstTopAthletes);
            panelStats.Controls.Add(lblTopAthleteDay);
            panelStats.Controls.Add(dtpSpecificDay);
            panelStats.Controls.Add(txtTopAthleteDay);
            panelStats.Dock = DockStyle.Bottom;
            panelStats.Location = new Point(0, 300);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(800, 150);
            panelStats.TabIndex = 3;
            // 
            // lblTopAthletes
            // 
            lblTopAthletes.Location = new Point(10, 10);
            lblTopAthletes.Name = "lblTopAthletes";
            lblTopAthletes.Size = new Size(200, 20);
            lblTopAthletes.TabIndex = 0;
            lblTopAthletes.Text = "Top 5 aktivních atletů";
            // 
            // lstTopAthletes
            // 
            lstTopAthletes.ItemHeight = 15;
            lstTopAthletes.Location = new Point(10, 35);
            lstTopAthletes.Name = "lstTopAthletes";
            lstTopAthletes.Size = new Size(300, 94);
            lstTopAthletes.TabIndex = 1;
            // 
            // lblTopAthleteDay
            // 
            lblTopAthleteDay.Location = new Point(330, 10);
            lblTopAthleteDay.Name = "lblTopAthleteDay";
            lblTopAthleteDay.Size = new Size(200, 20);
            lblTopAthleteDay.TabIndex = 2;
            lblTopAthleteDay.Text = "Nejaktivnější atlet dne";
            // 
            // dtpSpecificDay
            // 
            dtpSpecificDay.Location = new Point(330, 56);
            dtpSpecificDay.Name = "dtpSpecificDay";
            dtpSpecificDay.Size = new Size(200, 23);
            dtpSpecificDay.TabIndex = 3;
            dtpSpecificDay.ValueChanged += dtpSpecificDay_ValueChanged;
            // 
            // txtTopAthleteDay
            // 
            txtTopAthleteDay.Location = new Point(330, 88);
            txtTopAthleteDay.Name = "txtTopAthleteDay";
            txtTopAthleteDay.ReadOnly = true;
            txtTopAthleteDay.Size = new Size(200, 23);
            txtTopAthleteDay.TabIndex = 4;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoadCsv);
            Controls.Add(cmbActivities);
            Controls.Add(dgvTrainings);
            Controls.Add(panelStats);
            Name = "Form1";
            Text = "Activity Tracker";
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            ResumeLayout(false);
        }


        #endregion
    }
}
