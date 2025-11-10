namespace _06_Obrazce
{
    public partial class Form1 : Form
    {
        private int xAxe = 0, yAxe = 0;
        private bool draw = false;
        public Form1()
        {
            InitializeComponent();
            LblLocation.Text = $"[{xAxe}, {yAxe}]";
            ComboPen.SelectedIndex = 0;
            ComboColor.SelectedIndex = 0;
        }

        private void PanelImages_MouseDown(object sender, MouseEventArgs e)
        {
            xAxe = e.X;
            yAxe = e.Y;
            LblLocation.Text = $"[{xAxe}, {yAxe}]";
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            if (NumWidth.Value == 0 || NumHeight.Value == 0)
                MessageBox.Show("Jeden z rozmìrù je nulový obrazec nepùjde vidìt.");
            draw = true;
            PanelImages.Refresh();
        }

        private void PanelImages_Paint(object sender, PaintEventArgs e)
        {
            if (!draw) return;
            Graphics g = e.Graphics;
            SolidBrush b;
            
            switch (ComboColor.Text)
            {
                case "RED":
                    b = new SolidBrush(Color.Red);
                    break;
                case "BLUE":
                    b = new SolidBrush(Color.Blue);
                    break;
                case "GREEN":
                    b = new SolidBrush(Color.Green);
                    break;
                default:
                    b = new SolidBrush(Color.Black);
                    break;

            }
            Pen p = new Pen(b, float.Parse(ComboPen.Text));

            Rectangle rec = new Rectangle(xAxe, yAxe, (int)NumWidth.Value, (int)NumHeight.Value);
            if (CheckFill.Checked)
            {

                if (RadEllipse.Checked)
                    g.FillEllipse(b, rec);
                else
                    g.FillRectangle(b, rec);
            }
            else
            {
                if (RadEllipse.Checked)
                    g.DrawEllipse(p, rec);
                else
                    g.DrawRectangle(p, rec);
            }
        }

        private void CheckFill_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFill.Checked)
            {
                ComboPen.Enabled = false;
            }
            else
            {
                ComboPen.Enabled = true;
            }
        }
    }
}
