namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    partial class ManObraCrear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManObraCrear));
            this.lblNomObra = new MaterialSkin.Controls.MaterialLabel();
            this.txtNomObra = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblFecIniObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblFecFinObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblDescripcionObra = new MaterialSkin.Controls.MaterialLabel();
            this.txtDescripcionObra = new System.Windows.Forms.RichTextBox();
            this.lblEstadoObra = new MaterialSkin.Controls.MaterialLabel();
            this.cboEstadoObra = new MetroFramework.Controls.MetroComboBox();
            this.cboTeatroObra = new MetroFramework.Controls.MetroComboBox();
            this.lblTeatroObra = new MaterialSkin.Controls.MaterialLabel();
            this.btnAceptarObra = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dtpFecIniObra = new System.Windows.Forms.DateTimePicker();
            this.dtpFecFinObra = new System.Windows.Forms.DateTimePicker();
            this.gbDatosObra = new System.Windows.Forms.GroupBox();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbDatosObra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomObra
            // 
            this.lblNomObra.AutoSize = true;
            this.lblNomObra.BackColor = System.Drawing.Color.Transparent;
            this.lblNomObra.Depth = 0;
            this.lblNomObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNomObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNomObra.Location = new System.Drawing.Point(15, 36);
            this.lblNomObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNomObra.Name = "lblNomObra";
            this.lblNomObra.Size = new System.Drawing.Size(44, 19);
            this.lblNomObra.TabIndex = 0;
            this.lblNomObra.Text = "Obra:";
            // 
            // txtNomObra
            // 
            this.txtNomObra.BackColor = System.Drawing.Color.White;
            this.txtNomObra.Depth = 0;
            this.txtNomObra.Hint = "";
            this.txtNomObra.Location = new System.Drawing.Point(173, 32);
            this.txtNomObra.MaxLength = 32767;
            this.txtNomObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNomObra.Name = "txtNomObra";
            this.txtNomObra.PasswordChar = '\0';
            this.txtNomObra.SelectedText = "";
            this.txtNomObra.SelectionLength = 0;
            this.txtNomObra.SelectionStart = 0;
            this.txtNomObra.Size = new System.Drawing.Size(241, 23);
            this.txtNomObra.TabIndex = 1;
            this.txtNomObra.TabStop = false;
            this.txtNomObra.UseSystemPasswordChar = false;
            // 
            // lblFecIniObra
            // 
            this.lblFecIniObra.AutoSize = true;
            this.lblFecIniObra.BackColor = System.Drawing.Color.Transparent;
            this.lblFecIniObra.Depth = 0;
            this.lblFecIniObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFecIniObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFecIniObra.Location = new System.Drawing.Point(15, 79);
            this.lblFecIniObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFecIniObra.Name = "lblFecIniObra";
            this.lblFecIniObra.Size = new System.Drawing.Size(94, 19);
            this.lblFecIniObra.TabIndex = 3;
            this.lblFecIniObra.Text = "Fecha Inicio:";
            // 
            // lblFecFinObra
            // 
            this.lblFecFinObra.AutoSize = true;
            this.lblFecFinObra.BackColor = System.Drawing.Color.Transparent;
            this.lblFecFinObra.Depth = 0;
            this.lblFecFinObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFecFinObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFecFinObra.Location = new System.Drawing.Point(15, 134);
            this.lblFecFinObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFecFinObra.Name = "lblFecFinObra";
            this.lblFecFinObra.Size = new System.Drawing.Size(77, 19);
            this.lblFecFinObra.TabIndex = 5;
            this.lblFecFinObra.Text = "Fecha Fin:";
            // 
            // lblDescripcionObra
            // 
            this.lblDescripcionObra.AutoSize = true;
            this.lblDescripcionObra.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcionObra.Depth = 0;
            this.lblDescripcionObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDescripcionObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescripcionObra.Location = new System.Drawing.Point(15, 282);
            this.lblDescripcionObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDescripcionObra.Name = "lblDescripcionObra";
            this.lblDescripcionObra.Size = new System.Drawing.Size(93, 19);
            this.lblDescripcionObra.TabIndex = 6;
            this.lblDescripcionObra.Text = "Descripción:";
            // 
            // txtDescripcionObra
            // 
            this.txtDescripcionObra.Location = new System.Drawing.Point(173, 282);
            this.txtDescripcionObra.Name = "txtDescripcionObra";
            this.txtDescripcionObra.Size = new System.Drawing.Size(241, 96);
            this.txtDescripcionObra.TabIndex = 7;
            this.txtDescripcionObra.Text = "";
            // 
            // lblEstadoObra
            // 
            this.lblEstadoObra.AutoSize = true;
            this.lblEstadoObra.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoObra.Depth = 0;
            this.lblEstadoObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEstadoObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstadoObra.Location = new System.Drawing.Point(15, 184);
            this.lblEstadoObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEstadoObra.Name = "lblEstadoObra";
            this.lblEstadoObra.Size = new System.Drawing.Size(60, 19);
            this.lblEstadoObra.TabIndex = 8;
            this.lblEstadoObra.Text = "Estado:";
            // 
            // cboEstadoObra
            // 
            this.cboEstadoObra.FormattingEnabled = true;
            this.cboEstadoObra.ItemHeight = 23;
            this.cboEstadoObra.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoObra.Location = new System.Drawing.Point(173, 174);
            this.cboEstadoObra.Name = "cboEstadoObra";
            this.cboEstadoObra.Size = new System.Drawing.Size(241, 29);
            this.cboEstadoObra.TabIndex = 9;
            // 
            // cboTeatroObra
            // 
            this.cboTeatroObra.FormattingEnabled = true;
            this.cboTeatroObra.ItemHeight = 23;
            this.cboTeatroObra.Location = new System.Drawing.Point(173, 223);
            this.cboTeatroObra.Name = "cboTeatroObra";
            this.cboTeatroObra.Size = new System.Drawing.Size(241, 29);
            this.cboTeatroObra.TabIndex = 11;
            // 
            // lblTeatroObra
            // 
            this.lblTeatroObra.AutoSize = true;
            this.lblTeatroObra.BackColor = System.Drawing.Color.Transparent;
            this.lblTeatroObra.Depth = 0;
            this.lblTeatroObra.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTeatroObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTeatroObra.Location = new System.Drawing.Point(15, 233);
            this.lblTeatroObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTeatroObra.Name = "lblTeatroObra";
            this.lblTeatroObra.Size = new System.Drawing.Size(57, 19);
            this.lblTeatroObra.TabIndex = 10;
            this.lblTeatroObra.Text = "Teatro:";
            // 
            // btnAceptarObra
            // 
            this.btnAceptarObra.Depth = 0;
            this.btnAceptarObra.Location = new System.Drawing.Point(553, 338);
            this.btnAceptarObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAceptarObra.Name = "btnAceptarObra";
            this.btnAceptarObra.Primary = true;
            this.btnAceptarObra.Size = new System.Drawing.Size(168, 40);
            this.btnAceptarObra.TabIndex = 12;
            this.btnAceptarObra.Text = "Crear";
            this.btnAceptarObra.UseVisualStyleBackColor = true;
            this.btnAceptarObra.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // dtpFecIniObra
            // 
            this.dtpFecIniObra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIniObra.Location = new System.Drawing.Point(173, 77);
            this.dtpFecIniObra.Name = "dtpFecIniObra";
            this.dtpFecIniObra.Size = new System.Drawing.Size(241, 20);
            this.dtpFecIniObra.TabIndex = 14;
            // 
            // dtpFecFinObra
            // 
            this.dtpFecFinObra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinObra.Location = new System.Drawing.Point(173, 132);
            this.dtpFecFinObra.Name = "dtpFecFinObra";
            this.dtpFecFinObra.Size = new System.Drawing.Size(241, 20);
            this.dtpFecFinObra.TabIndex = 15;
            // 
            // gbDatosObra
            // 
            this.gbDatosObra.BackColor = System.Drawing.Color.White;
            this.gbDatosObra.Controls.Add(this.btnCargarImagen);
            this.gbDatosObra.Controls.Add(this.pcbImagen);
            this.gbDatosObra.Controls.Add(this.btnAceptarObra);
            this.gbDatosObra.Controls.Add(this.materialLabel1);
            this.gbDatosObra.Controls.Add(this.txtNomObra);
            this.gbDatosObra.Controls.Add(this.dtpFecFinObra);
            this.gbDatosObra.Controls.Add(this.lblNomObra);
            this.gbDatosObra.Controls.Add(this.dtpFecIniObra);
            this.gbDatosObra.Controls.Add(this.lblFecIniObra);
            this.gbDatosObra.Controls.Add(this.lblFecFinObra);
            this.gbDatosObra.Controls.Add(this.lblDescripcionObra);
            this.gbDatosObra.Controls.Add(this.cboTeatroObra);
            this.gbDatosObra.Controls.Add(this.txtDescripcionObra);
            this.gbDatosObra.Controls.Add(this.lblTeatroObra);
            this.gbDatosObra.Controls.Add(this.lblEstadoObra);
            this.gbDatosObra.Controls.Add(this.cboEstadoObra);
            this.gbDatosObra.Location = new System.Drawing.Point(12, 71);
            this.gbDatosObra.Name = "gbDatosObra";
            this.gbDatosObra.Size = new System.Drawing.Size(756, 396);
            this.gbDatosObra.TabIndex = 16;
            this.gbDatosObra.TabStop = false;
            this.gbDatosObra.Text = "Datos";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(695, 278);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(25, 23);
            this.btnCargarImagen.TabIndex = 63;
            this.btnCargarImagen.Text = "...";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // pcbImagen
            // 
            this.pcbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbImagen.Location = new System.Drawing.Point(521, 36);
            this.pcbImagen.Name = "pcbImagen";
            this.pcbImagen.Size = new System.Drawing.Size(200, 266);
            this.pcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagen.TabIndex = 62;
            this.pcbImagen.TabStop = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(443, 36);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(62, 19);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "Imagen:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(404, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // ManObraCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 486);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbDatosObra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManObraCrear";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Obra";
            this.Load += new System.EventHandler(this.ManPlayCreate_Load);
            this.gbDatosObra.ResumeLayout(false);
            this.gbDatosObra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblNomObra;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNomObra;
        private MaterialSkin.Controls.MaterialLabel lblFecIniObra;
        private MaterialSkin.Controls.MaterialLabel lblFecFinObra;
        private MaterialSkin.Controls.MaterialLabel lblDescripcionObra;
        private System.Windows.Forms.RichTextBox txtDescripcionObra;
        private MaterialSkin.Controls.MaterialLabel lblEstadoObra;
        private MetroFramework.Controls.MetroComboBox cboEstadoObra;
        private MetroFramework.Controls.MetroComboBox cboTeatroObra;
        private MaterialSkin.Controls.MaterialLabel lblTeatroObra;
        private MaterialSkin.Controls.MaterialRaisedButton btnAceptarObra;
        private System.Windows.Forms.DateTimePicker dtpFecIniObra;
        private System.Windows.Forms.DateTimePicker dtpFecFinObra;
        private System.Windows.Forms.GroupBox gbDatosObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.PictureBox pcbImagen;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}