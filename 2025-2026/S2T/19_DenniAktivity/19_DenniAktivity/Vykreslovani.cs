using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _19_DenniAktivity
{
    internal static class Vykreslovani
    {
        public static void Kresli()
        {
            return;
        }

        internal static void VytvorGraf(Graphics g, int width, int height, List<Aktivita> aktivity)
        {
            Rectangle oblast = new Rectangle(40, 40, width - 60, height - 60);
            g.FillEllipse(Brushes.Gray, oblast);
            float pocatecniUhel = 0;
            for(int i = 0; i < aktivity.Count; i++)
            {
                Aktivita a = aktivity[i];
                SolidBrush stetec = new SolidBrush(a.Barva);
                float vysec = a.StravenyCas / 1440f * 360;
                g.FillPie(stetec,oblast, pocatecniUhel,vysec);
                pocatecniUhel += vysec;
            }
        }

        internal static void VytvorLegendu(Graphics g, List<Aktivita> aktivity)
        {
            int pocatecniY = 0;
            const int velikost = 20;
            Font f = new Font("Arial", 10);
            for (int i = 0; i < aktivity.Count; i++)
            {
                Aktivita a = aktivity[i];
                SolidBrush stetec = new SolidBrush(a.Barva);
                g.FillRectangle(stetec, 0, pocatecniY, velikost, velikost);
                g.DrawString(a.NazevAktivity, f, stetec, velikost + 5, pocatecniY + 2);
                pocatecniY += velikost;
            }
        }
    }
}
