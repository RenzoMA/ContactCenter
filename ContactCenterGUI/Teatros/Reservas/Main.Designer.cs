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
            this.btnGenerarReporte = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNuevoRegistro = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReporteCliente = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Depth = 0;
            this.btnGenerarReporte.Location = new System.Drawing.Point(47, 230);
            this.btnGenerarReporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Primary = true;
            this.btnGenerarReporte.Size = new System.Drawing.Size(244, 45);
            this.btnGenerarReporte.TabIndex = 7;
            this.btnGenerarReporte.Text = "Reporte Reservas";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(255, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnReporteCliente
            // 
            this.btnReporteCliente.Depth = 0;
            this.btnReporteCliente.Location = new System.Drawing.Point(47, 290);
            this.btnReporteCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReporteCliente.Name = "btnReporteCliente";
            this.btnReporteCliente.Primary = true;
            this.btnReporteCliente.Size = new System.Drawing.Size(244, 45);
            this.btnReporteCliente.TabIndex = 15;
            this.btnReporteCliente.Text = "RANKING CLIENTES";
            this.btnReporteCliente.UseVisualStyleBackColor = true;
            this.btnReporteCliente.Click += new System.EventHandler(this.btnReporteCliente_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(47, 354);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(244, 45);
            this.materialRaisedButton2.TabIndex = 16;
            this.materialRaisedButton2.Text = "REPORTE RESERVA  POR OBRA";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 420);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.btnReporteCliente);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerarReporte;
        private MaterialSkin.Controls.MaterialRaisedButton btnNuevoRegistro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnReporteCliente;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}