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

namespace MikuFX
{
    public partial class MikuFX: Form
    {
        public MikuFX()
        {
            InitializeComponent();
            ConfigurarChart();
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
            guardarImagen.Click += (s, e) => MessageBox.Show("Función de guardar imagen aún no implementada.");

            ToolStripMenuItem aplicarFiltro = new ToolStripMenuItem("Aplicar Filtro");
            aplicarFiltro.Click += (s, e) => MessageBox.Show("Filtros aún no implementados.");

            ToolStripMenuItem borrarFiltro = new ToolStripMenuItem("Borrar Filtro");
            borrarFiltro.Click += (s, e) => MessageBox.Show("Filtros aún no implementados.");

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

            ToolStripMenuItem aplicarFiltroVideo = new ToolStripMenuItem("Aplicar Filtro en Vivo");
            aplicarFiltroVideo.Click += (s, e) => MessageBox.Show("Filtros en video aún no implementados.");

            menuOpciones.Items.Add(cargarVideo);
            menuOpciones.Items.Add(aplicarFiltroVideo);
        }

        private void CambiarMenuCamara()
        {
            menuOpciones.Items.Clear();

            ToolStripMenuItem activarCamara = new ToolStripMenuItem("Activar Cámara");
            activarCamara.Click += (s, e) => MessageBox.Show("Cámara aún no implementada.");


            menuOpciones.Items.Add(activarCamara);
        }

        private void ConfigurarChart()
        {
            chartHistograma.ChartAreas.Clear();
            chartHistograma.Series.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Intensidad de color (0-255)";
            chartArea.AxisY.Title = "Frecuencia de píxeles";
            chartHistograma.ChartAreas.Add(chartArea);

            // Crear series para R, G y B
            string[] colores = { "Rojo", "Verde", "Azul" };
            Color[] coloresRGB = { Color.Red, Color.Green, Color.Blue };

            for (int i = 0; i < colores.Length; i++)
            {
                Series serie = new Series(colores[i])
                {
                    ChartType = SeriesChartType.Column, // Barras verticales
                    Color = coloresRGB[i],
                    BorderWidth = 1
                };
                chartHistograma.Series.Add(serie);
            }
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

            // Limpiar datos anteriores
            foreach (var serie in chartHistograma.Series)
            {
                serie.Points.Clear();
            }

            // Agregar datos al Chart
            for (int i = 0; i < 256; i++)
            {
                chartHistograma.Series["Rojo"].Points.AddXY(i, histogramaR[i]);
                chartHistograma.Series["Verde"].Points.AddXY(i, histogramaG[i]);
                chartHistograma.Series["Azul"].Points.AddXY(i, histogramaB[i]);
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

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap imagen = new Bitmap(openFileDialog.FileName);
                pictureBoxImagen.Image = imagen;
                GenerarHistograma(imagen);
            }
        }

        private void btnCargarVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Videos|*.mp4;*.avi;*.mov" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Video cargado: " + openFileDialog.FileName);
                // Aquí más adelante agregaremos la funcionalidad para reproducir el video
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxColor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
