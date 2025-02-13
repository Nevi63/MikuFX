namespace MikuFX
{
    partial class MikuFX
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MikuFX));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnCamara = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelImagen = new System.Windows.Forms.Panel();
            this.chartHistograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.chartVideoHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.trackBarVideo = new System.Windows.Forms.TrackBar();
            this.panelReproductor = new System.Windows.Forms.Panel();
            this.panelCamara = new System.Windows.Forms.Panel();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.chartHistogramaCamara = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxCamara = new System.Windows.Forms.PictureBox();
            this.btnDetectar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
            this.panelVideo.SuspendLayout();
            this.panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVideoHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).BeginInit();
            this.panelCamara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogramaCamara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(122)))), ((int)(((byte)(127)))));
            this.flowLayoutPanel1.Controls.Add(this.btnImagen);
            this.flowLayoutPanel1.Controls.Add(this.btnVideo);
            this.flowLayoutPanel1.Controls.Add(this.btnCamara);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 584);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1536, 350);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.UseWaitCursor = true;
            // 
            // btnImagen
            // 
            this.btnImagen.BackgroundImage = global::MikuFX.Properties.Resources.ImagenLogo;
            this.btnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImagen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImagen.Location = new System.Drawing.Point(50, 50);
            this.btnImagen.Margin = new System.Windows.Forms.Padding(50);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(400, 250);
            this.btnImagen.TabIndex = 0;
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.UseWaitCursor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.BackgroundImage = global::MikuFX.Properties.Resources.VideoLogo;
            this.btnVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnVideo.Location = new System.Drawing.Point(550, 50);
            this.btnVideo.Margin = new System.Windows.Forms.Padding(50);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(400, 250);
            this.btnVideo.TabIndex = 1;
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.UseWaitCursor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnCamara
            // 
            this.btnCamara.BackgroundImage = global::MikuFX.Properties.Resources.CameraLogo;
            this.btnCamara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCamara.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCamara.Location = new System.Drawing.Point(1050, 50);
            this.btnCamara.Margin = new System.Windows.Forms.Padding(50);
            this.btnCamara.Name = "btnCamara";
            this.btnCamara.Size = new System.Drawing.Size(400, 250);
            this.btnCamara.TabIndex = 2;
            this.btnCamara.UseVisualStyleBackColor = true;
            this.btnCamara.UseWaitCursor = true;
            this.btnCamara.Click += new System.EventHandler(this.btnCamara_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // panelImagen
            // 
            this.panelImagen.AutoSize = true;
            this.panelImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(206)))), ((int)(((byte)(203)))));
            this.panelImagen.Controls.Add(this.chartHistograma);
            this.panelImagen.Controls.Add(this.pictureBoxImagen);
            this.panelImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImagen.Location = new System.Drawing.Point(0, 0);
            this.panelImagen.Name = "panelImagen";
            this.panelImagen.Size = new System.Drawing.Size(1536, 934);
            this.panelImagen.TabIndex = 2;
            // 
            // chartHistograma
            // 
            chartArea10.Name = "ChartArea1";
            this.chartHistograma.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartHistograma.Legends.Add(legend10);
            this.chartHistograma.Location = new System.Drawing.Point(1125, 79);
            this.chartHistograma.Name = "chartHistograma";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chartHistograma.Series.Add(series10);
            this.chartHistograma.Size = new System.Drawing.Size(358, 348);
            this.chartHistograma.TabIndex = 2;
            this.chartHistograma.Text = "chart1";
            // 
            // pictureBoxImagen
            // 
            this.pictureBoxImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.pictureBoxImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxImagen.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxImagen.ErrorImage")));
            this.pictureBoxImagen.Image = global::MikuFX.Properties.Resources.MikuError_sin_imagen;
            this.pictureBoxImagen.InitialImage = global::MikuFX.Properties.Resources.MikuError_sin_imagen;
            this.pictureBoxImagen.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImagen.Name = "pictureBoxImagen";
            this.pictureBoxImagen.Size = new System.Drawing.Size(1062, 541);
            this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagen.TabIndex = 1;
            this.pictureBoxImagen.TabStop = false;
            // 
            // menuOpciones
            // 
            this.menuOpciones.Location = new System.Drawing.Point(0, 0);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(1536, 24);
            this.menuOpciones.TabIndex = 3;
            this.menuOpciones.Text = "menuStrip1";
            // 
            // panelVideo
            // 
            this.panelVideo.AutoSize = true;
            this.panelVideo.Controls.Add(this.panelControles);
            this.panelVideo.Controls.Add(this.panelReproductor);
            this.panelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVideo.Location = new System.Drawing.Point(0, 0);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(1536, 934);
            this.panelVideo.TabIndex = 3;
            this.panelVideo.Visible = false;
            // 
            // panelControles
            // 
            this.panelControles.Controls.Add(this.chartVideoHistogram);
            this.panelControles.Controls.Add(this.btnStop);
            this.panelControles.Controls.Add(this.btnPause);
            this.panelControles.Controls.Add(this.btnPlay);
            this.panelControles.Controls.Add(this.trackBarVideo);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControles.Location = new System.Drawing.Point(1125, 0);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(411, 934);
            this.panelControles.TabIndex = 1;
            // 
            // chartVideoHistogram
            // 
            chartArea11.Name = "ChartArea1";
            this.chartVideoHistogram.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chartVideoHistogram.Legends.Add(legend11);
            this.chartVideoHistogram.Location = new System.Drawing.Point(79, 13);
            this.chartVideoHistogram.Name = "chartVideoHistogram";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chartVideoHistogram.Series.Add(series11);
            this.chartVideoHistogram.Size = new System.Drawing.Size(285, 205);
            this.chartVideoHistogram.TabIndex = 4;
            this.chartVideoHistogram.Text = "chart1";
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::MikuFX.Properties.Resources.StopLogo;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.Location = new System.Drawing.Point(141, 457);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(139, 90);
            this.btnStop.TabIndex = 3;
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::MikuFX.Properties.Resources.PauseLogo;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.Location = new System.Drawing.Point(141, 361);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(139, 90);
            this.btnPause.TabIndex = 2;
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::MikuFX.Properties.Resources.PlayLogo;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.Location = new System.Drawing.Point(141, 265);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(139, 90);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // trackBarVideo
            // 
            this.trackBarVideo.Location = new System.Drawing.Point(29, 228);
            this.trackBarVideo.Name = "trackBarVideo";
            this.trackBarVideo.Size = new System.Drawing.Size(376, 45);
            this.trackBarVideo.TabIndex = 0;
            // 
            // panelReproductor
            // 
            this.panelReproductor.BackColor = System.Drawing.Color.Black;
            this.panelReproductor.BackgroundImage = global::MikuFX.Properties.Resources.MikuError;
            this.panelReproductor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelReproductor.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelReproductor.Location = new System.Drawing.Point(0, 0);
            this.panelReproductor.Name = "panelReproductor";
            this.panelReproductor.Size = new System.Drawing.Size(1125, 934);
            this.panelReproductor.TabIndex = 0;
            // 
            // panelCamara
            // 
            this.panelCamara.AutoSize = true;
            this.panelCamara.Controls.Add(this.btnDetectar);
            this.panelCamara.Controls.Add(this.labelColor);
            this.panelCamara.Controls.Add(this.textBoxColor);
            this.panelCamara.Controls.Add(this.chartHistogramaCamara);
            this.panelCamara.Controls.Add(this.pictureBoxCamara);
            this.panelCamara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCamara.Location = new System.Drawing.Point(0, 0);
            this.panelCamara.Name = "panelCamara";
            this.panelCamara.Size = new System.Drawing.Size(1536, 934);
            this.panelCamara.TabIndex = 3;
            this.panelCamara.Visible = false;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Lucida Fax", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.Location = new System.Drawing.Point(1182, 347);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(253, 23);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "Ingrese RGB a detectar";
            this.labelColor.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(1150, 373);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(300, 20);
            this.textBoxColor.TabIndex = 2;
            this.textBoxColor.TextChanged += new System.EventHandler(this.textBoxColor_TextChanged);
            // 
            // chartHistogramaCamara
            // 
            chartArea12.Name = "ChartArea1";
            this.chartHistogramaCamara.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartHistogramaCamara.Legends.Add(legend12);
            this.chartHistogramaCamara.Location = new System.Drawing.Point(1150, 31);
            this.chartHistogramaCamara.Name = "chartHistogramaCamara";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartHistogramaCamara.Series.Add(series12);
            this.chartHistogramaCamara.Size = new System.Drawing.Size(300, 300);
            this.chartHistogramaCamara.TabIndex = 1;
            this.chartHistogramaCamara.Text = "chart1";
            // 
            // pictureBoxCamara
            // 
            this.pictureBoxCamara.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCamara.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCamara.Name = "pictureBoxCamara";
            this.pictureBoxCamara.Size = new System.Drawing.Size(1062, 554);
            this.pictureBoxCamara.TabIndex = 0;
            this.pictureBoxCamara.TabStop = false;
            // 
            // btnDetectar
            // 
            this.btnDetectar.Location = new System.Drawing.Point(1257, 399);
            this.btnDetectar.Name = "btnDetectar";
            this.btnDetectar.Size = new System.Drawing.Size(75, 23);
            this.btnDetectar.TabIndex = 4;
            this.btnDetectar.Text = "Detectar";
            this.btnDetectar.UseVisualStyleBackColor = true;
            // 
            // MikuFX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(206)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(1536, 934);
            this.Controls.Add(this.menuOpciones);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelImagen);
            this.Controls.Add(this.panelVideo);
            this.Controls.Add(this.panelCamara);
            this.Name = "MikuFX";
            this.Text = "MikuFX";
            this.Load += new System.EventHandler(this.MikuFX_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHistograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
            this.panelVideo.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVideoHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).EndInit();
            this.panelCamara.ResumeLayout(false);
            this.panelCamara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogramaCamara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnCamara;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxImagen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistograma;
        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Panel panelReproductor;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TrackBar trackBarVideo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVideoHistogram;
        private System.Windows.Forms.Panel panelCamara;
        private System.Windows.Forms.PictureBox pictureBoxCamara;
        private System.Windows.Forms.Panel panelImagen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogramaCamara;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button btnDetectar;
    }
}

