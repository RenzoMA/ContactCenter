namespace ContactCenterGUI.Teatros.Reservas
{
    partial class FindEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindEmpresa));
            this.lstEmpresas = new System.Windows.Forms.ListBox();
            this.btnAplicarDescuento = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtNombreEmpresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.FormattingEnabled = true;
            this.lstEmpresas.Location = new System.Drawing.Point(12, 113);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.Size = new System.Drawing.Size(415, 147);
            this.lstEmpresas.TabIndex = 0;
            // 
            // btnAplicarDescuento
            // 
            this.btnAplicarDescuento.Depth = 0;
            this.btnAplicarDescuento.Location = new System.Drawing.Point(12, 271);
            this.btnAplicarDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAplicarDescuento.Name = "btnAplicarDescuento";
            this.btnAplicarDescuento.Primary = true;
            this.btnAplicarDescuento.Size = new System.Drawing.Size(168, 40);
            this.btnAplicarDescuento.TabIndex = 37;
            this.btnAplicarDescuento.Text = "Seleccionar";
            this.btnAplicarDescuento.UseVisualStyleBackColor = true;
            this.btnAplicarDescuento.Click += new System.EventHandler(this.btnAplicarDescuento_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(259, 271);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(168, 40);
            this.materialRaisedButton1.TabIndex = 38;
            this.materialRaisedButton1.Text = "Cancelar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Depth = 0;
            this.txtNombreEmpresa.Hint = "";
            this.txtNombreEmpresa.Location = new System.Drawing.Point(12, 84);
            this.txtNombreEmpresa.MaxLength = 20;
            this.txtNombreEmpresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.PasswordChar = '\0';
            this.txtNombreEmpresa.SelectedText = "";
            this.txtNombreEmpresa.SelectionLength = 0;
            this.txtNombreEmpresa.SelectionStart = 0;
            this.txtNombreEmpresa.Size = new System.Drawing.Size(289, 23);
            this.txtNombreEmpresa.TabIndex = 39;
            this.txtNombreEmpresa.TabStop = false;
            this.txtNombreEmpresa.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(321, 80);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(106, 27);
            this.materialRaisedButton2.TabIndex = 40;
            this.materialRaisedButton2.Text = "Buscar";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // FindEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 327);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btnAplicarDescuento);
            this.Controls.Add(this.lstEmpresas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FindEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Empresa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstEmpresas;
        private MaterialSkin.Controls.MaterialRaisedButton btnAplicarDescuento;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreEmpresa;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}