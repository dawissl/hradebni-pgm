namespace Pocasi
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.75F);
            textBox1.Location = new Point(125, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 35);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.Location = new Point(43, 44);
            label1.Name = "label1";
            label1.Size = new Size(78, 30);
            label1.TabIndex = 1;
            label1.Text = "teplota";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(43, 83);
            label2.Name = "label2";
            label2.Size = new Size(78, 30);
            label2.TabIndex = 3;
            label2.Text = "vlhkost";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15.75F);
            textBox2.Location = new Point(125, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(168, 35);
            textBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(43, 123);
            label3.Name = "label3";
            label3.Size = new Size(70, 30);
            label3.TabIndex = 5;
            label3.Text = "srážky";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 15.75F);
            textBox3.Location = new Point(125, 115);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(168, 35);
            textBox3.TabIndex = 4;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(361, 14);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(357, 429);
            listBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(48, 205);
            button1.Name = "button1";
            button1.Size = new Size(176, 87);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private ListBox listBox1;
        private Button button1;
    }
}
