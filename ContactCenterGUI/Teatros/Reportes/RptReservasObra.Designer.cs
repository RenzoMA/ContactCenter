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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reservaObraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptcro = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFechaReservaF = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnGenRep = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dtpFechaReservaI = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.reservaObraBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservaObraBindingSource
            // 
            this.reservaObraBindingSource.DataSource = typeof(ContactCenterBE.CC.TH.Entidades.ReservaBE.ReservaObra);
            // 
            // rptcro
            // 
            this.rptcro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reservaObraBindingSource;
            this.rptcro.LocalReport.DataSources.Add(reportDataSource1);
            this.rptcro.LocalReport.ReportEmbeddedResource = "ContactCenterGUI.Teatros.Reportes.RptReservasObra.rdlc";
            this.rptcro.Location = new System.Drawing.Point(40, 190);
            this.rptcro.Name = "rptcro";
            this.rptcro.Size = new System.Drawing.Size(712, 448);
            this.rptcro.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.dtpFechaReservaF);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btnGenRep);
            this.groupBox1.Controls.Add(this.dtpFechaReservaI);
            this.groupBox1.Location = new System.Drawing.Point(40, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 100);
            this.groupBox1.TabIndex = 21;
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
            this.materialLabel2.Location = new System.Drawing.Point(44, 67);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(77, 19);
            this.materialLabel2.TabIndex = 24;
            this.materialLabel2.Text = "Fecha Fin:";
            // 
            // dtpFechaReservaF
            // 
            this.dtpFechaReservaF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReservaF.Location = new System.Drawing.Point(174, 65);
            this.dtpFechaReservaF.Name = "dtpFechaReservaF";
            this.dtpFechaReservaF.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaReservaF.TabIndex = 23;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(44, 27);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 19);
            this.materialLabel1.TabIndex = 22;
            this.materialLabel1.Text = "Fecha Inicio:";
            // 
            // btnGenRep
            // 
            this.btnGenRep.Depth = 0;
            this.btnGenRep.Location = new System.Drawing.Point(436, 27);
            this.btnGenRep.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenRep.Name = "btnGenRep";
            this.btnGenRep.Primary = true;
            this.btnGenRep.Size = new System.Drawing.Size(168, 40);
            this.btnGenRep.TabIndex = 21;
            this.btnGenRep.Text = "Generar";
            this.btnGenRep.UseVisualStyleBackColor = true;
            // 
            // dtpFechaReservaI
            // 
            this.dtpFechaReservaI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReservaI.Location = new System.Drawing.Point(174, 25);
            this.dtpFechaReservaI.Name = "dtpFechaReservaI";
            this.dtpFechaReservaI.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaReservaI.TabIndex = 20;
            // 
            // RptReservasObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rptcro);
            this.MaximizeBox = false;
            this.Name = "RptReservasObra";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Cantidad Reservas";
            this.Load += new System.EventHandler(this.RptReservasObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservaObraBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rptcro;
        private System.Windows.Forms.BindingSource reservaObraBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dtpFechaReservaF;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton btnGenRep;
        private System.Windows.Forms.DateTimePicker dtpFechaReservaI;
    }
}