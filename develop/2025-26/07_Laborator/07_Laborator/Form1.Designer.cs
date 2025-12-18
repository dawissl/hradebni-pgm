namespace _07_Laborator
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
            components = new System.ComponentModel.Container();
            ListSamples = new ListBox();
            label1 = new Label();
            BtnAddSample = new Button();
            button1 = new Button();
            label2 = new Label();
            ListTests = new ListBox();
            button2 = new Button();
            label3 = new Label();
            ListRequests = new ListBox();
            label4 = new Label();
            ListResults = new ListBox();
            PanelInfo = new Panel();
            TimerLab = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // ListSamples
            // 
            ListSamples.Font = new Font("Segoe UI", 15.75F);
            ListSamples.FormattingEnabled = true;
            ListSamples.ItemHeight = 30;
            ListSamples.Location = new Point(12, 44);
            ListSamples.Name = "ListSamples";
            ListSamples.Size = new Size(206, 394);
            ListSamples.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(75, 30);
            label1.TabIndex = 1;
            label1.Text = "Vzorky";
            // 
            // BtnAddSample
            // 
            BtnAddSample.Font = new Font("Segoe UI", 15.75F);
            BtnAddSample.Location = new Point(12, 455);
            BtnAddSample.Name = "BtnAddSample";
            BtnAddSample.Size = new Size(206, 48);
            BtnAddSample.TabIndex = 2;
            BtnAddSample.Text = "Nový vzorek";
            BtnAddSample.UseVisualStyleBackColor = true;
            BtnAddSample.Click += BtnAddSample_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F);
            button1.Location = new Point(236, 455);
            button1.Name = "button1";
            button1.Size = new Size(206, 48);
            button1.TabIndex = 5;
            button1.Text = "Nový test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(236, 11);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 4;
            label2.Text = "Testy";
            // 
            // ListTests
            // 
            ListTests.Font = new Font("Segoe UI", 15.75F);
            ListTests.FormattingEnabled = true;
            ListTests.ItemHeight = 30;
            ListTests.Location = new Point(236, 44);
            ListTests.Name = "ListTests";
            ListTests.Size = new Size(206, 394);
            ListTests.TabIndex = 3;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15.75F);
            button2.Location = new Point(459, 455);
            button2.Name = "button2";
            button2.Size = new Size(206, 48);
            button2.TabIndex = 8;
            button2.Text = "Přidat do fronty";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(459, 11);
            label3.Name = "label3";
            label3.Size = new Size(178, 30);
            label3.TabIndex = 7;
            label3.Text = "Fronta zpracování";
            // 
            // ListRequests
            // 
            ListRequests.Font = new Font("Segoe UI", 15.75F);
            ListRequests.FormattingEnabled = true;
            ListRequests.ItemHeight = 30;
            ListRequests.Location = new Point(459, 44);
            ListRequests.Name = "ListRequests";
            ListRequests.Size = new Size(206, 394);
            ListRequests.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.Location = new Point(681, 11);
            label4.Name = "label4";
            label4.Size = new Size(93, 30);
            label4.TabIndex = 10;
            label4.Text = "Výsledky";
            // 
            // ListResults
            // 
            ListResults.Font = new Font("Segoe UI", 15.75F);
            ListResults.FormattingEnabled = true;
            ListResults.ItemHeight = 30;
            ListResults.Location = new Point(681, 44);
            ListResults.Name = "ListResults";
            ListResults.Size = new Size(206, 394);
            ListResults.TabIndex = 9;
            // 
            // PanelInfo
            // 
            PanelInfo.Location = new Point(908, 44);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(277, 389);
            PanelInfo.TabIndex = 11;
            PanelInfo.Paint += PanelInfo_Paint;
            // 
            // TimerLab
            // 
            TimerLab.Enabled = true;
            TimerLab.Tick += TimerLab_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1197, 517);
            Controls.Add(PanelInfo);
            Controls.Add(label4);
            Controls.Add(ListResults);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(ListRequests);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(ListTests);
            Controls.Add(BtnAddSample);
            Controls.Add(label1);
            Controls.Add(ListSamples);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListSamples;
        private Label label1;
        private Button BtnAddSample;
        private Button button1;
        private Label label2;
        private ListBox ListTests;
        private Button button2;
        private Label label3;
        private ListBox ListRequests;
        private Label label4;
        private ListBox ListResults;
        private Panel PanelInfo;
        private System.Windows.Forms.Timer TimerLab;
    }
}
