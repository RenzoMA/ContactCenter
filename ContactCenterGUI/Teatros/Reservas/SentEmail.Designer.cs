namespace ContactCenterGUI.Teatros.Reservas
{
    partial class SentEmail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdLogEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensaje = new System.Windows.Forms.DataGridViewImageColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmail
            // 
            this.dgvEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLogEmail,
            this.FechaFin,
            this.FechaInicio,
            this.UsuarioModificacion,
            this.Estado,
            this.Error,
            this.Intento,
            this.Mensaje,
            this.FechaCreacion,
            this.UsuarioCreacion});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmail.Location = new System.Drawing.Point(12, 134);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmail.Size = new System.Drawing.Size(968, 423);
            this.dgvEmail.TabIndex = 14;
            this.dgvEmail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmail_CellContentClick);
            this.dgvEmail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmail_CellFormatting);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(920, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Reenviar";
            this.dataGridViewImageColumn1.Image = global::ContactCenterGUI.Properties.Resources._forward_icon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 140;
            // 
            // IdLogEmail
            // 
            this.IdLogEmail.DataPropertyName = "IdLogEmail";
            this.IdLogEmail.HeaderText = "IdEmail";
            this.IdLogEmail.Name = "IdLogEmail";
            this.IdLogEmail.ReadOnly = true;
            this.IdLogEmail.Visible = false;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "CorreoDestino";
            this.FechaFin.HeaderText = "Destino";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 160;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaEnvio";
            this.FechaInicio.HeaderText = "Ultimo Envío";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 140;
            // 
            // UsuarioModificacion
            // 
            this.UsuarioModificacion.DataPropertyName = "UsuarioModificacion";
            this.UsuarioModificacion.HeaderText = "Usuario Modificacion";
            this.UsuarioModificacion.Name = "UsuarioModificacion";
            this.UsuarioModificacion.ReadOnly = true;
            this.UsuarioModificacion.Width = 120;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 80;
            // 
            // Error
            // 
            this.Error.DataPropertyName = "Descripcion";
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            // 
            // Intento
            // 
            this.Intento.DataPropertyName = "Intento";
            this.Intento.HeaderText = "Intentos";
            this.Intento.Name = "Intento";
            this.Intento.ReadOnly = true;
            this.Intento.Width = 50;
            // 
            // Mensaje
            // 
            this.Mensaje.HeaderText = "Mensaje";
            this.Mensaje.Image = global::ContactCenterGUI.Properties.Resources.mensaje;
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mensaje.Width = 50;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            this.FechaCreacion.HeaderText = "Fecha Creacion";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 120;
            // 
            // UsuarioCreacion
            // 
            this.UsuarioCreacion.DataPropertyName = "UsuarioCreacion";
            this.UsuarioCreacion.HeaderText = "Usuario Creacion";
            this.UsuarioCreacion.Name = "UsuarioCreacion";
            this.UsuarioCreacion.ReadOnly = true;
            this.UsuarioCreacion.Width = 120;
            // 
            // SentEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 569);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvEmail);
            this.MaximizeBox = false;
            this.Name = "SentEmail";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bandeja de salida";
            this.Load += new System.EventHandler(this.SentEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLogEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intento;
        private System.Windows.Forms.DataGridViewImageColumn Mensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioCreacion;
    }
}