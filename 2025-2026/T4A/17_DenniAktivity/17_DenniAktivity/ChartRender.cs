using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_DenniAktivity
{
    static class ChartRender
    {
        public static void DrawChart(Graphics g, int width, int height, List<Activity> activities, int selectedActivityIndex = -1)
        {
            Rectangle rect = new Rectangle(40, 40, width - 60, height - 60);
            int angle = 0;
            g.FillEllipse(Brushes.Gray, rect);

            for (int i = 0; i < activities.Count; i++)
            {
                Activity activity = activities[i];
                SolidBrush brush = new SolidBrush(activity.Color);
                float sweep = ((float)activity.Time / 1440) * 360;

                Rectangle drawRect = rect;
                if (i == selectedActivityIndex)
                {
                    // Vysunutí výseče
                    double midAngle = (angle + sweep / 2) * Math.PI / 180;
                    int offset = 20; // vzdálenost vysunutí
                    int dx = (int)(Math.Cos(midAngle) * offset);
                    int dy = (int)(Math.Sin(midAngle) * offset);
                    drawRect = new Rectangle(rect.X + dx, rect.Y + dy, rect.Width, rect.Height);
                }

                g.FillPie(brush, drawRect, angle, sweep);
                angle += (int)sweep;
            }
        }


        internal static void DrawLegend(Graphics g, List<Activity> acitivities)
        {
            int baseY = 0;
            Font f = new Font("Arial", 16);
            foreach (Activity activity in acitivities)
            {
                Rectangle r = new Rectangle(0, baseY,20, 20);
                SolidBrush brush = new SolidBrush(activity.Color);
                g.FillRectangle(brush, r);
                g.DrawString(activity.Name, f, brush, 20, baseY);
                baseY += 20;
            }
        }
    }
}
