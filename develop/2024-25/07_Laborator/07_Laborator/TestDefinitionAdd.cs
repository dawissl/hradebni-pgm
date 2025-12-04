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
    public partial class TestDefinitionAdd : Form
    {

        private string name;
        private string type;
        private double threshold;
        private int time;

        public string Name {  get { return name; } }
        public string Type { get { return type; } }
        public double Threashold { get { return threshold; } }
        public int Time { get { return time; } }    
        public TestDefinitionAdd()
        {
            InitializeComponent();
        }

        private void BtnAddTest_Click(object sender, EventArgs e)
        {
             if(ComboSampleType.SelectedIndex == -1) MessageBox.Show("Je třeba vybrat typ vzorku potřebný pro test");
             if(TxtTestName.Text.Trim() == "") MessageBox.Show("Zadejte jméno test");
            name = TxtTestName.Text;
            type = ComboSampleType.Text;
            threshold = (double) NumThreshold.Value;
            time = (int) NumTime.Value;
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
