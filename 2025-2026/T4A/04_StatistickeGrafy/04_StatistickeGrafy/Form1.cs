namespace _04_StatistickeGrafy
{
    public partial class Form1 : Form
    {
        // datova struktura pro uchování datové sady
        private int[] data;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            // vytvoøení datové sady, se kterou budeme pracovat
            data = new int[18];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = r.Next(30, 101);
            }
            // vynucení pøekreslení panelu - voláme jeho událost Paint
            PanelGraph.Refresh();
        }
        // konstant
        const int POSUN_X = 20;

        // Pøi vykreslování je tøeba si dát pozor na pøereslování již nakresleného
        // aktuálnì se zobrazená èísla pøekreslují lomenou èarou
        // ideální by bylo vykreslit èísla až po vykreslení èáry
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            // ziskani informace o grafice panelu
            Graphics grf = e.Graphics;
            // | = alt + 124
            NakresliOsy(grf);
            if (data == null || data.Length == 0) {  
                // v pøípadì, že data neexistují nebo jsou malá informujem uživatele
                // oranžová barva => warning
                // èervená barva => error
                grf.DrawString($"Žádná data k zobrazení",
                    new Font("Arial", 15), Brushes.Orange,
                    new Point(50,20));
                return;
            }           

            // vlastni funkce pro vykreslení os grafu
            Point[] bodyGrafu = new Point[data.Length];
            int x = 50;

            for (int i = 0; i < bodyGrafu.Length; i++)
            {
                // data v poli násobíme pro umìlé naškálování, aby vypadala lépe
                // hodnotu rovnìž posouváme o 30px nahoru, bay odpovídala posunu na ose
                bodyGrafu[i] = new Point(x, PanelGraph.Height - data[i] * 2 - 30);
                // text vykreslujeme na pozice novì vzniklých bodù
                grf.DrawString($"{data[i]}",
                    new Font("Arial", 15), Brushes.Green,
                    new Point(bodyGrafu[i].X - 5, bodyGrafu[i].Y - 25));

                x += POSUN_X;
            }

            Pen grafovaCara = new Pen(Color.Blue, 2);
            // vakresleni lomene cary reprezentujici hodnoty
            grf.DrawLines(grafovaCara, bodyGrafu);

            //vykreslení bodù pro zvýraznìní hodnot v grafu
            foreach (Point p in bodyGrafu)
            {
                grf.FillEllipse(Brushes.Red, p.X - 5, p.Y - 5, 10, 10);
            }

        }

        private void NakresliOsy(Graphics grf)
        {
            // osa x
            grf.DrawLine(Pens.Black, new Point(30, 0),
                                    new Point(30, PanelGraph.Height));
            // osa y
            grf.DrawLine(Pens.Black, new Point(0, PanelGraph.Height - 30),
                        new Point(PanelGraph.Width, PanelGraph.Height - 30));
            // škála osy x
            for (int i = 30; i < PanelGraph.Width; i += POSUN_X)
            {
                grf.DrawLine(Pens.Black, new Point(i, PanelGraph.Height - 40),
                        new Point(i, PanelGraph.Height - 20));
            }
            // škála osy y
            for (int i = 30; i < PanelGraph.Height; i += POSUN_X)
            {
                grf.DrawLine(Pens.Black, new Point(20, PanelGraph.Height - i),
                                    new Point(40, PanelGraph.Height - i));
            }
        }
    }
}
