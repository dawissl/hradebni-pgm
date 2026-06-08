using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_NpcManager
{
    public partial class NpcDialog : Form
    {
        private NpcCharacter _character;

        public NpcCharacter Character { get { return _character; } }
        public NpcDialog()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            if (TxtName.Text == string.Empty)
            {
                MessageBox.Show("Jméno nesmí být prázdné");
                return;
            }
            if (NumLvl.Value < 1 || NumLvl.Value > 20)
            {
                MessageBox.Show("Úroveň musí být v rozsahu <1,20>");
                return;
            }
            _character = new NpcCharacter(TxtName.Text, (int)NumLvl.Value, CheckFriendly.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
