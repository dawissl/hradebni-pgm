using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _10_GenerovaniMapy
{
    public partial class Form1 : Form
    {
        // Generátor náhodných hodnot.
        // Používá se při rozhodování o tom, jaký typ terénu se vygeneruje.
        private Random rnd = new Random();

        // Dvourozměrné pole reprezentující mapu.
        // [řádek, sloupec] – každá buňka obsahuje znak určující typ terénu (V, T, P).
        private char[,] map;

        public Form1()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------
        // TLAČÍTKO PRO GENEROVÁNÍ MAPY
        //---------------------------------------------------------------
        private void BtnGenerateMap_Click(object sender, EventArgs e)
        {
            // Ověření, že rozměry mapy jsou nenulové.
            if (NumHeight.Value == 0 || NumWidth.Value == 0)
            {
                MessageBox.Show("Jeden z rozměrů je nulový, nelze vytvořit mapu");
                return;
            }

            // Součet pravděpodobností vody a trávy nesmí překročit 100 %.
            // Jinak by se vytvořily intervaly, které nedávají logický smysl.
            if (NumGrass.Value + NumWater.Value > 100)
            {
                MessageBox.Show("Maximální součet pravděpodobností pro výskyt vody a trávy je 100%");
                return;
            }

            // Vygenerování nové mapy
            map = GenerateMap(
                (int)NumWidth.Value,
                (int)NumHeight.Value,
                (int)NumWater.Value,
                (int)NumGrass.Value
            );

            //---------------------------------------------------------------
            // TEXTOVÁ PODOBA MAPY + SČÍTÁNÍ TYPOLOGIE
            //---------------------------------------------------------------
            // Zde se pouze prochází celé 2D pole a podle znaků se sčítají typy.
            // Negenerujeme zde nic nového — jde o čisté vyhodnocení.
            int waterTiles = 0;
            int sandTiles = 0;
            int grassTiles = 0;
            string strMap = "";

            for (int i = 0; i < map.GetLength(0); i++)     // řádky
            {
                for (int j = 0; j < map.GetLength(1); j++) // sloupce
                {
                    // Počítání počtu jednotlivých typů terénu.
                    // Tyto hodnoty slouží pro statistiku a určení typu mapy.
                    if (map[i, j] == 'P') sandTiles++;
                    if (map[i, j] == 'V') waterTiles++;
                    if (map[i, j] == 'T') grassTiles++;

                    // Přidání znaku do textové verze mapy.
                    strMap += map[i, j] + " ";
                }
                strMap += Environment.NewLine;
            }

            // Výpis textové mapy do labelu.
            LblMap.Text = strMap;

            // Jednoduché rozhodnutí, zda je mapa spíše vodní, travní nebo písčitá
            string dominant = (waterTiles > grassTiles && waterTiles > sandTiles) ? "vodní" :
                                    (grassTiles > waterTiles && grassTiles > sandTiles) ? "travnatá" : "písčitá";
            LblMapType.Text = dominant;

            // Překreslení grafiky panelu.
            PanelMap.Refresh();
        }

        //---------------------------------------------------------------
        // GENEROVÁNÍ MAPY – HLAVNÍ ALGORITMUS
        //---------------------------------------------------------------
        private char[,] GenerateMap(int width, int height, int waterProbability, int grassProbability)
        {
            // Mapu ukládáme jako dvourozměrné pole:
            // map[y, x] — výška = počet řádků, šířka = počet sloupců
            char[,] map = new char[height, width];

            // Náhodné generování terénu pomocí "intervalové logiky".
            // Nepoužíváme samostatné podmínky typu:
            //   if (náhoda < něco) …
            //   if (náhoda < něco jiného) …
            // protože takový přístup by neodpovídal pravděpodobnostem.
            //
            // Místo toho používáme JEDNO náhodné číslo a porovnáváme ho s hranicemi intervalů.
            //
            // Příklad:
            // water = 30, grass = 20 → intervals:
            //  0–29 → voda
            //  30–49 → tráva
            //  50–100 → písek
            //
            // Tím je zaručeno, že mezi typy terénu nevznikají „díry“ ani překryvy.

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    // Náhodné číslo 0–100 určuje, do kterého intervalu buňka spadne.
                    int r = rnd.Next(0, 101);

                    if (r < waterProbability)
                    {
                        // Buňka spadá do intervalu vody.
                        map[h, w] = 'V';
                    }
                    else if (r < waterProbability + grassProbability)
                    {
                        // Buňka spadá do druhého intervalu – trávy.
                        map[h, w] = 'T';
                    }
                    else
                    {
                        // Zbytek automaticky padá do písku.
                        // Nemusíme provádět třetí podmínku, protože jde o zbytkový interval.
                        map[h, w] = 'P';
                    }
                }
            }

            return map;
        }

        //---------------------------------------------------------------
        // KRESLENÍ MAPY – GRAFICKÁ PODPORA
        //---------------------------------------------------------------
        private void PanelMap_Paint(object sender, PaintEventArgs e)
        {
            if (map == null) return;

            Graphics g = e.Graphics;

            // Velikost čtverečku v pixelech
            int TILE_SIZE = (int)NumTileSite.Value;

            // Procházíme mapu podle souřadnic X,Y.
            for (int x = 0; x < map.GetLength(1); x++)     // sloupce
            {
                for (int y = 0; y < map.GetLength(0); y++) // řádky
                {
                    // Vykreslení daného typu terénu.
                    // Nepoužíváme zde logiku — jen interpretaci hodnot z pole.
                    switch (map[y, x])
                    {
                        case 'V':
                            g.FillRectangle(Brushes.Aqua, TILE_SIZE * x, TILE_SIZE * y, TILE_SIZE, TILE_SIZE);
                            continue;

                        case 'P':
                            g.FillRectangle(Brushes.SandyBrown, TILE_SIZE * x, TILE_SIZE * y, TILE_SIZE, TILE_SIZE);
                            continue;

                        case 'T':
                            g.FillRectangle(Brushes.Green, TILE_SIZE * x, TILE_SIZE * y, TILE_SIZE, TILE_SIZE);
                            continue;

                        // Neznámá hodnota – čistě bezpečnostní fallback
                        default:
                            g.FillRectangle(Brushes.Black, TILE_SIZE * x, TILE_SIZE * y, TILE_SIZE, TILE_SIZE);
                            continue;
                    }
                }
            }
        }

        //---------------------------------------------------------------
        // ULOŽENÍ TEXTOVÉ MAPY DO SOUBORU
        //---------------------------------------------------------------
        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            // Jednoduchý zápis obsahující textovou podobu mapy.
            // Nepracujeme s typy terénů znovu, jen přebíráme vygenerovaný text.
            using (StreamWriter sw = new StreamWriter("mapa.txt"))
            {
                sw.Write(LblMap.Text);
                sw.Close();
            }
        }
    }
}