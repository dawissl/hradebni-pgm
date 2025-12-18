namespace GroupData
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
            ListCity = new ListBox();
            PanelCity = new Panel();
            label1 = new Label();
            LblDetail = new Label();
            ListGroup = new ListBox();
            SuspendLayout();
            // 
            // ListCity
            // 
            ListCity.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ListCity.FormattingEnabled = true;
            ListCity.ItemHeight = 30;
            ListCity.Location = new Point(541, 12);
            ListCity.Name = "ListCity";
            ListCity.Size = new Size(321, 274);
            ListCity.TabIndex = 0;
            // 
            // PanelCity
            // 
            PanelCity.Location = new Point(12, 12);
            PanelCity.Name = "PanelCity";
            PanelCity.Size = new Size(500, 500);
            PanelCity.TabIndex = 1;
            PanelCity.Paint += PanelCity_Paint;
            PanelCity.MouseDown += PanelCity_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(541, 309);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 2;
            label1.Text = "Detail";
            // 
            // LblDetail
            // 
            LblDetail.BorderStyle = BorderStyle.FixedSingle;
            LblDetail.Location = new Point(541, 337);
            LblDetail.Name = "LblDetail";
            LblDetail.Size = new Size(638, 175);
            LblDetail.TabIndex = 3;
            // 
            // ListGroup
            // 
            ListGroup.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ListGroup.FormattingEnabled = true;
            ListGroup.ItemHeight = 30;
            ListGroup.Location = new Point(880, 12);
            ListGroup.Name = "ListGroup";
            ListGroup.Size = new Size(299, 274);
            ListGroup.TabIndex = 4;
            ListGroup.SelectedIndexChanged += ListGroup_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 539);
            Controls.Add(ListGroup);
            Controls.Add(LblDetail);
            Controls.Add(label1);
            Controls.Add(PanelCity);
            Controls.Add(ListCity);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListCity;
        private Panel PanelCity;
        private Label label1;
        private Label LblDetail;
        private ListBox ListGroup;
    }
}
