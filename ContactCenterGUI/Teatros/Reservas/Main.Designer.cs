namespace ContactCenterGUI.Teatros.Reservas
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNuevoRegistro = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCargaMasiva = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnGenerarFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGenerarReporte = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBandejaSalida = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(47, 168);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(244, 45);
            this.materialRaisedButton1.TabIndex = 9;
            this.materialRaisedButton1.Text = "Buscar Reservas";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // btnNuevoRegistro
            // 
            this.btnNuevoRegistro.Depth = 0;
            this.btnNuevoRegistro.Location = new System.Drawing.Point(47, 103);
            this.btnNuevoRegistro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNuevoRegistro.Name = "btnNuevoRegistro";
            this.btnNuevoRegistro.Primary = true;
            this.btnNuevoRegistro.Size = new System.Drawing.Size(244, 45);
            this.btnNuevoRegistro.TabIndex = 5;
            this.btnNuevoRegistro.Text = "Nueva Reserva";
            this.btnNuevoRegistro.UseVisualStyleBackColor = true;
            this.btnNuevoRegistro.Click += new System.EventHandler(this.btnNuevoRegistro_Click);
            // 
            // btnCargaMasiva
            // 
            this.btnCargaMasiva.Depth = 0;
            this.btnCargaMasiva.Location = new System.Drawing.Point(47, 293);
            this.btnCargaMasiva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCargaMasiva.Name = "btnCargaMasiva";
            this.btnCargaMasiva.Primary = true;
            this.btnCargaMasiva.Size = new System.Drawing.Size(244, 45);
            this.btnCargaMasiva.TabIndex = 17;
            this.btnCargaMasiva.Text = "CARGA MASIVA";
            this.btnCargaMasiva.UseVisualStyleBackColor = true;
            this.btnCargaMasiva.Click += new System.EventHandler(this.btnCargaMasiva_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnGenerarFile
            // 
            this.btnGenerarFile.Depth = 0;
            this.btnGenerarFile.Location = new System.Drawing.Point(275, 324);
            this.btnGenerarFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerarFile.Name = "btnGenerarFile";
            this.btnGenerarFile.Primary = true;
            this.btnGenerarFile.Size = new System.Drawing.Size(16, 14);
            this.btnGenerarFile.TabIndex = 18;
            this.btnGenerarFile.Text = "..";
            this.btnGenerarFile.UseVisualStyleBackColor = true;
            this.btnGenerarFile.Click += new System.EventHandler(this.btnGenerarFile_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Depth = 0;
            this.btnGenerarReporte.Location = new System.Drawing.Point(47, 230);
            this.btnGenerarReporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Primary = true;
            this.btnGenerarReporte.Size = new System.Drawing.Size(244, 45);
            this.btnGenerarReporte.TabIndex = 7;
            this.btnGenerarReporte.Text = "Reportes";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnBandejaSalida
            // 
            this.btnBandejaSalida.Depth = 0;
            this.btnBandejaSalida.Location = new System.Drawing.Point(47, 353);
            this.btnBandejaSalida.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBandejaSalida.Name = "btnBandejaSalida";
            this.btnBandejaSalida.Primary = true;
            this.btnBandejaSalida.Size = new System.Drawing.Size(244, 45);
            this.btnBandejaSalida.TabIndex = 19;
            this.btnBandejaSalida.Text = "BANDEJA DE SALIDA";
            this.btnBandejaSalida.UseVisualStyleBackColor = true;
            this.btnBandejaSalida.Click += new System.EventHandler(this.btnBandejaSalida_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(255, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 410);
            this.Controls.Add(this.btnBandejaSalida);
            this.Controls.Add(this.btnGenerarFile);
            this.Controls.Add(this.btnCargaMasiva);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnNuevoRegistro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicación Teatro";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btnNuevoRegistro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCargaMasiva;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerarFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerarReporte;
        private MaterialSkin.Controls.MaterialRaisedButton btnBandejaSalida;
    }
}