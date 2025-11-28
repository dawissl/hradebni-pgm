namespace _07_Laborator
{
    partial class TestDefinitionAdd
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
            label2 = new Label();
            label1 = new Label();
            BtnAddTest = new Button();
            ComboSampleType = new ComboBox();
            TxtTestName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            NumThreshold = new NumericUpDown();
            NumTime = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTime).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(28, 94);
            label2.Name = "label2";
            label2.Size = new Size(130, 32);
            label2.TabIndex = 9;
            label2.Text = "Typ vzorku";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(28, 25);
            label1.Name = "label1";
            label1.Size = new Size(140, 32);
            label1.TabIndex = 8;
            label1.Text = "Název testu";
            // 
            // BtnAddTest
            // 
            BtnAddTest.Font = new Font("Segoe UI", 18F);
            BtnAddTest.Location = new Point(322, 285);
            BtnAddTest.Name = "BtnAddTest";
            BtnAddTest.Size = new Size(242, 74);
            BtnAddTest.TabIndex = 7;
            BtnAddTest.Text = "Přidat test";
            BtnAddTest.UseVisualStyleBackColor = true;
            BtnAddTest.Click += BtnAddTest_Click;
            // 
            // ComboSampleType
            // 
            ComboSampleType.Font = new Font("Segoe UI", 18F);
            ComboSampleType.FormattingEnabled = true;
            ComboSampleType.Items.AddRange(new object[] { "VODA", "PŮDA", "SLINY", "KREV" });
            ComboSampleType.Location = new Point(248, 94);
            ComboSampleType.Name = "ComboSampleType";
            ComboSampleType.Size = new Size(316, 40);
            ComboSampleType.TabIndex = 6;
            // 
            // TxtTestName
            // 
            TxtTestName.Font = new Font("Segoe UI", 18F);
            TxtTestName.Location = new Point(248, 25);
            TxtTestName.Name = "TxtTestName";
            TxtTestName.Size = new Size(316, 39);
            TxtTestName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(28, 168);
            label3.Name = "label3";
            label3.Size = new Size(196, 32);
            label3.TabIndex = 10;
            label3.Text = "Prahová hodnota";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F);
            label4.Location = new Point(28, 229);
            label4.Name = "label4";
            label4.Size = new Size(138, 32);
            label4.TabIndex = 11;
            label4.Text = "Doba trvání";
            // 
            // NumThreshold
            // 
            NumThreshold.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NumThreshold.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumThreshold.Location = new Point(248, 168);
            NumThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            NumThreshold.Name = "NumThreshold";
            NumThreshold.Size = new Size(316, 39);
            NumThreshold.TabIndex = 12;
            // 
            // NumTime
            // 
            NumTime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            NumTime.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            NumTime.Location = new Point(248, 222);
            NumTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumTime.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            NumTime.Name = "NumTime";
            NumTime.Size = new Size(316, 39);
            NumTime.TabIndex = 13;
            NumTime.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // TestDefinitionAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 377);
            Controls.Add(NumTime);
            Controls.Add(NumThreshold);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnAddTest);
            Controls.Add(ComboSampleType);
            Controls.Add(TxtTestName);
            Name = "TestDefinitionAdd";
            Text = "Přidání nového testu";
            ((System.ComponentModel.ISupportInitialize)NumThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button BtnAddTest;
        private ComboBox ComboSampleType;
        private TextBox TxtTestName;
        private Label label3;
        private Label label4;
        private NumericUpDown NumThreshold;
        private NumericUpDown NumTime;
    }
}