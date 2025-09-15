namespace _00_Boiler
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
            Btn_Config = new Button();
            label1 = new Label();
            TxtPower = new TextBox();
            TxtVolume = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            BtnDrain = new Button();
            ProgVolume = new ProgressBar();
            LblTemperature = new Label();
            label3 = new Label();
            BtnControl = new Button();
            Timer = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_Config
            // 
            Btn_Config.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Btn_Config.Location = new Point(35, 118);
            Btn_Config.Name = "Btn_Config";
            Btn_Config.Size = new Size(240, 60);
            Btn_Config.TabIndex = 0;
            Btn_Config.Text = "Inicializuj boiler";
            Btn_Config.UseVisualStyleBackColor = true;
            Btn_Config.Click += Btn_Config_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(26, 43);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 1;
            label1.Text = "Výkon (kW)";
            // 
            // TxtPower
            // 
            TxtPower.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TxtPower.Location = new Point(140, 40);
            TxtPower.Name = "TxtPower";
            TxtPower.Size = new Size(135, 33);
            TxtPower.TabIndex = 2;
            // 
            // TxtVolume
            // 
            TxtVolume.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TxtVolume.Location = new Point(140, 79);
            TxtVolume.Name = "TxtVolume";
            TxtVolume.Size = new Size(135, 33);
            TxtVolume.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(26, 82);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 3;
            label2.Text = "Objem (l)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtVolume);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TxtPower);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Btn_Config);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            groupBox1.Location = new Point(25, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(308, 204);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nastavení nového boileru";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnDrain);
            groupBox2.Controls.Add(ProgVolume);
            groupBox2.Controls.Add(LblTemperature);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(BtnControl);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            groupBox2.Location = new Point(366, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(308, 204);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ovládání boileru";
            // 
            // BtnDrain
            // 
            BtnDrain.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BtnDrain.Location = new Point(150, 123);
            BtnDrain.Name = "BtnDrain";
            BtnDrain.Size = new Size(124, 60);
            BtnDrain.TabIndex = 5;
            BtnDrain.Text = "Vypouštět";
            BtnDrain.UseVisualStyleBackColor = true;
            BtnDrain.Click += BtnDrain_Click;
            // 
            // ProgVolume
            // 
            ProgVolume.Location = new Point(23, 94);
            ProgVolume.Name = "ProgVolume";
            ProgVolume.Size = new Size(279, 23);
            ProgVolume.TabIndex = 7;
            // 
            // LblTemperature
            // 
            LblTemperature.BorderStyle = BorderStyle.Fixed3D;
            LblTemperature.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblTemperature.Location = new Point(150, 37);
            LblTemperature.Name = "LblTemperature";
            LblTemperature.Size = new Size(109, 25);
            LblTemperature.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(23, 37);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 5;
            label3.Text = "Teplota (°C)";
            // 
            // BtnControl
            // 
            BtnControl.BackColor = Color.IndianRed;
            BtnControl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            BtnControl.Location = new Point(23, 123);
            BtnControl.Name = "BtnControl";
            BtnControl.Size = new Size(115, 60);
            BtnControl.TabIndex = 0;
            BtnControl.Text = "Vypnuto";
            BtnControl.UseVisualStyleBackColor = false;
            BtnControl.Click += BtnControl_Click;
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Interval = 200;
            Timer.Tick += Timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 268);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_Config;
        private Label label1;
        private TextBox TxtPower;
        private TextBox TxtVolume;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ProgressBar ProgVolume;
        private Label LblTemperature;
        private Label label3;
        private Button BtnControl;
        private System.Windows.Forms.Timer Timer;
        private Button BtnDrain;
    }
}
