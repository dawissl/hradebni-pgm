using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_DenniAktivity
{
    static class ChartRender
    {
        public static void DrawChart(Graphics g, int width, int height, List<Activity> activities)
        {
            Rectangle rect = new Rectangle(40, 40, width - 60, height - 60);
            int angle = 0;
            g.FillEllipse(Brushes.Gray, rect);
            foreach (Activity activity in activities)
            {
                SolidBrush brush = new SolidBrush(activity.Color);

                g.FillPie(brush, rect, angle, ((float)activity.Time / 1440) * 360);
                angle += (int)(((float)activity.Time / 1440) * 360);
            }
        }

        internal static void DrawLegend(Graphics g, List<Activity> acitivities)
        {
            int baseY = 0;
            Font f = new Font("Arial", 16);
            foreach (Activity activity in acitivities)
            {
                Rectangle r = new Rectangle(0, baseY, 20, 20);
                SolidBrush brush = new SolidBrush(activity.Color);
                g.FillRectangle(brush, r);
                g.DrawString(activity.Name, f, brush, 20, baseY);
                baseY += 20;
            }
        }
    }
}