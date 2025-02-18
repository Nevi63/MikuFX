using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace MikuFX
{
    public partial class MikuFX: Form
    {
        private Bitmap imagenOriginal;
        private Bitmap imagenFiltrada;
        private FiltroImagen filtroImagen;
        private VideoCapture videoCapture;
        private Mat currentFrame;
        private Timer videoTimer;
        private bool isPlaying = false;
        private bool isSeeking = false;
        private string filtroSeleccionado = "Ninguno";
        public MikuFX()
        {
            InitializeComponent();
            SetupVideoPlayer();
        }

        private void MikuFX_Load(object sender, EventArgs e)
        {
            CambiarMenuImagen();
        }

        private void CambiarMenuImagen()
        {
            menuOpciones.Items.Clear();

            ToolStripMenuItem cargarImagen = new ToolStripMenuItem("Cargar Imagen");
            cargarImagen.Click += btnCargarImagen_Click;

            ToolStripMenuItem guardarImagen = new ToolStripMenuItem("Guardar Imagen");
            guardarImagen.Click += btnGuardarImagen_Click;

            ToolStripMenuItem aplicarFiltro = new ToolStripMenuItem("Aplicar Filtro");
            string[] filtros = { "Inverso", "Brillo+", "Brillo-", "Contraste+", "Contraste-", "Gaussiano", "Detección Bordes", "Ojo de Pez", "Color Shift", "Posterización", "Ruido", "Mosaico" };

            foreach (var filtro in filtros)
            {
                ToolStripMenuItem itemFiltro = new ToolStripMenuItem(filtro);
                itemFiltro.Click += (s, e) => AplicarFiltro(filtro);
                aplicarFiltro.DropDownItems.Add(itemFiltro);
            }

            ToolStripMenuItem borrarFiltro = new ToolStripMenuItem("Borrar Filtro");
            borrarFiltro.Click += btnBorrarFiltro_Click;

            menuOpciones.Items.Add(cargarImagen);
            menuOpciones.Items.Add(guardarImagen);
            menuOpciones.Items.Add(aplicarFiltro);
            menuOpciones.Items.Add(borrarFiltro);
        }

        private void CambiarMenuVideo()
        {
            menuOpciones.Items.Clear();

            ToolStripMenuItem cargarVideo = new ToolStripMenuItem("Cargar Video");
            cargarVideo.Click += btnCargarVideo_Click;

            ToolStripMenuItem aplicarFiltroVideo = new ToolStripMenuItem("Aplicar Filtro en Video");

            // Definir los filtros de video
            string[] filtrosVideo = { "Inverso", "Brillo+", "Brillo-", "Contraste+", "Contraste-", "Gaussiano", "Detección Bordes", "Ojo de Pez", "Color Shift", "Posterización", "Ruido", "Mosaico" };

            // Crear un submenú para los filtros
            ToolStripMenuItem filtrosSubMenu = new ToolStripMenuItem("Filtros");

            foreach (var filtro in filtrosVideo)
            {
                ToolStripMenuItem filtroItem = new ToolStripMenuItem(filtro);
                filtroItem.Click += (s, e) => SeleccionarFiltroVideo(filtro);  // Llamar a una función para aplicar el filtro
                filtrosSubMenu.DropDownItems.Add(filtroItem);
            }

            aplicarFiltroVideo.DropDownItems.Add(filtrosSubMenu);

            ToolStripMenuItem borrarFiltroVideo = new ToolStripMenuItem("Borrar Filtro en Video");
            borrarFiltroVideo.Click += btnBorrarFiltroVideo_Click;


            menuOpciones.Items.Add(cargarVideo);
            menuOpciones.Items.Add(aplicarFiltroVideo);
            menuOpciones.Items.Add(borrarFiltroVideo);
        }

        private void SeleccionarFiltroVideo(string filtro)
        {
            if (videoCapture.IsOpened && isPlaying)
            {
                switch (filtro)
                {
                    case "Inverso":
                        filtroSeleccionado = "Inverso";
                        break;
                    case "Brillo+":
                        filtroSeleccionado = "Brillo+";
                        break;
                    case "Brillo-":
                        filtroSeleccionado = "Brillo-";
                        break;
                    case "Contraste+":
                        filtroSeleccionado = "Contraste+";
                        break;
                    case "Contraste-":
                        filtroSeleccionado = "Contraste-";
                        break;
                    case "Gaussiano":
                        filtroSeleccionado = "Gaussiano";
                        break;
                    case "Detección Bordes":
                        filtroSeleccionado = "Detección Bordes";
                        break;
                    case "Ojo de Pez":
                        filtroSeleccionado = "Ojo de Pez";
                        break;
                    case "Color Shift":
                        filtroSeleccionado = "Color Shift";
                        break;
                    case "Posterización":
                        filtroSeleccionado = "Posterización";
                        break;
                    case "Ruido":
                        filtroSeleccionado = "Ruido";
                        break;
                    case "Mosaico":
                        filtroSeleccionado = "Mosaico";
                        break;
                    default:
                        filtroSeleccionado = "Ninguno";
                        break;
                }
            }
        }

        private void CambiarMenuCamara()
        {
            menuOpciones.Items.Clear();

            ToolStripMenuItem activarCamara = new ToolStripMenuItem("Activar Cámara");
            activarCamara.Click += (s, e) => MessageBox.Show("Cámara aún no implementada.");


            menuOpciones.Items.Add(activarCamara);
        }

        private void ConfigurarChart(Chart chart, string nombreSerie, Color color)
        {
            chart.ChartAreas.Clear();
            chart.Series.Clear();

            ChartArea chartArea = new ChartArea
            {
                AxisX = { Title = "Intensidad de color (0-255)" },
                AxisY = { Title = "Frecuencia de píxeles" }
            };

            chart.ChartAreas.Add(chartArea);

            Series serie = new Series(nombreSerie)
            {
                ChartType = SeriesChartType.Column, // Barras verticales
                Color = color,
                BorderWidth = 1
            };

            chart.Series.Add(serie);
        }
        private void ConfigurarHistogramas()
        {
            // Configurar el histograma general con R, G y B
            chartHistograma.ChartAreas.Clear();
            chartHistograma.Series.Clear();

            ChartArea chartArea = new ChartArea
            {
                AxisX = { Title = "Intensidad de color (0-255)" },
                AxisY = { Title = "Frecuencia de píxeles" }
            };
            chartHistograma.ChartAreas.Add(chartArea);

            string[] colores = { "Rojo", "Verde", "Azul" };
            Color[] coloresRGB = { Color.Red, Color.Green, Color.Blue };

            for (int i = 0; i < colores.Length; i++)
            {
                Series serie = new Series(colores[i])
                {
                    ChartType = SeriesChartType.Column,
                    Color = coloresRGB[i],
                    BorderWidth = 1
                };
                chartHistograma.Series.Add(serie);
            }

            // Configurar los histogramas individuales
            ConfigurarChart(chartImgRed, "Rojo", Color.Red);
            ConfigurarChart(chartImgGreen, "Verde", Color.Green);
            ConfigurarChart(chartImgBlue, "Azul", Color.Blue);
        }

        private void ConfigurarHistogramasVideo()
        {
            // Configurar el histograma general con R, G y B
            chartVideoHistogram.ChartAreas.Clear();
            chartVideoHistogram.Series.Clear();

            ChartArea chartArea = new ChartArea
            {
                AxisX = { Title = "Intensidad de color (0-255)" },
                AxisY = { Title = "Frecuencia de píxeles" }
            };
            chartVideoHistogram.ChartAreas.Add(chartArea);

            string[] colores = { "Rojo", "Verde", "Azul" };
            Color[] coloresRGB = { Color.Red, Color.Green, Color.Blue };

            for (int i = 0; i < colores.Length; i++)
            {
                Series serie = new Series(colores[i])
                {
                    ChartType = SeriesChartType.Column,
                    Color = coloresRGB[i],
                    BorderWidth = 1
                };
                chartVideoHistogram.Series.Add(serie);
            }

            // Configurar los histogramas individuales
            ConfigurarChart(chartVideoRed, "Rojo", Color.Red);
            ConfigurarChart(chartVideoGreen, "Verde", Color.Green);
            ConfigurarChart(chartVideoBlue, "Azul", Color.Blue);
        }

        private void GenerarHistograma(Bitmap imagen)
        {
            int[] histogramaR = new int[256];
            int[] histogramaG = new int[256];
            int[] histogramaB = new int[256];

            // Recorrer cada píxel y contar los colores
            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    Color pixel = imagen.GetPixel(x, y);
                    histogramaR[pixel.R]++;
                    histogramaG[pixel.G]++;
                    histogramaB[pixel.B]++;
                }
            }

            // Configurar los gráficos antes de llenarlos
            ConfigurarHistogramas();

            // Función para actualizar un chart específico
            void ActualizarChart(Chart chart, string serieNombre, int[] datos)
            {
                if (chart.Series.FindByName(serieNombre) != null)
                {
                    chart.Series[serieNombre].Points.Clear();
                    for (int i = 0; i < 256; i++)
                    {
                        chart.Series[serieNombre].Points.AddXY(i, datos[i]);
                    }
                }
            }

            // Llenar los datos en cada gráfico
            ActualizarChart(chartHistograma, "Rojo", histogramaR);
            ActualizarChart(chartHistograma, "Verde", histogramaG);
            ActualizarChart(chartHistograma, "Azul", histogramaB);

            ActualizarChart(chartImgRed, "Rojo", histogramaR);
            ActualizarChart(chartImgGreen, "Verde", histogramaG);
            ActualizarChart(chartImgBlue, "Azul", histogramaB);
        }

        private void GenerarHistogramaVideo(Mat frame)
        {
            int[] histogramaR = new int[256];
            int[] histogramaG = new int[256];
            int[] histogramaB = new int[256];

            // Convertir el frame a Image<Bgr, byte> para facilitar el acceso a los píxeles
            Image<Bgr, byte> imgBgr = frame.ToImage<Bgr, byte>();

            // Recorrer cada píxel y contar los colores de cada canal
            for (int y = 0; y < imgBgr.Height; y++)
            {
                for (int x = 0; x < imgBgr.Width; x++)
                {
                    // Obtener el valor de cada canal (B, G, R)
                    Bgr pixel = imgBgr[y, x];

                    // Asegurarnos de que los valores de los canales sean enteros
                    histogramaB[(int)pixel.Blue]++;
                    histogramaG[(int)pixel.Green]++;
                    histogramaR[(int)pixel.Red]++;
                }
            }

            // Configurar los gráficos antes de llenarlos
            ConfigurarHistogramasVideo();

            // Función para actualizar un chart específico
            void ActualizarChart(Chart chart, string serieNombre, int[] datos)
            {
                if (chart.Series.FindByName(serieNombre) != null)
                {
                    chart.Series[serieNombre].Points.Clear();
                    for (int i = 0; i < 256; i++)
                    {
                        chart.Series[serieNombre].Points.AddXY(i, datos[i]);
                    }
                }
            }

            // Llenar los datos en cada gráfico
            ActualizarChart(chartVideoHistogram, "Rojo", histogramaR);
            ActualizarChart(chartVideoHistogram, "Verde", histogramaG);
            ActualizarChart(chartVideoHistogram, "Azul", histogramaB);

            ActualizarChart(chartVideoRed, "Rojo", histogramaR);
            ActualizarChart(chartVideoGreen, "Verde", histogramaG);
            ActualizarChart(chartVideoBlue, "Azul", histogramaB);
        }


        private void SetupVideoPlayer()
        {
            // Crea una nueva instancia de VideoCapture
            videoCapture = new VideoCapture();

            // Inicializa el temporizador que actualizará el video cada 33ms (aproximadamente 30 FPS)
            videoTimer = new Timer();
            videoTimer.Interval = 33; // Aproximadamente 30 FPS
            videoTimer.Tick += VideoTimer_Tick;

            // Configurar TrackBar
            trackBarVideo.Minimum = 0;
            trackBarVideo.TickFrequency = 10;
            trackBarVideo.Scroll += TrackBarVideo_Scroll;
        }

        // Método para cargar y reproducir el video
        private void CargarVideo(string path)
        {
            DetenerVideo(); // Detener cualquier video previo
            videoCapture = new VideoCapture(path);

            // Configurar TrackBar según la duración del video
            trackBarVideo.Maximum = (int)videoCapture.Get(CapProp.FrameCount);
            trackBarVideo.Value = 0;

            isPlaying = true;
            videoTimer.Start();
        }

        // Evento que se ejecuta en cada tick del temporizador
        private void VideoTimer_Tick(object sender, EventArgs e)
        {
            if (videoCapture.IsOpened && isPlaying)
            {
                currentFrame = videoCapture.QueryFrame();

                if (currentFrame != null)
                {
                    // Aplicar el filtro al frame
                    Mat frameProcesado = AplicarFiltroVideo(currentFrame, filtroSeleccionado);

                    panelReproductor.BackgroundImage = frameProcesado.ToBitmap();
                    GenerarHistogramaVideo(frameProcesado);

                    // Actualizar TrackBar si no está siendo arrastrado
                    if (!isSeeking)
                    {
                        trackBarVideo.Value = (int)videoCapture.Get(CapProp.PosFrames);
                    }
                }
                else
                {
                    // Fin del video, detener
                    DetenerVideo();
                }
            }
        }

        private Mat AplicarFiltroVideo(Mat frame, string filtro)
        {
            if (frame == null)
            {
                MessageBox.Show("Carga un video antes de aplicar un filtro.");
                return frame;
            }
            else
            {
                FiltroVideo filtroVideo = new FiltroVideo(); // Crear una instancia
                return filtroVideo.AplicarFiltro(frame, filtro); // Llamar al método de instancia
            }

        }


        // Llamado cuando el usuario selecciona cargar video
        private void btnCargarVideo_Click(object sender, EventArgs e)
        {
            // Abrir el cuadro de diálogo para seleccionar el archivo de video
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.avi;*.mp4;*.mkv;*.mov;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar el video seleccionado
                CargarVideo(openFileDialog.FileName);
            }
        }


        private void btnImagen_Click(object sender, EventArgs e)
        {
            panelImagen.Visible = true;
            panelVideo.Visible = false;
            panelCamara.Visible = false;
            panelImagen.BringToFront();
            CambiarMenuImagen();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            panelImagen.Visible = false;
            panelVideo.Visible = true; // Asegurar que realmente se active
            panelCamara.Visible = false;
            panelVideo.BringToFront();
            CambiarMenuVideo();
        }

        private void btnCamara_Click(object sender, EventArgs e)
        {
            panelImagen.Visible = false;
            panelVideo.Visible = false;
            panelCamara.Visible = true;
            panelCamara.BringToFront();
            CambiarMenuCamara();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void AplicarFiltro(string filtroNombre)
        {
            if (imagenOriginal == null)
            {
                MessageBox.Show("Carga una imagen antes de aplicar un filtro.");
                return;
            }

            filtroImagen = new FiltroImagen(imagenOriginal);
            imagenFiltrada = filtroImagen.AplicarFiltro(filtroNombre);
            pictureBoxImagen.Image = imagenFiltrada;
            GenerarHistograma(imagenFiltrada);
        }

        private void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            if (imagenOriginal != null)
            {
                pictureBoxImagen.Image = imagenOriginal;
                GenerarHistograma(imagenOriginal);
            }
        }

        private void btnBorrarFiltroVideo_Click(object sender, EventArgs e)
        {
            filtroSeleccionado = "Ninguno";
        }

        private void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            if (imagenFiltrada == null)
            {
                MessageBox.Show("No hay imagen filtrada para guardar.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.png;*.bmp"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagenFiltrada.Save(saveFileDialog.FileName);
                MessageBox.Show("Imagen guardada exitosamente.");
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagenOriginal = new Bitmap(openFileDialog.FileName);
                pictureBoxImagen.Image = imagenOriginal;
                GenerarHistograma(imagenOriginal);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxColor_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                isPlaying = true;
                videoTimer.Start();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPlaying = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DetenerVideo();
        }

        // Método para detener el video
        private void DetenerVideo()
        {
            isPlaying = false;
            videoTimer.Stop();
            videoCapture.Set(CapProp.PosFrames, 0); // Reiniciar al inicio
            trackBarVideo.Value = 0;
        }

        // Evento cuando el usuario mueve la barra
        private void TrackBarVideo_Scroll(object sender, EventArgs e)
        {
            isSeeking = true; // Evita que el Timer actualice la barra mientras el usuario la mueve
            videoCapture.Set(CapProp.PosFrames, trackBarVideo.Value);
            isSeeking = false;
        }
    }
}
