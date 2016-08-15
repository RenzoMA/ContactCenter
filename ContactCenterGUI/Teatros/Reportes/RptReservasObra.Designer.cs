namespace ContactCenterGUI.Teatros.Reportes
{
    partial class RptReservasObra
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTituloTeatro = new MaterialSkin.Controls.MaterialLabel();
            this.btnGenRep = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dtpFechaReservaI = new System.Windows.Forms.DateTimePicker();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaReservaF = new System.Windows.Forms.DateTimePicker();
            this.rptcro = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(36, 127);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 19);
            this.materialLabel1.TabIndex = 17;
            this.materialLabel1.Text = "Fecha Inicio:";
            // 
            // lblTituloTeatro
            // 
            this.lblTituloTeatro.AutoSize = true;
            this.lblTituloTeatro.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloTeatro.Depth = 0;
            this.lblTituloTeatro.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTituloTeatro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTituloTeatro.Location = new System.Drawing.Point(36, 86);
            this.lblTituloTeatro.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTituloTeatro.Name = "lblTituloTeatro";
            this.lblTituloTeatro.Size = new System.Drawing.Size(44, 19);
            this.lblTituloTeatro.TabIndex = 16;
            this.lblTituloTeatro.Text = "Obra:";
            // 
            // btnGenRep
            // 
            this.btnGenRep.Depth = 0;
            this.btnGenRep.Location = new System.Drawing.Point(361, 104);
            this.btnGenRep.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenRep.Name = "btnGenRep";
            this.btnGenRep.Primary = true;
            this.btnGenRep.Size = new System.Drawing.Size(168, 40);
            this.btnGenRep.TabIndex = 15;
            this.btnGenRep.Text = "Generar";
            this.btnGenRep.UseVisualStyleBackColor = true;
            this.btnGenRep.Click += new System.EventHandler(this.btnGenRep_Click);
            // 
            // dtpFechaReservaI
            // 
            this.dtpFechaReservaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReservaI.Location = new System.Drawing.Point(166, 125);
            this.dtpFechaReservaI.Name = "dtpFechaReservaI";
            this.dtpFechaReservaI.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaReservaI.TabIndex = 14;
            // 
            // cboObra
            // 
            this.cboObra.FontSize = MetroFramework.MetroLinkSize.Small;
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 19;
            this.cboObra.Location = new System.Drawing.Point(166, 80);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(170, 25);
            this.cboObra.TabIndex = 13;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(36, 153);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(77, 19);
            this.materialLabel2.TabIndex = 19;
            this.materialLabel2.Text = "Fecha Fin:";
            // 
            // dtpFechaReservaF
            // 
            this.dtpFechaReservaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReservaF.Location = new System.Drawing.Point(166, 151);
            this.dtpFechaReservaF.Name = "dtpFechaReservaF";
            this.dtpFechaReservaF.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaReservaF.TabIndex = 18;
            // 
            // rptcro
            // 
            this.rptcro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptcro.LocalReport.ReportEmbeddedResource = "ContactCenterGUI.Teatros.Reportes.RptReservasObra.rdlc";
            this.rptcro.Location = new System.Drawing.Point(40, 190);
            this.rptcro.Name = "rptcro";
            this.rptcro.Size = new System.Drawing.Size(1175, 448);
            this.rptcro.TabIndex = 20;
            // 
            // RptReservasObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 650);
            this.Controls.Add(this.rptcro);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dtpFechaReservaF);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lblTituloTeatro);
            this.Controls.Add(this.btnGenRep);
            this.Controls.Add(this.dtpFechaReservaI);
            this.Controls.Add(this.cboObra);
            this.MaximizeBox = false;
            this.Name = "RptReservasObra";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Cantidad Reservas";
            this.Load += new System.EventHandler(this.RptReservasObra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblTituloTeatro;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenRep;
        private System.Windows.Forms.DateTimePicker dtpFechaReservaI;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dtpFechaReservaF;
        private Microsoft.Reporting.WinForms.ReportViewer rptcro;
    }
}