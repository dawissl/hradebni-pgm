using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace _06_ObrazoveUpravy
{
    /// <summary>
    /// Hlavní formuláø aplikace pro demonstraci základních obrazových úprav.
    /// Obsahuje naètení, zobrazení, úpravy a uložení obrázku.
    /// </summary>
    public partial class Form1 : Form
    {
        // Uchovává aktuálnì naètený obrázek (originál)
        private Bitmap image;

        /// <summary>
        /// Konstruktor formuláøe – inicializuje komponenty GUI.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nabídka "Otevøít" – umožòuje uživateli vybrat soubor z disku
        /// a naète ho jako obrázek typu Bitmap.
        /// </summary>
        private void otevøítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // Po potvrzení dialogu (OK) naèteme soubor
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(ofd.FileName);   // vytvoøíme kopii obrázku
                PicDefault.Image = image;           // zobrazíme ji v PictureBoxu
            }
        }

        /// <summary>
        /// Nabídka "Prahování" – volá metodu Thresholding z tøídy ImageProcessing
        /// a výsledek zobrazí v pravém PictureBoxu (PicEdit).
        /// </summary>
        private void prahováníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Použije prah 150 (na stupnici 0–255)
            PicEdit.Image = ImageProcessing.Thresholding(image, 150);
        }

        /// <summary>
        /// Nabídka "Šum – sùl a pepø" – pøidá do obrázku náhodný šum pomocí metody SaltAndPeper.
        /// </summary>
        private void šumSùlAPepøToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Parametry: 10 % bílé "soli", 4 % èerného "pepøe"
            PicEdit.Image = ImageProcessing.SaltAndPeper(image, 0.1, 0.04);
        }

        /// <summary>
        /// Nabídka "Mediánový filtr" – aplikuje filtraci obrazu pomocí masky 5×5 pixelù.
        /// Používá se k odstranìní šumu (napø. soli a pepøe).
        /// </summary>
        private void mediánovýFiltrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicEdit.Image = ImageProcessing.MedianFilter(image, 5);
        }

        /// <summary>
        /// Nabídka "Uložit" – uloží upravený obrázek z pravého panelu jako .png soubor.
        /// </summary>
        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();

            if (sfg.ShowDialog() == DialogResult.OK)
            {
                // Výsledek se uloží s pøíponou .png (i když uživatel nevybere formát)
                PicEdit.Image.Save($"{sfg.FileName}.png");
            }
        }

        /// <summary>
        /// Nabídka "Pøemístit" – pøenese upravený obrázek zpìt do levého panelu.
        /// To umožní aplikovat na výsledek další úpravy.
        /// </summary>
        private void pøemístitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(PicEdit.Image);   // vytvoøí novou bitmapu z upraveného obrázku
            PicDefault.Image = PicEdit.Image;    // zobrazí ji vlevo
        }

        private void zesvìtlitztmavitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicEdit.Image = ImageProcessing.Brightness(image, 20);

        }

        private void obarvitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicEdit.Image = ImageProcessing.Greyscale(image);
        }

        private void rotaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicEdit.Image = ImageProcessing.Rotate(image);

        }

        private void gaussùvFiltrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicEdit.Image = ImageProcessing.GaussBlur(image);

        }
    }
}
