using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Filmoteka
{
    public partial class Form2 : Form
    {
        // zpřístupnění vlastností dialogového okna
        private string n;
        private string d;
        public string MovieName { get {  return n; } }
        public string MovieDirector { get {  return d; } }
        public Form2()
        {
            InitializeComponent();
        }

        // parametrizovaný konstruktor, který předvyplní hodnoty do vstupních polí
        // ideální například pro následnou editaci položky
        public Form2(string n,string d)
        {
            InitializeComponent();
            this.n = n;
            this.d = d;
            txtDirectorDialog.Text = d;
            txtNameDialog.Text = n;
        }

        private void Btn_AddFilm_Click(object sender, EventArgs e)
        {
            n = txtNameDialog.Text;
            d = txtDirectorDialog.Text;
            DialogResult = DialogResult.OK; // nastavení stavu po uzavření
            Close();
        }
    }
}
