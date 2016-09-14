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
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdLogEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensaje = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmail
            // 
            this.dgvEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLogEmail,
            this.FechaFin,
            this.FechaInicio,
            this.Intento,
            this.Estado,
            this.Mensaje});
            this.dgvEmail.Location = new System.Drawing.Point(12, 134);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmail.Size = new System.Drawing.Size(701, 423);
            this.dgvEmail.TabIndex = 14;
            this.dgvEmail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmail_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(650, 2);
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
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaEnvio";
            this.FechaInicio.HeaderText = "Fecha de envío";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            // 
            // Intento
            // 
            this.Intento.DataPropertyName = "Intento";
            this.Intento.HeaderText = "Intentos";
            this.Intento.Name = "Intento";
            this.Intento.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Mensaje
            // 
            this.Mensaje.HeaderText = "Mensaje";
            this.Mensaje.Image = global::ContactCenterGUI.Properties.Resources.mensaje;
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SentEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 569);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Intento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewImageColumn Mensaje;
    }
}