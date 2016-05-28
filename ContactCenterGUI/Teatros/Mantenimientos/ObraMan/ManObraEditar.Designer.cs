namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    partial class ManObraEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManObraEditar));
            this.gbDatosObra = new System.Windows.Forms.GroupBox();
            this.dtpFecFinObra = new System.Windows.Forms.DateTimePicker();
            this.lblNomObra = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFecIniObra = new System.Windows.Forms.DateTimePicker();
            this.lblFecIniObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblFecFinObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblDescripcionObra = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeatroObra = new MetroFramework.Controls.MetroComboBox();
            this.txtDescripcionObra = new System.Windows.Forms.RichTextBox();
            this.lblTeatroObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblEstadoObra = new MaterialSkin.Controls.MaterialLabel();
            this.cboEstadoObra = new MetroFramework.Controls.MetroComboBox();
            this.btnAceptarObra = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtNomObra = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.gbDatosObra.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosObra
            // 
            this.gbDatosObra.BackColor = System.Drawing.Color.White;
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
            this.gbDatosObra.Location = new System.Drawing.Point(12, 77);
            this.gbDatosObra.Name = "gbDatosObra";
            this.gbDatosObra.Size = new System.Drawing.Size(444, 411);
            this.gbDatosObra.TabIndex = 18;
            this.gbDatosObra.TabStop = false;
            this.gbDatosObra.Text = "Datos Obra";
            // 
            // dtpFecFinObra
            // 
            this.dtpFecFinObra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinObra.Location = new System.Drawing.Point(173, 132);
            this.dtpFecFinObra.Name = "dtpFecFinObra";
            this.dtpFecFinObra.Size = new System.Drawing.Size(241, 20);
            this.dtpFecFinObra.TabIndex = 15;
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
            // dtpFecIniObra
            // 
            this.dtpFecIniObra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIniObra.Location = new System.Drawing.Point(173, 77);
            this.dtpFecIniObra.Name = "dtpFecIniObra";
            this.dtpFecIniObra.Size = new System.Drawing.Size(241, 20);
            this.dtpFecIniObra.TabIndex = 14;
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
            // cboTeatroObra
            // 
            this.cboTeatroObra.FormattingEnabled = true;
            this.cboTeatroObra.ItemHeight = 23;
            this.cboTeatroObra.Location = new System.Drawing.Point(173, 223);
            this.cboTeatroObra.Name = "cboTeatroObra";
            this.cboTeatroObra.Size = new System.Drawing.Size(241, 29);
            this.cboTeatroObra.TabIndex = 11;
            // 
            // txtDescripcionObra
            // 
            this.txtDescripcionObra.Location = new System.Drawing.Point(173, 282);
            this.txtDescripcionObra.Name = "txtDescripcionObra";
            this.txtDescripcionObra.Size = new System.Drawing.Size(241, 96);
            this.txtDescripcionObra.TabIndex = 7;
            this.txtDescripcionObra.Text = "";
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
            // btnAceptarObra
            // 
            this.btnAceptarObra.Depth = 0;
            this.btnAceptarObra.Location = new System.Drawing.Point(303, 495);
            this.btnAceptarObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAceptarObra.Name = "btnAceptarObra";
            this.btnAceptarObra.Primary = true;
            this.btnAceptarObra.Size = new System.Drawing.Size(168, 40);
            this.btnAceptarObra.TabIndex = 17;
            this.btnAceptarObra.Text = "Aceptar";
            this.btnAceptarObra.UseVisualStyleBackColor = true;
            this.btnAceptarObra.Click += new System.EventHandler(this.btnAceptarObra_Click);
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
            this.txtNomObra.TabIndex = 16;
            this.txtNomObra.TabStop = false;
            this.txtNomObra.UseSystemPasswordChar = false;
            // 
            // ManObraEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 547);
            this.Controls.Add(this.gbDatosObra);
            this.Controls.Add(this.btnAceptarObra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManObraEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Obra";
            this.Load += new System.EventHandler(this.ManObraEditar_Load);
            this.gbDatosObra.ResumeLayout(false);
            this.gbDatosObra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosObra;
        private System.Windows.Forms.DateTimePicker dtpFecFinObra;
        private MaterialSkin.Controls.MaterialLabel lblNomObra;
        private System.Windows.Forms.DateTimePicker dtpFecIniObra;
        private MaterialSkin.Controls.MaterialLabel lblFecIniObra;
        private MaterialSkin.Controls.MaterialLabel lblFecFinObra;
        private MaterialSkin.Controls.MaterialLabel lblDescripcionObra;
        private MetroFramework.Controls.MetroComboBox cboTeatroObra;
        private System.Windows.Forms.RichTextBox txtDescripcionObra;
        private MaterialSkin.Controls.MaterialLabel lblTeatroObra;
        private MaterialSkin.Controls.MaterialLabel lblEstadoObra;
        private MetroFramework.Controls.MetroComboBox cboEstadoObra;
        private MaterialSkin.Controls.MaterialRaisedButton btnAceptarObra;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNomObra;
    }
}