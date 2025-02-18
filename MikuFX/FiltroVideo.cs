using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace MikuFX
{
    class FiltroVideo
    {
        // Método que aplica el filtro correspondiente al frame de video
        public Mat AplicarFiltro(Mat frame, string filtro)
        {
            switch (filtro)
            {
                case "Inverso": return FiltroInverso(frame);
                case "Brillo+": return AjustarBrillo(frame, 30);
                case "Brillo-": return AjustarBrillo(frame, -30);
                case "Contraste+": return AjustarContraste(frame, 1.2);
                case "Contraste-": return AjustarContraste(frame, 0.8);
                case "Gaussiano": return FiltroGaussiano(frame);
                case "Detección Bordes": return FiltroDeteccionBordes(frame);
                case "Ojo de Pez": return FiltroOjoDePez(frame);
                case "Color Shift": return FiltroColorShift(frame);
                case "Posterización": return FiltroPosterizacion(frame);
                case "Ruido": return FiltroRuido(frame);
                case "Mosaico": return FiltroMosaico(frame, 30);
                default: return frame;
            }
        }

        // Filtro inverso para video
        private Mat FiltroInverso(Mat frame)
        {
            Mat resultado = new Mat();
            CvInvoke.BitwiseNot(frame, resultado);
            return resultado;
        }

        // Filtro de brillo para video
        private Mat AjustarBrillo(Mat frame, int cantidad)
        {
            Mat resultado = new Mat();
            frame.ConvertTo(resultado, DepthType.Cv8U, 1, cantidad); // Ajuste de brillo
            return resultado;
        }

        // Filtro de contraste para video
        private Mat AjustarContraste(Mat frame, double factor)
        {
            Mat resultado = new Mat();
            frame.ConvertTo(resultado, DepthType.Cv8U, factor, 0); // Ajuste de contraste
            return resultado;
        }

        // Filtro Gaussiano para video
        private Mat FiltroGaussiano(Mat frame)
        {
            Mat resultado = new Mat();
            CvInvoke.GaussianBlur(frame, resultado, new System.Drawing.Size(15, 15), 2.0);
            return resultado;
        }

        // Filtro detección de bordes (Sobel) para video
        private Mat FiltroDeteccionBordes(Mat frame)
        {
            Mat resultado = new Mat();
            CvInvoke.Canny(frame, resultado, 100, 200);
            return resultado;
        }

        // Filtro Ojo de Pez para video
        private Mat FiltroOjoDePez(Mat frame)
        {
            Mat resultado = frame.Clone();
            Image<Bgr, byte> imgFrame = frame.ToImage<Bgr, byte>();
            Image<Bgr, byte> imgResultado = resultado.ToImage<Bgr, byte>();

            int centerX = frame.Width / 2;
            int centerY = frame.Height / 2;
            double radius = Math.Min(centerX, centerY);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    // Calcular la distancia desde el centro
                    double dx = x - centerX;
                    double dy = y - centerY;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    // Calcular el ángulo
                    double angle = Math.Atan2(dy, dx);

                    // Aplicar la distorsión
                    double newDistance = distance * (1 - distance / (2 * radius));

                    // Calcular nuevas coordenadas
                    int sourceX = (int)(centerX + newDistance * Math.Cos(angle));
                    int sourceY = (int)(centerY + newDistance * Math.Sin(angle));

                    // Asegurarse de que las coordenadas estén dentro de los límites
                    if (sourceX >= 0 && sourceX < frame.Width && sourceY >= 0 && sourceY < frame.Height)
                    {
                        imgResultado[y, x] = imgFrame[sourceY, sourceX];
                    }
                }
            }

            return imgResultado.Mat;
        }

        // Filtro de desplazamiento de color (shift) para video
        private Mat FiltroColorShift(Mat frame)
        {
            Mat resultado = new Mat();
            // Crear un arreglo de Mat para los canales
            VectorOfMat canales = new VectorOfMat();
            // Dividir los canales de la imagen
            CvInvoke.Split(frame, canales);

            // Crear un vector temporal para reorganizar los canales (BGR -> GBR)
            VectorOfMat canalesReorganizados = new VectorOfMat();
            canalesReorganizados.Push(canales[1]); // G
            canalesReorganizados.Push(canales[2]); // B
            canalesReorganizados.Push(canales[0]); // R

            // Merge con los tipos correctos
            CvInvoke.Merge(canalesReorganizados, resultado);

            return resultado;
        }




        // Filtro de posterización para video
        private Mat FiltroPosterizacion(Mat frame, int niveles = 4)
        {
            Mat resultado = frame.Clone();
            Image<Bgr, byte> imgFrame = resultado.ToImage<Bgr, byte>();

            // Factor de división para crear los niveles
            int factor = 256 / niveles;

            for (int x = 0; x < frame.Width; x++)
            {
                for (int y = 0; y < frame.Height; y++)
                {
                    Bgr pixel = imgFrame[y, x];

                    // Reducir los niveles de cada canal de color
                    pixel.Blue = (byte)(Math.Floor(pixel.Blue / factor) * factor);
                    pixel.Green = (byte)(Math.Floor(pixel.Green / factor) * factor);
                    pixel.Red = (byte)(Math.Floor(pixel.Red / factor) * factor);

                    imgFrame[y, x] = pixel;
                }
            }

            return imgFrame.Mat;
        }

        // Filtro de ruido para video
        private Mat FiltroRuido(Mat frame)
        {
            Random rand = new Random();
            Mat resultado = frame.Clone();

            // Convertimos la imagen a un formato que podamos manipular más fácilmente
            Image<Bgr, byte> imgFrame = resultado.ToImage<Bgr, byte>();

            for (int x = 0; x < frame.Width; x++)
            {
                for (int y = 0; y < frame.Height; y++)
                {
                    Bgr pixel = imgFrame[y, x];

                    // Aplicamos el ruido a cada canal
                    pixel.Blue = (byte)Clamp(pixel.Blue + rand.Next(-30, 30), 0, 255);
                    pixel.Green = (byte)Clamp(pixel.Green + rand.Next(-30, 30), 0, 255);
                    pixel.Red = (byte)Clamp(pixel.Red + rand.Next(-30, 30), 0, 255);

                    imgFrame[y, x] = pixel;
                }
            }

            // Convertimos de vuelta a Mat
            return imgFrame.Mat;
        }

        // Función auxiliar para mantener los valores en el rango correcto
        private int Clamp(double value, int min, int max)
        {
            return (int)Math.Max(min, Math.Min(max, value));
        }

        private Mat FiltroMosaico(Mat frame, int tamanoBloque)
        {
            Mat resultado = frame.Clone();
            Image<Bgr, byte> imgFrame = resultado.ToImage<Bgr, byte>();

            for (int x = 0; x < frame.Width; x += tamanoBloque)
            {
                for (int y = 0; y < frame.Height; y += tamanoBloque)
                {
                    Bgr colorPromedio = CalcularColorPromedio(imgFrame, x, y, tamanoBloque);

                    // Aplicar el color promedio a todo el bloque
                    for (int i = 0; i < tamanoBloque && x + i < frame.Width; i++)
                    {
                        for (int j = 0; j < tamanoBloque && y + j < frame.Height; j++)
                        {
                            imgFrame[y + j, x + i] = colorPromedio;
                        }
                    }
                }
            }

            return imgFrame.Mat;
        }

        private Bgr CalcularColorPromedio(Image<Bgr, byte> imagen, int startX, int startY, int tamanoBloque)
        {
            double sumB = 0, sumG = 0, sumR = 0;
            int count = 0;

            for (int i = 0; i < tamanoBloque && startX + i < imagen.Width; i++)
            {
                for (int j = 0; j < tamanoBloque && startY + j < imagen.Height; j++)
                {
                    Bgr pixel = imagen[startY + j, startX + i];
                    sumB += pixel.Blue;
                    sumG += pixel.Green;
                    sumR += pixel.Red;
                    count++;
                }
            }

            // Calcular el promedio de cada canal
            return new Bgr(
                sumB / count,
                sumG / count,
                sumR / count
            );
        }

    }
}
