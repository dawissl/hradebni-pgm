using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Laborator
{
    public partial class SampleAdd : Form
    {
        private string name;
        private string type;
        public string Name { get { return name; } }
        public string Type { get { return type; } }
        public SampleAdd()
        {
            InitializeComponent();
        }

        private void BtnAddSample_Click(object sender, EventArgs e)
        {
            name = TxtSampleName.Text;
            type = ComboSampleType.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
