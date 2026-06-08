using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dialogy
{
    public partial class AddFilm : Form
    {
        private Film f = null;

        public Film GetFilm { get { return f; } }
        public AddFilm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            f = new Film(textBox1.Text, textBox2.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
