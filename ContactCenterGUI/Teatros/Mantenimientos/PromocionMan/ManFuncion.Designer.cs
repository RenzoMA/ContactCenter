namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    partial class ManPromocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManPromocion));
            this.btnCrear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cboFuncion = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.btnBuscar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvPromociones = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Depth = 0;
            this.btnCrear.Location = new System.Drawing.Point(331, 549);
            this.btnCrear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Primary = true;
            this.btnCrear.Size = new System.Drawing.Size(101, 32);
            this.btnCrear.TabIndex = 12;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.cboFuncion);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.cboObra);
            this.groupBox1.Controls.Add(this.cboTeatro);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 148);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(22, 98);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(62, 19);
            this.materialLabel2.TabIndex = 16;
            this.materialLabel2.Text = "Función";
            // 
            // cboFuncion
            // 
            this.cboFuncion.FormattingEnabled = true;
            this.cboFuncion.ItemHeight = 23;
            this.cboFuncion.Location = new System.Drawing.Point(102, 90);
            this.cboFuncion.Name = "cboFuncion";
            this.cboFuncion.Size = new System.Drawing.Size(241, 29);
            this.cboFuncion.TabIndex = 15;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(22, 62);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(44, 19);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Obra:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(22, 28);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(57, 19);
            this.materialLabel5.TabIndex = 13;
            this.materialLabel5.Text = "Teatro:";
            // 
            // cboObra
            // 
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 23;
            this.cboObra.Location = new System.Drawing.Point(102, 55);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(241, 29);
            this.cboObra.TabIndex = 13;
            this.cboObra.SelectionChangeCommitted += new System.EventHandler(this.cboObra_SelectionChangeCommitted);
            // 
            // cboTeatro
            // 
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 23;
            this.cboTeatro.Location = new System.Drawing.Point(102, 19);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(241, 29);
            this.cboTeatro.TabIndex = 12;
            this.cboTeatro.SelectionChangeCommitted += new System.EventHandler(this.cboTeatro_SelectionChangeCommitted);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Depth = 0;
            this.btnBuscar.Location = new System.Drawing.Point(493, 22);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Primary = true;
            this.btnBuscar.Size = new System.Drawing.Size(101, 32);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPromociones
            // 
            this.dgvPromociones.AllowUserToAddRows = false;
            this.dgvPromociones.AllowUserToDeleteRows = false;
            this.dgvPromociones.BackgroundColor = System.Drawing.Color.White;
            this.dgvPromociones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromociones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.FechaInicio,
            this.FechaFin,
            this.Descripcion,
            this.TipoDescuento,
            this.Descuento,
            this.Estado});
            this.dgvPromociones.Location = new System.Drawing.Point(12, 240);
            this.dgvPromociones.Name = "dgvPromociones";
            this.dgvPromociones.ReadOnly = true;
            this.dgvPromociones.RowHeadersVisible = false;
            this.dgvPromociones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromociones.Size = new System.Drawing.Size(750, 303);
            this.dgvPromociones.TabIndex = 10;
            this.dgvPromociones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromociones_CellContentClick);
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
            // TipoDescuento
            // 
            this.TipoDescuento.DataPropertyName = "TipoDescuento";
            this.TipoDescuento.HeaderText = "TipoDescuento";
            this.TipoDescuento.Name = "TipoDescuento";
            this.TipoDescuento.ReadOnly = true;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_edit;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // ManPromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 595);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPromociones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManPromocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Promociones";
            this.Load += new System.EventHandler(this.ManFuncion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCrear;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscar;
        private System.Windows.Forms.DataGridView dgvPromociones;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MetroFramework.Controls.MetroComboBox cboFuncion;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}