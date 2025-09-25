using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace _01_Filmoteka
{
    public partial class EditFilm : Form
    {
        private string note;
        private int rating;
        // properties dialogu umožní podívat se na hodnoty i po uzavření
        public string Note {get{ return note; } }
        public int Rating {get{ return rating; } }
        public EditFilm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            note = TxtNote.Text;
            rating = int.Parse(TxtRating.Text);
            DialogResult = DialogResult.OK; // indefikace, jak byl dialog uzavřen
            Close();
        }
    }
}
