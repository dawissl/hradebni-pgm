namespace _07_Laborator
{
    partial class SampleAdd
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
            TxtSampleName = new TextBox();
            ComboSampleType = new ComboBox();
            BtnAddSample = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TxtSampleName
            // 
            TxtSampleName.Font = new Font("Segoe UI", 18F);
            TxtSampleName.Location = new Point(197, 21);
            TxtSampleName.Name = "TxtSampleName";
            TxtSampleName.Size = new Size(316, 39);
            TxtSampleName.TabIndex = 0;
            // 
            // ComboSampleType
            // 
            ComboSampleType.Font = new Font("Segoe UI", 18F);
            ComboSampleType.FormattingEnabled = true;
            ComboSampleType.Items.AddRange(new object[] { "VODA", "PŮDA", "SLINY", "KREV" });
            ComboSampleType.Location = new Point(197, 90);
            ComboSampleType.Name = "ComboSampleType";
            ComboSampleType.Size = new Size(316, 40);
            ComboSampleType.TabIndex = 1;
            // 
            // BtnAddSample
            // 
            BtnAddSample.Font = new Font("Segoe UI", 18F);
            BtnAddSample.Location = new Point(271, 163);
            BtnAddSample.Name = "BtnAddSample";
            BtnAddSample.Size = new Size(242, 74);
            BtnAddSample.TabIndex = 2;
            BtnAddSample.Text = "Přidat vzorek";
            BtnAddSample.UseVisualStyleBackColor = true;
            BtnAddSample.Click += BtnAddSample_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(158, 32);
            label1.TabIndex = 3;
            label1.Text = "Název vzorku";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(130, 32);
            label2.TabIndex = 4;
            label2.Text = "Typ vzorku";
            // 
            // SampleAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 257);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnAddSample);
            Controls.Add(ComboSampleType);
            Controls.Add(TxtSampleName);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Přidání nového vzorku";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtSampleName;
        private ComboBox ComboSampleType;
        private Button BtnAddSample;
        private Label label1;
        private Label label2;
    }
}