namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    partial class ManTarifa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManTarifa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCrear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvTarifa = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.tari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.cboTeatro);
            this.groupBox1.Controls.Add(this.cboObra);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Depth = 0;
            this.btnBuscar.Location = new System.Drawing.Point(525, 15);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Primary = true;
            this.btnBuscar.Size = new System.Drawing.Size(168, 40);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(35, 36);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(53, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Teatro";
            // 
            // cboTeatro
            // 
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 23;
            this.cboTeatro.Location = new System.Drawing.Point(121, 26);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(243, 29);
            this.cboTeatro.TabIndex = 13;
            this.cboTeatro.SelectedIndexChanged += new System.EventHandler(this.cboTeatro_SelectedIndexChanged);
            // 
            // cboObra
            // 
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 23;
            this.cboObra.Location = new System.Drawing.Point(121, 75);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(243, 29);
            this.cboObra.TabIndex = 12;
            this.cboObra.SelectedIndexChanged += new System.EventHandler(this.cboObra_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 85);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(40, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Obra";
            // 
            // btnCrear
            // 
            this.btnCrear.Depth = 0;
            this.btnCrear.Location = new System.Drawing.Point(275, 543);
            this.btnCrear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Primary = true;
            this.btnCrear.Size = new System.Drawing.Size(168, 40);
            this.btnCrear.TabIndex = 10;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = ((System.Drawing.Image)(resources.GetObject("Editar.Image")));
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Editar.Name = "Editar";
            this.Editar.Width = 101;
            // 
            // dgvTarifa
            // 
            this.dgvTarifa.AllowUserToAddRows = false;
            this.dgvTarifa.AllowUserToDeleteRows = false;
            this.dgvTarifa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTarifa.BackgroundColor = System.Drawing.Color.White;
            this.dgvTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit,
            this.tari,
            this.zona,
            this.pre});
            this.dgvTarifa.Location = new System.Drawing.Point(13, 241);
            this.dgvTarifa.Name = "dgvTarifa";
            this.dgvTarifa.ReadOnly = true;
            this.dgvTarifa.RowHeadersVisible = false;
            this.dgvTarifa.Size = new System.Drawing.Size(698, 285);
            this.dgvTarifa.TabIndex = 11;
            this.dgvTarifa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarifa_CellContentClick);
            // 
            // edit
            // 
            this.edit.HeaderText = "Editar";
            this.edit.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_edit;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            // 
            // tari
            // 
            this.tari.DataPropertyName = "IdTarifa";
            this.tari.HeaderText = "Tarifa";
            this.tari.Name = "tari";
            this.tari.ReadOnly = true;
            this.tari.Visible = false;
            // 
            // zona
            // 
            this.zona.DataPropertyName = "NombreZona";
            this.zona.HeaderText = "Zona";
            this.zona.Name = "zona";
            this.zona.ReadOnly = true;
            // 
            // pre
            // 
            this.pre.DataPropertyName = "Precio";
            this.pre.HeaderText = "Precio";
            this.pre.Name = "pre";
            this.pre.ReadOnly = true;
            // 
            // ManTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 595);
            this.Controls.Add(this.dgvTarifa);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManTarifa";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Tarifas";
            this.Load += new System.EventHandler(this.ManTarifa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCrear;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridView dgvTarifa;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscar;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tari;
        private System.Windows.Forms.DataGridViewTextBoxColumn zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn pre;
    }
}