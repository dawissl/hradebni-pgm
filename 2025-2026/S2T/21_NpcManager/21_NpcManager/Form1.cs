namespace _21_NpcManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDialog_Click(object sender, EventArgs e)
        {
            NpcDialog dialog = new NpcDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                NpcList.Items.Add(dialog.Character);
            }
        }

        private void NpcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpcCharacter character = (NpcCharacter)NpcList.Items[NpcList.SelectedIndex];
            LblInfo.Text = character.Friendly.ToString();
        }
    }
}
