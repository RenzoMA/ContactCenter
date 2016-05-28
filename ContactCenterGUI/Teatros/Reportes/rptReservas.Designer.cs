namespace ContactCenterGUI.Teatros.Reportes
{
    partial class RptReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptReservas));
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpFechaObra = new System.Windows.Forms.DateTimePicker();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblTituloTeatro = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(77, 100);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(170, 29);
            this.metroComboBox1.TabIndex = 4;
            // 
            // cboTeatro
            // 
            this.cboTeatro.FontSize = MetroFramework.MetroLinkSize.Small;
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 19;
            this.cboTeatro.Location = new System.Drawing.Point(119, 80);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(170, 25);
            this.cboTeatro.TabIndex = 5;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ContactCenterGUI.Teatros.Reportes.rptReservas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 151);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1252, 487);
            this.reportViewer1.TabIndex = 6;
            // 
            // dtpFechaObra
            // 
            this.dtpFechaObra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaObra.Location = new System.Drawing.Point(119, 111);
            this.dtpFechaObra.Name = "dtpFechaObra";
            this.dtpFechaObra.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaObra.TabIndex = 7;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(325, 84);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(168, 40);
            this.materialRaisedButton1.TabIndex = 10;
            this.materialRaisedButton1.Text = "Generar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // lblTituloTeatro
            // 
            this.lblTituloTeatro.AutoSize = true;
            this.lblTituloTeatro.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloTeatro.Depth = 0;
            this.lblTituloTeatro.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTituloTeatro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTituloTeatro.Location = new System.Drawing.Point(37, 84);
            this.lblTituloTeatro.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTituloTeatro.Name = "lblTituloTeatro";
            this.lblTituloTeatro.Size = new System.Drawing.Size(57, 19);
            this.lblTituloTeatro.TabIndex = 11;
            this.lblTituloTeatro.Text = "Teatro:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(37, 111);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(53, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Fecha:";
            // 
            // RptReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 650);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lblTituloTeatro);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.dtpFechaObra);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cboTeatro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RptReservas";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de reservas";
            this.Load += new System.EventHandler(this.rptReservas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpFechaObra;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialLabel lblTituloTeatro;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}