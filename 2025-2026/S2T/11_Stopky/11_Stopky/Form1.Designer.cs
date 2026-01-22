namespace _11_Stopky
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
            label1 = new Label();
            LblTime = new Label();
            BtnStart = new Button();
            BtnStop = new Button();
            TimerTime = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F);
            label1.Location = new Point(26, 30);
            label1.Name = "label1";
            label1.Size = new Size(102, 65);
            label1.TabIndex = 0;
            label1.Text = "Čas";
            // 
            // LblTime
            // 
            LblTime.AutoSize = true;
            LblTime.Font = new Font("Segoe UI", 36F);
            LblTime.Location = new Point(156, 30);
            LblTime.Name = "LblTime";
            LblTime.Size = new Size(256, 65);
            LblTime.TabIndex = 1;
            LblTime.Text = "00 : 00 : 00";
            // 
            // BtnStart
            // 
            BtnStart.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnStart.Location = new Point(26, 99);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(169, 53);
            BtnStart.TabIndex = 2;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnStop
            // 
            BtnStop.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnStop.Location = new Point(225, 99);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(169, 53);
            BtnStop.TabIndex = 3;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // TimerTime
            // 
            TimerTime.Tick += TimerTime_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 211);
            Controls.Add(BtnStop);
            Controls.Add(BtnStart);
            Controls.Add(LblTime);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label LblTime;
        private Button BtnStart;
        private Button BtnStop;
        private System.Windows.Forms.Timer TimerTime;
    }
}
