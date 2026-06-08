using System;
using System.Windows.Forms;


namespace CityClusters
{
    public class AddCityForm : Form
    {
        public City CreatedCity { get; private set; }


        TextBox name = new TextBox();
        NumericUpDown x = new NumericUpDown();
        NumericUpDown y = new NumericUpDown();
        NumericUpDown population = new NumericUpDown();
        NumericUpDown infected = new NumericUpDown();
        CheckBox capital = new CheckBox { Text = "Krajské město" };
        Button ok = new Button { Text = "Přidat" };


        public AddCityForm()
        {
            Text = "Přidat město";
            Width = 250;
            Height = 300;


            var layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown
            };


            x.Maximum = 500;
            y.Maximum = 300;
            population.Maximum = 1_000_000;
            infected.Maximum = 1_000_000;


            layout.Controls.AddRange(new Control[]
            {
            new Label{Text="Název"}, name,
            new Label{Text="X"}, x,
            new Label{Text="Y"}, y,
            new Label{Text="Populace"}, population,
            new Label{Text="Nakažení"}, infected,
            capital,
             ok
            });


            ok.Click += Ok_Click;
            Controls.Add(layout);
        }


        private void Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Zadej název města.");
                return;
            }


        }
    }
}