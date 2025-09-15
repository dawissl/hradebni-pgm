

namespace _00_Boiler
{
    internal class Boiler
    {
        private int water;
        private int heat;
        private double temp;
        // doplnit atribut pro sepnutí ohřevu a vypouštění
        public int Water
        {
            // užití lambda funkcí
            get => water;
            // get { return water;}
            // set{water = Update(value);}
            //private double Upadte(double value){....}
            set
            {
                // lépší oddělit do samostatné funkce
                if (value < 0)
                {
                    water = 1;
                    MessageBox.Show("Minimální hodnota vody je 1l");
                }
                else if (value > 500)
                {
                    water = 500;
                    MessageBox.Show("Maximální hodnota vody je 500l");
                }
                else
                {
                    // tento poslední else vyvrací tvrzení, že minimální množství je 1l
                    // propadne sem hodnta 0
                    water = value;
                }
            }
        }
        public int Heat
        {
            get => heat;
            set
            {
                //DTTO
                if (value < 0)
                {
                    heat = 1;
                    MessageBox.Show("Minimální hodnota tepla je 1kW");
                }
                else if (value > 100)
                {
                    heat = 100;
                    MessageBox.Show("Maximální hodnota tepla je 100kW");
                }
                else
                {
                    heat = value;
                }
            }

        }

        public double Temp
        {
            get => temp;
        }

        public Boiler(int water, int h)
        {
            // možná pro lepší čitelnost ukládat hodnoty do atributů
           Water = water;
            Heat = h;
            temp = 20;
        }

        // není vždy třeba, aby byla nějaká hodnota vracena
        // chybí zde aktualizace teploty boileru uvnitř třídy
        public void HeatUp(int time, double current_temp)
        {
            
            temp = Math.Round(temp + (Heat * time) / (Water * 4.186 /* je třeba násobit 1000*/), 3);
            //return temp.ToString();
        }

        textbox.Text = $"{boiler.Temp}";

        //DTTO
        public string HeatOff(double current_temp)
        {
            if (temp > 20)
            {
                temp = Math.Round(current_temp - (current_temp - 20) * 0.02, 3);
            }
            else
            {
                temp = 20;
            }
            return temp.ToString();
        }


    }
}
