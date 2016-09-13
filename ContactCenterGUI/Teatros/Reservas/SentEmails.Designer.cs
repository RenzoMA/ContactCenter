namespace ContactCenterGUI.Teatros.Reservas
{
    partial class SentEmails
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
            this.IdEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reenviar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmail
            // 
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmail,
            this.CorreoDestino,
            this.FechaEnvio,
            this.Estado,
            this.Intento,
            this.Reenviar});
            this.dgvEmail.Location = new System.Drawing.Point(12, 70);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmail.Size = new System.Drawing.Size(749, 494);
            this.dgvEmail.TabIndex = 14;
            // 
            // IdEmail
            // 
            this.IdEmail.DataPropertyName = "IdLogEmail";
            this.IdEmail.HeaderText = "IdLogEmail";
            this.IdEmail.Name = "IdEmail";
            this.IdEmail.ReadOnly = true;
            this.IdEmail.Visible = false;
            // 
            // CorreoDestino
            // 
            this.CorreoDestino.DataPropertyName = "CorreoDestino";
            this.CorreoDestino.HeaderText = "Destino";
            this.CorreoDestino.Name = "CorreoDestino";
            this.CorreoDestino.ReadOnly = true;
            // 
            // FechaEnvio
            // 
            this.FechaEnvio.DataPropertyName = "FechaEnvio";
            this.FechaEnvio.HeaderText = "Fecha de envío";
            this.FechaEnvio.Name = "FechaEnvio";
            this.FechaEnvio.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Intento
            // 
            this.Intento.DataPropertyName = "Intento";
            this.Intento.HeaderText = "Intentos";
            this.Intento.Name = "Intento";
            this.Intento.ReadOnly = true;
            // 
            // Reenviar
            // 
            this.Reenviar.HeaderText = "Reenviar";
            this.Reenviar.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_edit;
            this.Reenviar.Name = "Reenviar";
            this.Reenviar.ReadOnly = true;
            // 
            // SentEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 576);
            this.Controls.Add(this.dgvEmail);
            this.Name = "SentEmails";
            this.Text = "Bandeja de salida";
            this.Load += new System.EventHandler(this.SentEmails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intento;
        private System.Windows.Forms.DataGridViewImageColumn Reenviar;
    }
}