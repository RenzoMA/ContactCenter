﻿namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    partial class ManObra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManObra));
            this.gbFiltroObra = new System.Windows.Forms.GroupBox();
            this.lblFiltroObra = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeFilObra = new MetroFramework.Controls.MetroComboBox();
            this.btnBuscarObra = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvObras = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevaObra = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbFiltroObra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltroObra
            // 
            this.gbFiltroObra.BackColor = System.Drawing.Color.White;
            this.gbFiltroObra.Controls.Add(this.lblFiltroObra);
            this.gbFiltroObra.Controls.Add(this.cboTeFilObra);
            this.gbFiltroObra.Controls.Add(this.btnBuscarObra);
            this.gbFiltroObra.Location = new System.Drawing.Point(22, 78);
            this.gbFiltroObra.Name = "gbFiltroObra";
            this.gbFiltroObra.Size = new System.Drawing.Size(648, 148);
            this.gbFiltroObra.TabIndex = 12;
            this.gbFiltroObra.TabStop = false;
            this.gbFiltroObra.Text = "Filtros";
            // 
            // lblFiltroObra
            // 
            this.lblFiltroObra.AutoSize = true;
            this.lblFiltroObra.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltroObra.Depth = 0;
            this.lblFiltroObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFiltroObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFiltroObra.Location = new System.Drawing.Point(17, 48);
            this.lblFiltroObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFiltroObra.Name = "lblFiltroObra";
            this.lblFiltroObra.Size = new System.Drawing.Size(57, 19);
            this.lblFiltroObra.TabIndex = 13;
            this.lblFiltroObra.Text = "Teatro:";
            // 
            // cboTeFilObra
            // 
            this.cboTeFilObra.FormattingEnabled = true;
            this.cboTeFilObra.ItemHeight = 23;
            this.cboTeFilObra.Location = new System.Drawing.Point(97, 39);
            this.cboTeFilObra.Name = "cboTeFilObra";
            this.cboTeFilObra.Size = new System.Drawing.Size(241, 29);
            this.cboTeFilObra.TabIndex = 12;
            // 
            // btnBuscarObra
            // 
            this.btnBuscarObra.Depth = 0;
            this.btnBuscarObra.Location = new System.Drawing.Point(438, 48);
            this.btnBuscarObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarObra.Name = "btnBuscarObra";
            this.btnBuscarObra.Primary = true;
            this.btnBuscarObra.Size = new System.Drawing.Size(168, 40);
            this.btnBuscarObra.TabIndex = 10;
            this.btnBuscarObra.Text = "Buscar";
            this.btnBuscarObra.UseVisualStyleBackColor = true;
            this.btnBuscarObra.Click += new System.EventHandler(this.btnBuscarObra_Click);
            // 
            // dgvObras
            // 
            this.dgvObras.AllowUserToAddRows = false;
            this.dgvObras.AllowUserToDeleteRows = false;
            this.dgvObras.BackgroundColor = System.Drawing.Color.White;
            this.dgvObras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvObras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.FechaInicio,
            this.FechaFin,
            this.Descripcion,
            this.Nombre,
            this.Estado});
            this.dgvObras.Location = new System.Drawing.Point(22, 232);
            this.dgvObras.Name = "dgvObras";
            this.dgvObras.ReadOnly = true;
            this.dgvObras.RowHeadersVisible = false;
            this.dgvObras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObras.Size = new System.Drawing.Size(648, 303);
            this.dgvObras.TabIndex = 13;
            this.dgvObras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObras_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_edit;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 45;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "FechaInicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "FechaFin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Obra";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // btnNuevaObra
            // 
            this.btnNuevaObra.Depth = 0;
            this.btnNuevaObra.Location = new System.Drawing.Point(502, 543);
            this.btnNuevaObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNuevaObra.Name = "btnNuevaObra";
            this.btnNuevaObra.Primary = true;
            this.btnNuevaObra.Size = new System.Drawing.Size(168, 40);
            this.btnNuevaObra.TabIndex = 14;
            this.btnNuevaObra.Text = "Nuevo";
            this.btnNuevaObra.UseVisualStyleBackColor = true;
            this.btnNuevaObra.Click += new System.EventHandler(this.btnNuevaObra_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(623, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ManObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 595);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNuevaObra);
            this.Controls.Add(this.dgvObras);
            this.Controls.Add(this.gbFiltroObra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión Obra";
            this.Load += new System.EventHandler(this.ManObra_Load);
            this.gbFiltroObra.ResumeLayout(false);
            this.gbFiltroObra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltroObra;
        private MaterialSkin.Controls.MaterialLabel lblFiltroObra;
        private MetroFramework.Controls.MetroComboBox cboTeFilObra;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscarObra;
        private System.Windows.Forms.DataGridView dgvObras;
        private MaterialSkin.Controls.MaterialRaisedButton btnNuevaObra;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}