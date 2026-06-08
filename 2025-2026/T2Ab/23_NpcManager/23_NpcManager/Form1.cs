using System.Windows.Forms;

namespace _23_NpcManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NpcDialog addNpc = new NpcDialog();

            if (addNpc.ShowDialog() == DialogResult.OK)
            {
                lstNpc.Items.Add(addNpc.Npc);
            }

        }

        private void lstNpc_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpcCharacter? character = lstNpc.SelectedItem as NpcCharacter;
            if (character != null)
            {
                lblName.Text = character.Name;
                lblRace.Text = character.Race;
                lblLevel.Text = $"{character.Level}";
                lblHostile.Text = character.Friendly ? "pøátelská" : "nepøátelská";
                txtDescription.Text = character.Description;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstNpc.SelectedIndex != -1)
            {
                lstNpc.Items.RemoveAt(lstNpc.SelectedIndex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // pokud není žádná položka vybrání vrací se -1
            if (lstNpc.SelectedIndex != -1)
            {
                NpcCharacter edit = lstNpc.SelectedItem as NpcCharacter;
                NpcDialog editNpc = new NpcDialog(edit);
                if (editNpc.ShowDialog() == DialogResult.OK)
                {
                    lstNpc.Items[lstNpc.SelectedIndex] = editNpc.Npc;
                }

            }
        }
    }
}
