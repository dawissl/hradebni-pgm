using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KoloOsudu
{
    public partial class Form1 : Form
    {
        private List<string> studenti = new List<string>();
        private Random rnd = new Random();
        private int tickCount = 0;
        private int maxTicks = 60;
        private string aktualniJmeno = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNacist_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                studenti = File.ReadAllLines(openFileDialog1.FileName).ToList();
                lstStudenti.DataSource = null;
                lstStudenti.DataSource = studenti;
            }
        }

        private void btnSpustit_Click(object sender, EventArgs e)
        {
            if (studenti.Count == 0)
            {
                MessageBox.Show("Seznam studentů je prázdný.");
                return;
            }

            tickCount = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            int index = rnd.Next(studenti.Count);
            aktualniJmeno = studenti[index];
            lblVybrany.Text = aktualniJmeno;

            lblVybrany.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblVybrany.ForeColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            if (tickCount >= maxTicks)
            {
                timer.Stop();
                //MessageBox.Show($"🎉 Vybraný student: {aktualniJmeno} 🎉", "Výsledek", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chkOdebrat.Checked)
                {
                    studenti.Remove(aktualniJmeno);
                    lstStudenti.DataSource = null;
                    lstStudenti.DataSource = studenti;
                }
            }
        }
    }
}
