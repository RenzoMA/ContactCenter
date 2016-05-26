﻿namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    partial class ManAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManAplicacion));
            this.dgbAplicacion = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgbAplicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgbAplicacion
            // 
            this.dgbAplicacion.AllowUserToAddRows = false;
            this.dgbAplicacion.AllowUserToDeleteRows = false;
            this.dgbAplicacion.BackgroundColor = System.Drawing.Color.White;
            this.dgbAplicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbAplicacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Nombre,
            this.Correo});
            this.dgbAplicacion.Location = new System.Drawing.Point(12, 78);
            this.dgbAplicacion.Name = "dgbAplicacion";
            this.dgbAplicacion.ReadOnly = true;
            this.dgbAplicacion.RowHeadersVisible = false;
            this.dgbAplicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbAplicacion.Size = new System.Drawing.Size(773, 419);
            this.dgbAplicacion.TabIndex = 0;
            this.dgbAplicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbAplicacion_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_edit;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 45;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 300;
            // 
            // Correo
            // 
            this.Correo.DataPropertyName = "Correo";
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 300;
            // 
            // ManAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 509);
            this.Controls.Add(this.dgbAplicacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManAplicacion";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de aplicaciones";
            this.Load += new System.EventHandler(this.ManAppMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbAplicacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgbAplicacion;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
    }
}