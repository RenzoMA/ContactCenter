namespace ContactCenterGUI.Teatros.Mantenimientos.AsientoMan
{
    partial class ManAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManAsiento));
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboZona = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnDeshabilitar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnHabilitar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCheckAll = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.checkAsiento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.AllowUserToDeleteRows = false;
            this.dgvAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkAsiento,
            this.IdAsiento,
            this.Descripcion,
            this.Fila,
            this.Disponible});
            this.dgvAsientos.Location = new System.Drawing.Point(12, 266);
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.ReadOnly = true;
            this.dgvAsientos.RowHeadersVisible = false;
            this.dgvAsientos.Size = new System.Drawing.Size(423, 410);
            this.dgvAsientos.TabIndex = 3;
            this.dgvAsientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsientos_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.materialRaisedButton1);
            this.groupBox1.Controls.Add(this.cboZona);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.cboObra);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.cboTeatro);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activar Asientos";
            // 
            // cboZona
            // 
            this.cboZona.FormattingEnabled = true;
            this.cboZona.ItemHeight = 23;
            this.cboZona.Location = new System.Drawing.Point(101, 89);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(241, 29);
            this.cboZona.TabIndex = 16;
            this.cboZona.SelectionChangeCommitted += new System.EventHandler(this.cboZona_SelectionChangeCommitted);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(20, 99);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(47, 19);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "Zona:";
            // 
            // cboObra
            // 
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 23;
            this.cboObra.Location = new System.Drawing.Point(101, 54);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(241, 29);
            this.cboObra.TabIndex = 13;
            this.cboObra.SelectionChangeCommitted += new System.EventHandler(this.cboObra_SelectionChangeCommitted);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(20, 64);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(44, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Obra:";
            // 
            // cboTeatro
            // 
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 23;
            this.cboTeatro.Location = new System.Drawing.Point(101, 19);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(241, 29);
            this.cboTeatro.TabIndex = 11;
            this.cboTeatro.SelectionChangeCommitted += new System.EventHandler(this.cboTeatro_SelectionChangeCommitted);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(20, 29);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(57, 19);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Teatro:";
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Depth = 0;
            this.btnDeshabilitar.Location = new System.Drawing.Point(450, 385);
            this.btnDeshabilitar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Primary = true;
            this.btnDeshabilitar.Size = new System.Drawing.Size(168, 40);
            this.btnDeshabilitar.TabIndex = 15;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Depth = 0;
            this.btnHabilitar.Location = new System.Drawing.Point(450, 326);
            this.btnHabilitar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Primary = true;
            this.btnHabilitar.Size = new System.Drawing.Size(168, 40);
            this.btnHabilitar.TabIndex = 16;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Depth = 0;
            this.btnCheckAll.Location = new System.Drawing.Point(450, 266);
            this.btnCheckAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Primary = true;
            this.btnCheckAll.Size = new System.Drawing.Size(168, 40);
            this.btnCheckAll.TabIndex = 17;
            this.btnCheckAll.Text = "Check Todo";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(395, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "S : SÍ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(395, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "N : NO";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(438, 19);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(168, 40);
            this.materialRaisedButton1.TabIndex = 17;
            this.materialRaisedButton1.Text = "ASIGNAR ASIENTOS";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // checkAsiento
            // 
            this.checkAsiento.FalseValue = "";
            this.checkAsiento.HeaderText = "Sel.";
            this.checkAsiento.Name = "checkAsiento";
            this.checkAsiento.ReadOnly = true;
            this.checkAsiento.TrueValue = "";
            // 
            // IdAsiento
            // 
            this.IdAsiento.DataPropertyName = "IdAsiento";
            this.IdAsiento.HeaderText = "IdAsiento";
            this.IdAsiento.Name = "IdAsiento";
            this.IdAsiento.ReadOnly = true;
            this.IdAsiento.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "AsientoDescripcion";
            this.Descripcion.HeaderText = "Asiento";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Fila
            // 
            this.Fila.DataPropertyName = "AsientoFila";
            this.Fila.HeaderText = "Fila";
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            // 
            // Disponible
            // 
            this.Disponible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Disponible.DataPropertyName = "Disponible";
            this.Disponible.HeaderText = "Disponible";
            this.Disponible.Name = "Disponible";
            this.Disponible.ReadOnly = true;
            this.Disponible.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(450, 441);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(168, 40);
            this.materialRaisedButton2.TabIndex = 20;
            this.materialRaisedButton2.Text = "Eliminar";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // ManAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 703);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.dgvAsientos);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManAsiento";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Asientos";
            this.Load += new System.EventHandler(this.ManAsiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsientos;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeshabilitar;
        private MaterialSkin.Controls.MaterialRaisedButton btnHabilitar;
        private MaterialSkin.Controls.MaterialRaisedButton btnCheckAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox cboZona;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponible;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}