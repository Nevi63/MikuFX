using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikuFX
{
    class FiltroImagen
    {
        private Bitmap imagenOriginal;

        public FiltroImagen(Bitmap imagen)
        {
            imagenOriginal = new Bitmap(imagen);
        }

        public Bitmap AplicarFiltro(string filtro)
        {
            switch (filtro)
            {
                case "Inverso": return FiltroInverso();
                case "Brillo+": return AjustarBrillo(30);
                case "Brillo-": return AjustarBrillo(-30);
                case "Contraste+": return AjustarContraste(1.2);
                case "Contraste-": return AjustarContraste(0.8);
                case "Gaussiano": return FiltroGaussiano();
                case "Detección Bordes": return FiltroDeteccionBordes();
                case "Ojo de Pez": return FiltroOjoDePez();
                case "Color Shift": return FiltroColorShift();
                case "Posterización": return FiltroPosterizacion();
                case "Ruido": return FiltroRuido();
                case "Mosaico": return FiltroMosaico(30);
                default: return new Bitmap(imagenOriginal);
            }
        }
        private int Clamp(int valor, int min, int max)
        {
            return valor < min ? min : (valor > max ? max : valor);
        }

        public Bitmap FiltroInverso()
        {
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            return bmp;
        }

        public Bitmap AjustarBrillo(int cantidad)
        {
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    int r = Clamp(pixel.R + cantidad, 0, 255);
                    int g = Clamp(pixel.G + cantidad, 0, 255);
                    int b = Clamp(pixel.B + cantidad, 0, 255);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }

        public Bitmap AjustarContraste(double factor)
        {
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    int r = Clamp((int)((pixel.R - 128) * factor + 128), 0, 255);
                    int g = Clamp((int)((pixel.G - 128) * factor + 128), 0, 255);
                    int b = Clamp((int)((pixel.B - 128) * factor + 128), 0, 255);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }

        public Bitmap FiltroGaussiano()
        {
            int[,] kernel = {
        { 1,  4,  7,  4, 1 },
        { 4, 16, 26, 16, 4 },
        { 7, 26, 41, 26, 7 },
        { 4, 16, 26, 16, 4 },
        { 1,  4,  7,  4, 1 }
    };

            int kernelSum = kernel.Cast<int>().Sum();
            Bitmap resultado = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 2; x < imagenOriginal.Width - 2; x++)
            {
                for (int y = 2; y < imagenOriginal.Height - 2; y++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int i = -2; i <= 2; i++)
                    {
                        for (int j = -2; j <= 2; j++)
                        {
                            Color pixel = imagenOriginal.GetPixel(x + i, y + j);
                            int coef = kernel[i + 2, j + 2];

                            r += pixel.R * coef;
                            g += pixel.G * coef;
                            b += pixel.B * coef;
                        }
                    }

                    r = Clamp(r / kernelSum, 0, 255);
                    g = Clamp(g / kernelSum, 0, 255);
                    b = Clamp(b / kernelSum, 0, 255);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return resultado;
        }

        public Bitmap FiltroDeteccionBordes()
        {
            int[,] sobelX = {
        { -1,  0,  1 },
        { -2,  0,  2 },
        { -1,  0,  1 }
    };

            int[,] sobelY = {
        { -1, -2, -1 },
        {  0,  0,  0 },
        {  1,  2,  1 }
    };

            Bitmap resultado = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 1; x < imagenOriginal.Width - 1; x++)
            {
                for (int y = 1; y < imagenOriginal.Height - 1; y++)
                {
                    int gX = 0, gY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = imagenOriginal.GetPixel(x + i, y + j);
                            int intensidad = (pixel.R + pixel.G + pixel.B) / 3;

                            gX += intensidad * sobelX[i + 1, j + 1];
                            gY += intensidad * sobelY[i + 1, j + 1];
                        }
                    }

                    int magnitud = Clamp((int)Math.Sqrt(gX * gX + gY * gY), 0, 255);
                    resultado.SetPixel(x, y, Color.FromArgb(magnitud, magnitud, magnitud));
                }
            }

            return resultado;
        }


        public Bitmap FiltroColorShift()
        {
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(pixel.G, pixel.B, pixel.R));
                }
            }
            return bmp;
        }

        public Bitmap FiltroOjoDePez()
        {
            int ancho = imagenOriginal.Width;
            int alto = imagenOriginal.Height;
            Bitmap resultado = new Bitmap(ancho, alto);

            float radioMax = Math.Min(ancho, alto) / 2f;
            float centroX = ancho / 2f;
            float centroY = alto / 2f;

            for (int x = 0; x < ancho; x++)
            {
                for (int y = 0; y < alto; y++)
                {
                    float dx = x - centroX;
                    float dy = y - centroY;
                    float distancia = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (distancia < radioMax)
                    {
                        float factor = (float)Math.Pow(distancia / radioMax, 2);
                        int srcX = (int)(centroX + dx * factor);
                        int srcY = (int)(centroY + dy * factor);

                        if (srcX >= 0 && srcX < ancho && srcY >= 0 && srcY < alto)
                        {
                            resultado.SetPixel(x, y, imagenOriginal.GetPixel(srcX, srcY));
                        }
                    }
                    else
                    {
                        resultado.SetPixel(x, y, imagenOriginal.GetPixel(x, y));
                    }
                }
            }

            return resultado;
        }


        public Bitmap FiltroPosterizacion()
        {
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    int r = (pixel.R / 64) * 64;
                    int g = (pixel.G / 64) * 64;
                    int b = (pixel.B / 64) * 64;
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }

        public Bitmap FiltroRuido()
        {
            Random rand = new Random();
            Bitmap bmp = new Bitmap(imagenOriginal);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    int r = Clamp(pixel.R + rand.Next(-30, 30), 0, 255);
                    int g = Clamp(pixel.G + rand.Next(-30, 30), 0, 255);
                    int b = Clamp(pixel.B + rand.Next(-30, 30), 0, 255);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }

        public Bitmap FiltroMosaico(int tamanoBloque)
        {
            Bitmap bmp = new Bitmap(imagenOriginal);

            for (int x = 0; x < bmp.Width; x += tamanoBloque)
            {
                for (int y = 0; y < bmp.Height; y += tamanoBloque)
                {
                    // Calcular el color promedio del bloque
                    int r = 0, g = 0, b = 0;
                    int contador = 0;

                    // Recorrer el bloque de píxeles
                    for (int i = 0; i < tamanoBloque && x + i < bmp.Width; i++)
                    {
                        for (int j = 0; j < tamanoBloque && y + j < bmp.Height; j++)
                        {
                            Color pixel = bmp.GetPixel(x + i, y + j);
                            r += pixel.R;
                            g += pixel.G;
                            b += pixel.B;
                            contador++;
                        }
                    }

                    // Calcular el color promedio
                    r /= contador;
                    g /= contador;
                    b /= contador;

                    // Asignar el color promedio al bloque
                    for (int i = 0; i < tamanoBloque && x + i < bmp.Width; i++)
                    {
                        for (int j = 0; j < tamanoBloque && y + j < bmp.Height; j++)
                        {
                            bmp.SetPixel(x + i, y + j, Color.FromArgb(r, g, b));
                        }
                    }
                }
            }

            return bmp;
        }

    }
}
