using System.Drawing;

namespace _12_Vanoce
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private List<Rectangle>[] snowflakes;

        public Form1()
        {
            InitializeComponent();
            snowflakes = new List<Rectangle>[this.Width];
            for (int i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new List<Rectangle>();
            }
        }

        private void PanelChristmas_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TimeSnow_Tick(object sender, EventArgs e)
        {
            AddSnowFlakes(1);
            Refresh();
            MoveSnowFlakes();

        }

        private void MoveSnowFlakes()
        {
            for (int x = 0; x < snowflakes.Length; x++)
            {
                for (int i = 0; i < snowflakes[x].Count; i++)
                {
                    Rectangle r = snowflakes[x][i];
                    r.Y += 8;
                    snowflakes[x][i] = r;
                }
                // odstranìní dopadlých vloèek
                for (int i = snowflakes[x].Count - 1; i >= 0; i--)
                {
                    if (snowflakes[x][i].Y > this.Height)
                    {
                        snowflakes[x].RemoveAt(i);
                    }
                }
            }

        }

        private void AddSnowFlakes(int number)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < number; i++)
            {
                int num = rnd.Next(0, Width);
                if (!indexes.Contains(num))
                {
                    rnd.Next(0, Width);
                    snowflakes[num].Add(new Rectangle(num, 0, 10, 10));
                }
            }
        }

        private void PanelChristmas_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int bottomSize = 150;
            int middleSize = 110;
            int headSize = 70;
            int handWidth = 70;
            int handHeight = 30;

            // X pozice — snìhulák bude uprostøed
            int centerX = Width / 2;

            // Y pozice spodní koule
            int bottomY = Height - bottomSize - 10;

            // Vypoèítání pozic jednotlivých koulí, rukou a èepice
            Rectangle bottom = new Rectangle(centerX - bottomSize / 2, bottomY, bottomSize, bottomSize);
            Rectangle middle = new Rectangle(centerX - middleSize / 2, bottomY - middleSize + 10, middleSize, middleSize);
            Rectangle head = new Rectangle(centerX - headSize / 2, bottomY - middleSize - headSize + 20, headSize, headSize);
            Rectangle leftHand = new Rectangle(centerX - middleSize , bottomY - middleSize / 2,handWidth,handHeight);
            Rectangle rightHand = new Rectangle(centerX + middleSize / 2 - 10 , bottomY - middleSize / 2,handWidth, handHeight);
            Rectangle pot = new Rectangle(centerX - headSize / 2+5, bottomY - middleSize - headSize * 2 + 30, headSize-10, headSize);

            // --- Tìlo snìhuláka ---
            g.FillEllipse(Brushes.White, bottom);
            g.FillEllipse(Brushes.White, middle);
            g.FillEllipse(Brushes.White, head);

            // --- Ruce snìhuláka ---
            g.FillEllipse(Brushes.White, rightHand);
            g.FillEllipse(Brushes.White, leftHand);

            // --- Hrnec na hlavì ---
            g.FillRectangle(Brushes.Black, pot);

            // --- Oèi ---
            int eyeSize = 6;
            int eyeY = head.Y + head.Height / 3;

            int leftEyeX = head.X + head.Width / 3;
            int rightEyeX = head.X + (int)(head.Width * 0.66);

            g.FillEllipse(Brushes.Black, leftEyeX, eyeY, eyeSize, eyeSize);
            g.FillEllipse(Brushes.Black, rightEyeX, eyeY, eyeSize, eyeSize);

            // --- Mrkvový nos ---
            Point noseStart = new Point(centerX, head.Y + head.Height / 2);
            Point noseEnd = new Point(centerX + 15, head.Y + head.Height / 2 + 2);

            g.DrawLine(new Pen(Color.Orange, 4), noseStart, noseEnd);
            g.FillRectangle(Brushes.White, 0,Height - 50,Width,20);

            foreach (List<Rectangle> line in snowflakes)
            {
                foreach (Rectangle r in line)
                {
                    g.FillEllipse(Brushes.White, r);
                }
            }
        }
    }
}
