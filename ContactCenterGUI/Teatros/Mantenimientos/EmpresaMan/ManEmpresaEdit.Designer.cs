namespace ContactCenterGUI.Teatros.Mantenimientos.EmpresaMan
{
    partial class ManEmpresaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManEmpresaEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtCortesias = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.chkCortesia = new System.Windows.Forms.CheckBox();
            this.btnEditar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombreEmpresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.txtCortesias);
            this.groupBox1.Controls.Add(this.chkCortesia);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.txtNombreEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 232);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 103);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(60, 19);
            this.materialLabel1.TabIndex = 32;
            this.materialLabel1.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cboEstado.Location = new System.Drawing.Point(142, 104);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(183, 21);
            this.cboEstado.TabIndex = 31;
            // 
            // txtCortesias
            // 
            this.txtCortesias.Depth = 0;
            this.txtCortesias.Hint = "";
            this.txtCortesias.Location = new System.Drawing.Point(142, 64);
            this.txtCortesias.MaxLength = 40;
            this.txtCortesias.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCortesias.Name = "txtCortesias";
            this.txtCortesias.PasswordChar = '\0';
            this.txtCortesias.SelectedText = "";
            this.txtCortesias.SelectionLength = 0;
            this.txtCortesias.SelectionStart = 0;
            this.txtCortesias.Size = new System.Drawing.Size(74, 23);
            this.txtCortesias.TabIndex = 30;
            this.txtCortesias.TabStop = false;
            this.txtCortesias.UseSystemPasswordChar = false;
            this.txtCortesias.Visible = false;
            // 
            // chkCortesia
            // 
            this.chkCortesia.AutoSize = true;
            this.chkCortesia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCortesia.Location = new System.Drawing.Point(39, 66);
            this.chkCortesia.Name = "chkCortesia";
            this.chkCortesia.Size = new System.Drawing.Size(94, 21);
            this.chkCortesia.TabIndex = 29;
            this.chkCortesia.Text = "Cortesias:";
            this.chkCortesia.UseVisualStyleBackColor = true;
            this.chkCortesia.CheckedChanged += new System.EventHandler(this.chkCortesia_CheckedChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Depth = 0;
            this.btnEditar.Location = new System.Drawing.Point(157, 175);
            this.btnEditar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Primary = true;
            this.btnEditar.Size = new System.Drawing.Size(168, 40);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(35, 35);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(67, 19);
            this.materialLabel3.TabIndex = 19;
            this.materialLabel3.Text = "Nombre:";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Depth = 0;
            this.txtNombreEmpresa.Hint = "";
            this.txtNombreEmpresa.Location = new System.Drawing.Point(142, 31);
            this.txtNombreEmpresa.MaxLength = 40;
            this.txtNombreEmpresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.PasswordChar = '\0';
            this.txtNombreEmpresa.SelectedText = "";
            this.txtNombreEmpresa.SelectionLength = 0;
            this.txtNombreEmpresa.SelectionStart = 0;
            this.txtNombreEmpresa.Size = new System.Drawing.Size(243, 23);
            this.txtNombreEmpresa.TabIndex = 3;
            this.txtNombreEmpresa.TabStop = false;
            this.txtNombreEmpresa.UseSystemPasswordChar = false;
            // 
            // ManEmpresaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 340);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManEmpresaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Empresa";
            this.Load += new System.EventHandler(this.ManEmpresaEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCortesias;
        private System.Windows.Forms.CheckBox chkCortesia;
        private MaterialSkin.Controls.MaterialRaisedButton btnEditar;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreEmpresa;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox cboEstado;
    }
}