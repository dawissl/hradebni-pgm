using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Linq;

namespace _23_NpcManager
{
    public partial class NpcDialog : Form
    {
        private NpcCharacter character;

        public NpcCharacter Npc { get { return character; } }

        public NpcDialog()
        {
            InitializeComponent();
        }

        public NpcDialog(NpcCharacter editedCharacter) : this()
        {
            Text = $"Editace Npc {editedCharacter.Name} ";
            txtName.Text = editedCharacter.Name;
            nudLevel.Value = editedCharacter.Level;
            chkHostile.Checked = editedCharacter.Friendly;
            cmbRace.Text = editedCharacter.Race;
            txtDescription.Text = editedCharacter.Description;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            character = new NpcCharacter(txtName.Text, (int)nudLevel.Value, chkHostile.Checked, cmbRace.Text, txtDescription.Text);
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
