namespace _16_GarzTanky
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
            groupBox1 = new GroupBox();
            BtnAdd = new Button();
            label4 = new Label();
            TrackKanon = new TrackBar();
            label3 = new Label();
            TrackRychlost = new TrackBar();
            label2 = new Label();
            TrackPancir = new TrackBar();
            label1 = new Label();
            TrackUroven = new TrackBar();
            ComboNarod = new ComboBox();
            ComboTyp = new ComboBox();
            TxtName = new TextBox();
            groupBox2 = new GroupBox();
            LblPrehled = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackKanon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackRychlost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackPancir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackUroven).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnAdd);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TrackKanon);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TrackRychlost);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TrackPancir);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TrackUroven);
            groupBox1.Controls.Add(ComboNarod);
            groupBox1.Controls.Add(ComboTyp);
            groupBox1.Controls.Add(TxtName);
            groupBox1.Font = new Font("Segoe UI", 15.75F);
            groupBox1.Location = new Point(33, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 555);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vytvoření nového tanku";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(21, 494);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(230, 55);
            BtnAdd.TabIndex = 11;
            BtnAdd.Text = "Vložit";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 410);
            label4.Name = "label4";
            label4.Size = new Size(72, 30);
            label4.TabIndex = 10;
            label4.Text = "Kanón";
            // 
            // TrackKanon
            // 
            TrackKanon.Location = new Point(21, 443);
            TrackKanon.Maximum = 200;
            TrackKanon.Minimum = 20;
            TrackKanon.Name = "TrackKanon";
            TrackKanon.Size = new Size(246, 45);
            TrackKanon.TabIndex = 9;
            TrackKanon.Value = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 343);
            label3.Name = "label3";
            label3.Size = new Size(91, 30);
            label3.TabIndex = 8;
            label3.Text = "Rychlost";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // TrackRychlost
            // 
            TrackRychlost.Location = new Point(21, 376);
            TrackRychlost.Maximum = 50;
            TrackRychlost.Minimum = 10;
            TrackRychlost.Name = "TrackRychlost";
            TrackRychlost.Size = new Size(246, 45);
            TrackRychlost.TabIndex = 7;
            TrackRychlost.Value = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 276);
            label2.Name = "label2";
            label2.Size = new Size(69, 30);
            label2.TabIndex = 6;
            label2.Text = "Pancíř";
            // 
            // TrackPancir
            // 
            TrackPancir.Location = new Point(21, 309);
            TrackPancir.Maximum = 100;
            TrackPancir.Minimum = 10;
            TrackPancir.Name = "TrackPancir";
            TrackPancir.Size = new Size(246, 45);
            TrackPancir.TabIndex = 5;
            TrackPancir.Value = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 203);
            label1.Name = "label1";
            label1.Size = new Size(79, 30);
            label1.TabIndex = 4;
            label1.Text = "Úroveň";
            // 
            // TrackUroven
            // 
            TrackUroven.Location = new Point(21, 236);
            TrackUroven.Minimum = 1;
            TrackUroven.Name = "TrackUroven";
            TrackUroven.Size = new Size(246, 45);
            TrackUroven.TabIndex = 3;
            TrackUroven.Value = 1;
            // 
            // ComboNarod
            // 
            ComboNarod.FormattingEnabled = true;
            ComboNarod.Items.AddRange(new object[] { "britové", "američani", "rusové", "francouzi" });
            ComboNarod.Location = new Point(21, 156);
            ComboNarod.Name = "ComboNarod";
            ComboNarod.Size = new Size(224, 38);
            ComboNarod.TabIndex = 2;
            // 
            // ComboTyp
            // 
            ComboTyp.FormattingEnabled = true;
            ComboTyp.Items.AddRange(new object[] { "lehký", "střední", "tšžký" });
            ComboTyp.Location = new Point(21, 99);
            ComboTyp.Name = "ComboTyp";
            ComboTyp.Size = new Size(224, 38);
            ComboTyp.TabIndex = 1;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(21, 46);
            TxtName.Name = "TxtName";
            TxtName.PlaceholderText = "Název tanku";
            TxtName.Size = new Size(224, 35);
            TxtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblPrehled);
            groupBox2.Font = new Font("Segoe UI", 15.75F);
            groupBox2.Location = new Point(352, 18);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(385, 555);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Přehled garáže";
            // 
            // LblPrehled
            // 
            LblPrehled.AutoSize = true;
            LblPrehled.Location = new Point(23, 46);
            LblPrehled.Name = "LblPrehled";
            LblPrehled.Size = new Size(0, 30);
            LblPrehled.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 597);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackKanon).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackRychlost).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackPancir).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackUroven).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label4;
        private TrackBar TrackKanon;
        private Label label3;
        private TrackBar TrackRychlost;
        private Label label2;
        private TrackBar TrackPancir;
        private Label label1;
        private TrackBar TrackUroven;
        private ComboBox ComboNarod;
        private ComboBox ComboTyp;
        private TextBox TxtName;
        private GroupBox groupBox2;
        private Button BtnAdd;
        private Label LblPrehled;
    }
}
