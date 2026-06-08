using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pocasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double t, v, s;
        List<double> listT = new List<double>();
        List<double> listV = new List<double>();
        List<double> listS = new List<double>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               string[] pole = File.ReadAllLines(openFileDialog.FileName);
                foreach (string p in pole) { 
                
                
                }
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    
                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        if (line == null) break;
                        if (line == "datum,teplota,vlhkost,srazky")
                            continue;
                        if (line == "")
                            continue;
                        //"02.03.2025,3.1,78,2.3"
                        string[] rozdelene = line.Split(",");
                        if(rozdelene.Length != 4)
                        {
                            listBox1.Items.Add("špatný poèet sloupcù");
                            continue;
                        }
                        //{"02.03.2025","3.1","78","2.3"}


                        string vysledekKontroly = Kontrola(rozdelene[1], rozdelene[2], rozdelene[3]);
                        if (vysledekKontroly != "")
                        {
                            listBox1.Items.Add(vysledekKontroly);
                        }
                        else
                        {
                            string vysledek = ZapracujVeliciny(t, v, s);
                           // MessageBox.Show(vysledek);
                            using (StreamWriter sw = new StreamWriter("export.txt"))
                            {
                                sw.WriteLine(vysledek);
                            }
                        }
                    }
                }
            }

        }

        private string ZapracujVeliciny(double t, double v, double s)
        {
            listT.Add(t);
            listV.Add(v);
            listS.Add(s);
            double max = listT.Max();
            double min = listT.Min();
            double prumernaVlhkost = listV.Average();
            int dest = 0;
            foreach (double x in listS)
            {
                if (x > 0) dest++;
            }
            string vystupu = "pøehled poèasí" + Environment.NewLine;

            vystupu += $"Maximální teplota {max}{Environment.NewLine}";
            vystupu += $"Minimilání teplota {min}{Environment.NewLine}";
            vystupu += $"Prùmìrná vlhkost {prumernaVlhkost}{Environment.NewLine}";
            vystupu += $"Poèet deštivých dnù {dest}";

            return vystupu;

        }

        private string Kontrola(string text1, string text2, string text3)
        {
            string kontrola = "";
            try
            {
                t = double.Parse(text1.Replace(".",","));
                double x;
                if(! double.TryParse(text1, out x))
                {
                    return "nepovedlo se";
                    
                }
                v = double.Parse(text2.Replace(".", ","));
                s = double.Parse(text3.Replace(".", ","));
                if (v < 0 || v > 100)
                {
                    return "Neplatný rozsah pro vlhkost";
                }
            }
            catch (Exception ex)
            {
                kontrola = ex.Message;
            }
            return kontrola;

        }
    }
}
