namespace _04_CisteniDat
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
            TxtInput = new TextBox();
            label1 = new Label();
            BtnParse = new Button();
            label2 = new Label();
            LblResult = new Label();
            label3 = new Label();
            LblDateTime = new Label();
            SuspendLayout();
            // 
            // TxtInput
            // 
            TxtInput.Location = new Point(34, 51);
            TxtInput.Multiline = true;
            TxtInput.Name = "TxtInput";
            TxtInput.Size = new Size(308, 323);
            TxtInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(34, 18);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 1;
            label1.Text = "Vstupní text";
            // 
            // BtnParse
            // 
            BtnParse.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            BtnParse.Location = new Point(37, 389);
            BtnParse.Name = "BtnParse";
            BtnParse.Size = new Size(305, 39);
            BtnParse.TabIndex = 2;
            BtnParse.Text = "Zpracuj";
            BtnParse.UseVisualStyleBackColor = true;
            BtnParse.Click += BtnParse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(367, 18);
            label2.Name = "label2";
            label2.Size = new Size(81, 30);
            label2.TabIndex = 3;
            label2.Text = "Výstup";
            // 
            // LblResult
            // 
            LblResult.BorderStyle = BorderStyle.Fixed3D;
            LblResult.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblResult.Location = new Point(367, 51);
            LblResult.Name = "LblResult";
            LblResult.Size = new Size(305, 323);
            LblResult.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(367, 398);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 5;
            label3.Text = "Datum a čas";
            // 
            // LblDateTime
            // 
            LblDateTime.BorderStyle = BorderStyle.Fixed3D;
            LblDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LblDateTime.Location = new Point(505, 398);
            LblDateTime.Name = "LblDateTime";
            LblDateTime.Size = new Size(167, 30);
            LblDateTime.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 445);
            Controls.Add(LblDateTime);
            Controls.Add(label3);
            Controls.Add(LblResult);
            Controls.Add(label2);
            Controls.Add(BtnParse);
            Controls.Add(label1);
            Controls.Add(TxtInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtInput;
        private Label label1;
        private Button BtnParse;
        private Label label2;
        private Label LblResult;
        private Label label3;
        private Label LblDateTime;
    }
}