using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;          // nutné pro práci s Bitmap a Color
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;    // kvůli MessageBox

namespace _06_ObrazoveUpravy
{
    /// <summary>
    /// Statická třída obsahující základní metody pro úpravu rastrových obrázků.
    /// Umožňuje přidání šumu, filtraci a prahování obrazu.
    /// Statická třída umožňuje volat metody třídy bez potřeby instance třídy
    /// </summary>
    static class ImageProcessing
    {
        // Společný generátor náhodných čísel, aby se při každém volání nemusel vytvářet nový
        private static Random rnd = new Random();

        /// <summary>
        /// Testovací metoda pro ověření funkčnosti třídy.
        /// </summary>
        public static void Hi()
        {
            MessageBox.Show("Hi!");
        }

        /// <summary>
        /// Přidá do obrazu tzv. sůl a pepř (náhodně rozložený bílý a černý šum).
        /// </summary>
        /// <param name="img">Zdrojový obrázek typu Bitmap</param>
        /// <param name="salt">Pravděpodobnost (0–1), že pixel bude nahrazen bílou barvou</param>
        /// <param name="pepper">Pravděpodobnost (0–1), že pixel bude nahrazen černou barvou</param>
        /// <returns>Nový obrázek s přidaným šumem</returns>
        public static Bitmap SaltAndPeper(Bitmap img, double salt, double pepper)
        {
            Bitmap newImage = new Bitmap(img.Width, img.Height);

            // Vnější cyklus přes šířku, vnitřní přes výšku
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    // Vygeneruje náhodné číslo v intervalu <0,1)
                    double noise = rnd.NextDouble();

                    // Pokud je hodnota menší než parametr "salt", pixel se stane bílým
                    if (noise < salt)
                    {
                        newImage.SetPixel(x, y, Color.White);
                    }
                    // Pokud spadá do intervalu mezi "salt" a "salt + pepper", pixel se stane černým
                    else if (noise < salt + pepper)
                    {
                        newImage.SetPixel(x, y, Color.Black);
                    }
                    // Jinak se ponechá původní barva pixelu
                    else
                    {
                        newImage.SetPixel(x, y, img.GetPixel(x, y));
                    }
                }
            }

            return newImage;
        }

        /// <summary>
        /// Provádí mediánovou filtraci obrazu – slouží k redukci šumu (např. soli a pepře).
        /// Mediánový filtr nahrazuje každý pixel mediánem hodnot v okolí definovaném maskou.
        /// </summary>
        /// <param name="img">Zdrojový obrázek</param>
        /// <param name="maskSize">Rozměr čtvercové masky (typicky 3, 5, 7 ...)</param>
        /// <returns>Nový, vyhlazený obrázek</returns>
        public static Bitmap MedianFilter(Bitmap img, int maskSize)
        {
            Bitmap newImage = new Bitmap(img.Width, img.Height);

            int offset = maskSize / 2; // Poloměr masky (např. pro 3×3 je offset = 1)

            // Vnější cyklus přes šířku, vnitřní přes výšku
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    // Do pole mask uložíme jasové hodnoty okolních pixelů (zde pouze kanál R)
                    int[] mask = new int[maskSize * maskSize];
                    int index = 0;

                    // Procházíme okolí pixelu
                    for (int px = -offset; px <= offset; px++)
                    {
                        for (int py = -offset; py <= offset; py++)
                        {
                            int mx = x + px;
                            int my = y + py;

                            // Kontrola, zda sousední pixel leží uvnitř obrázku
                            if (mx < 0 || mx > img.Width - 1 || my < 0 || my > img.Height - 1)
                            {
                                // Pokud ne, použijeme hodnotu 0 (černá)
                                mask[index] = 0;
                            }
                            else
                            {
                                // Uložíme hodnotu červeného kanálu – předpokládáme černobílý obraz
                                mask[index] = img.GetPixel(mx, my).R;
                            }
                            index++;
                        }
                    }

                    // Seřadíme hodnoty a vybereme medián (střední hodnotu)
                    Array.Sort(mask);
                    int median = mask[mask.Length / 2];

                    // Nastavíme nový pixel – stejná hodnota pro R, G i B (odstíny šedi)
                    newImage.SetPixel(x, y, Color.FromArgb(median, median, median));
                }
            }

            return newImage;
        }

        /// <summary>
        /// Aplikuje prahování (binarizaci) obrazu – převádí šedotónový obrázek na černobílý podle prahu.
        /// </summary>
        /// <param name="img">Zdrojový obrázek</param>
        /// <param name="threshold">Hodnota prahu 0–255; pixely s vyšším jasem než threshold budou černé</param>
        /// <returns>Prahovaný (bílý/černý) obrázek</returns>
        public static Bitmap Thresholding(Bitmap img, int threshold)
        {
            Bitmap newImage = new Bitmap(img.Width, img.Height);

            // Vnější cyklus přes šířku, vnitřní přes výšku
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    // Pokud je jas (R kanál) větší nebo roven prahu, pixel je černý
                    if (img.GetPixel(x, y).R >= threshold)
                        newImage.SetPixel(x, y, Color.Black);
                    else
                        newImage.SetPixel(x, y, Color.White);
                }
            }

            return newImage;
        }

        public static Bitmap Brightness(Bitmap img, int brightness)
        {
            Bitmap newImage = new Bitmap(img.Width, img.Height);

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    int newColorValue = (int)Math.Max(0, img.GetPixel(x, y).R
                                                        - img.GetPixel(x, y).R * (brightness / 100.0));
                    Color newColor = Color.FromArgb(newColorValue, newColorValue, newColorValue);
                    newImage.SetPixel(x, y, newColor);
                }
            }
            return newImage;

        }

        public static Bitmap Greyscale(Bitmap img)
        {

            Bitmap newImage = new Bitmap(img.Width, img.Height);
            const double RED = 0.299;
            const double GREEN = 0.587;
            const double BLUE = 0.114;

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color c = img.GetPixel(x, y);
                    int grey = (int)(c.R * RED + c.G * GREEN + c.B * BLUE);
                    newImage.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            return newImage;

        }

        public static Bitmap Rotate(Bitmap img)
        {
            Bitmap newImage = new Bitmap(img.Height, img.Width);
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color px = img.GetPixel(x, y);

                    int newX = img.Height - 1 - y;
                    int newY = x;

                    newImage.SetPixel(newX, newY, px);
                }
            }

            return newImage;

        }

        public static Bitmap GaussBlur(Bitmap img)
        {

            Bitmap newImage = new Bitmap(img.Width, img.Height);
            int[,] kernel = {
                        { 1, 2, 1 },
                        { 2, 4, 2 },
                        { 1, 2, 1 }
                          };
            int kernelCoefficenet = 16;
            for (int x = 1; x < img.Width - 1; x++)
            {
                for (int y = 1; y < img.Height - 1; y++)
                {
                    int sum = 0;
                    for (int px = -1; px <= 1; px++)
                    {
                        for (int py = -1; py <= 1; py++)
                        {
                            int color = img.GetPixel(x + px, y + py).R;
                            sum += color * kernel[py + 1, px + 1];
                        }
                    }
                    int newValue = sum / kernelCoefficenet;
                    if(newValue < 0) newValue = 0;
                    if( newValue > 255) newValue = 255;
                    newImage.SetPixel(x,y,Color.FromArgb(newValue,newValue,newValue));
     
                }
            }
            return newImage;

        }
    }
}
