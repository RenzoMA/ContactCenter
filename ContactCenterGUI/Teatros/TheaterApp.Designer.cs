﻿namespace ContactCenterGUI.Teatros
{
    partial class TheaterApp
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
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnProcesarPromociones = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnGenerarReporte = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAmpliarTeatro = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNuevoRegistro = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // 
            // btnProcesarPromociones
            // 
            this.btnProcesarPromociones.Depth = 0;
            this.btnProcesarPromociones.Location = new System.Drawing.Point(47, 356);
            this.btnProcesarPromociones.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProcesarPromociones.Name = "btnProcesarPromociones";
            this.btnProcesarPromociones.Primary = true;
            this.btnProcesarPromociones.Size = new System.Drawing.Size(244, 45);
            this.btnProcesarPromociones.TabIndex = 8;
            this.btnProcesarPromociones.Text = "Generar Promociones";
            this.btnProcesarPromociones.UseVisualStyleBackColor = true;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Depth = 0;
            this.btnGenerarReporte.Location = new System.Drawing.Point(47, 295);
            this.btnGenerarReporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Primary = true;
            this.btnGenerarReporte.Size = new System.Drawing.Size(244, 45);
            this.btnGenerarReporte.TabIndex = 7;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // btnAmpliarTeatro
            // 
            this.btnAmpliarTeatro.Depth = 0;
            this.btnAmpliarTeatro.Location = new System.Drawing.Point(47, 232);
            this.btnAmpliarTeatro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAmpliarTeatro.Name = "btnAmpliarTeatro";
            this.btnAmpliarTeatro.Primary = true;
            this.btnAmpliarTeatro.Size = new System.Drawing.Size(244, 45);
            this.btnAmpliarTeatro.TabIndex = 6;
            this.btnAmpliarTeatro.Text = "Ampliar Teatro";
            this.btnAmpliarTeatro.UseVisualStyleBackColor = true;
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
            // TheaterApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 451);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btnProcesarPromociones);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnAmpliarTeatro);
            this.Controls.Add(this.btnNuevoRegistro);
            this.MaximizeBox = false;
            this.Name = "TheaterApp";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheaterApp";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btnProcesarPromociones;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenerarReporte;
        private MaterialSkin.Controls.MaterialRaisedButton btnAmpliarTeatro;
        private MaterialSkin.Controls.MaterialRaisedButton btnNuevoRegistro;
    }
}