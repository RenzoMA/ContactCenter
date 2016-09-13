namespace ContactCenterGUI.Teatros.Reservas
{
    partial class ReportesTeatro
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGenerarReporte = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnReporteCliente = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(265, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Depth = 0;
            this.btnGenerarReporte.Location = new System.Drawing.Point(49, 118);
            this.btnGenerarReporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Primary = true;
            this.btnGenerarReporte.Size = new System.Drawing.Size(244, 45);
            this.btnGenerarReporte.TabIndex = 16;
            this.btnGenerarReporte.Text = "Reporte Reservas";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnReporteCliente
            // 
            this.btnReporteCliente.Depth = 0;
            this.btnReporteCliente.Location = new System.Drawing.Point(49, 178);
            this.btnReporteCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReporteCliente.Name = "btnReporteCliente";
            this.btnReporteCliente.Primary = true;
            this.btnReporteCliente.Size = new System.Drawing.Size(244, 45);
            this.btnReporteCliente.TabIndex = 17;
            this.btnReporteCliente.Text = "RANKING CLIENTES";
            this.btnReporteCliente.UseVisualStyleBackColor = true;
            this.btnReporteCliente.Click += new System.EventHandler(this.btnReporteCliente_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(49, 239);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(244, 45);
            this.materialRaisedButton2.TabIndex = 18;
            this.materialRaisedButton2.Text = "RESERVA POR TÍTULO DE OBRA";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // ReportesTeatro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 349);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.btnReporteCliente);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "ReportesTeatro";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerarReporte;
        private MaterialSkin.Controls.MaterialRaisedButton btnReporteCliente;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}