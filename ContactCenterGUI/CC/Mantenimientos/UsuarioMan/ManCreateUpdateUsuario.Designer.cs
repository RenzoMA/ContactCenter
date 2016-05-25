namespace ContactCenterGUI.CC.Mantenimientos.UsuarioMan
{
    partial class ManCreateUpdateUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManCreateUpdateUsuario));
            this.txtNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtApePaterno = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtApeMaterno = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtContraseña = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblContraseña = new MaterialSkin.Controls.MaterialLabel();
            this.txtRepiteContraseña = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblRepiteContraseña = new MaterialSkin.Controls.MaterialLabel();
            this.btnCreaUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtCorreo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.lstAplicaciones = new System.Windows.Forms.ListBox();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.PictureBox();
            this.lblRol = new MaterialSkin.Controls.MaterialLabel();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new MaterialSkin.Controls.MaterialLabel();
            this.txtLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblLogin = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Depth = 0;
            this.txtNombre.Hint = "";
            this.txtNombre.Location = new System.Drawing.Point(162, 96);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.Size = new System.Drawing.Size(235, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TabStop = false;
            this.txtNombre.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(16, 96);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(67, 19);
            this.materialLabel1.TabIndex = 7;
            this.materialLabel1.Text = "Nombre:";
            // 
            // txtApePaterno
            // 
            this.txtApePaterno.BackColor = System.Drawing.Color.White;
            this.txtApePaterno.Depth = 0;
            this.txtApePaterno.Hint = "";
            this.txtApePaterno.Location = new System.Drawing.Point(162, 135);
            this.txtApePaterno.MaxLength = 32767;
            this.txtApePaterno.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApePaterno.Name = "txtApePaterno";
            this.txtApePaterno.PasswordChar = '\0';
            this.txtApePaterno.SelectedText = "";
            this.txtApePaterno.SelectionLength = 0;
            this.txtApePaterno.SelectionStart = 0;
            this.txtApePaterno.Size = new System.Drawing.Size(235, 23);
            this.txtApePaterno.TabIndex = 2;
            this.txtApePaterno.TabStop = false;
            this.txtApePaterno.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(16, 135);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(124, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Apellido Paterno:";
            // 
            // txtApeMaterno
            // 
            this.txtApeMaterno.BackColor = System.Drawing.Color.White;
            this.txtApeMaterno.Depth = 0;
            this.txtApeMaterno.Hint = "";
            this.txtApeMaterno.Location = new System.Drawing.Point(162, 174);
            this.txtApeMaterno.MaxLength = 32767;
            this.txtApeMaterno.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApeMaterno.Name = "txtApeMaterno";
            this.txtApeMaterno.PasswordChar = '\0';
            this.txtApeMaterno.SelectedText = "";
            this.txtApeMaterno.SelectionLength = 0;
            this.txtApeMaterno.SelectionStart = 0;
            this.txtApeMaterno.Size = new System.Drawing.Size(235, 23);
            this.txtApeMaterno.TabIndex = 3;
            this.txtApeMaterno.TabStop = false;
            this.txtApeMaterno.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(16, 174);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(128, 19);
            this.materialLabel3.TabIndex = 11;
            this.materialLabel3.Text = "Apellido Materno:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.Depth = 0;
            this.txtContraseña.Hint = "";
            this.txtContraseña.Location = new System.Drawing.Point(161, 327);
            this.txtContraseña.MaxLength = 32767;
            this.txtContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.SelectedText = "";
            this.txtContraseña.SelectionLength = 0;
            this.txtContraseña.SelectionStart = 0;
            this.txtContraseña.Size = new System.Drawing.Size(235, 23);
            this.txtContraseña.TabIndex = 7;
            this.txtContraseña.TabStop = false;
            this.txtContraseña.UseSystemPasswordChar = false;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.BackColor = System.Drawing.Color.Transparent;
            this.lblContraseña.Depth = 0;
            this.lblContraseña.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblContraseña.Location = new System.Drawing.Point(15, 327);
            this.lblContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(90, 19);
            this.lblContraseña.TabIndex = 15;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // txtRepiteContraseña
            // 
            this.txtRepiteContraseña.BackColor = System.Drawing.Color.White;
            this.txtRepiteContraseña.Depth = 0;
            this.txtRepiteContraseña.Hint = "";
            this.txtRepiteContraseña.Location = new System.Drawing.Point(161, 366);
            this.txtRepiteContraseña.MaxLength = 32767;
            this.txtRepiteContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRepiteContraseña.Name = "txtRepiteContraseña";
            this.txtRepiteContraseña.PasswordChar = '*';
            this.txtRepiteContraseña.SelectedText = "";
            this.txtRepiteContraseña.SelectionLength = 0;
            this.txtRepiteContraseña.SelectionStart = 0;
            this.txtRepiteContraseña.Size = new System.Drawing.Size(235, 23);
            this.txtRepiteContraseña.TabIndex = 8;
            this.txtRepiteContraseña.TabStop = false;
            this.txtRepiteContraseña.UseSystemPasswordChar = false;
            // 
            // lblRepiteContraseña
            // 
            this.lblRepiteContraseña.AutoSize = true;
            this.lblRepiteContraseña.BackColor = System.Drawing.Color.Transparent;
            this.lblRepiteContraseña.Depth = 0;
            this.lblRepiteContraseña.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRepiteContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRepiteContraseña.Location = new System.Drawing.Point(15, 366);
            this.lblRepiteContraseña.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRepiteContraseña.Name = "lblRepiteContraseña";
            this.lblRepiteContraseña.Size = new System.Drawing.Size(141, 19);
            this.lblRepiteContraseña.TabIndex = 17;
            this.lblRepiteContraseña.Text = "Repetir Contraseña:";
            // 
            // btnCreaUpdate
            // 
            this.btnCreaUpdate.Depth = 0;
            this.btnCreaUpdate.Location = new System.Drawing.Point(161, 655);
            this.btnCreaUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreaUpdate.Name = "btnCreaUpdate";
            this.btnCreaUpdate.Primary = true;
            this.btnCreaUpdate.Size = new System.Drawing.Size(101, 32);
            this.btnCreaUpdate.TabIndex = 19;
            this.btnCreaUpdate.UseVisualStyleBackColor = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.Depth = 0;
            this.txtCorreo.Hint = "";
            this.txtCorreo.Location = new System.Drawing.Point(162, 213);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.Size = new System.Drawing.Size(235, 23);
            this.txtCorreo.TabIndex = 4;
            this.txtCorreo.TabStop = false;
            this.txtCorreo.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(16, 213);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(59, 19);
            this.materialLabel7.TabIndex = 20;
            this.materialLabel7.Text = "Correo:";
            // 
            // lstAplicaciones
            // 
            this.lstAplicaciones.FormattingEnabled = true;
            this.lstAplicaciones.Location = new System.Drawing.Point(14, 479);
            this.lstAplicaciones.Name = "lstAplicaciones";
            this.lstAplicaciones.Size = new System.Drawing.Size(164, 134);
            this.lstAplicaciones.TabIndex = 26;
            // 
            // lstPermisos
            // 
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(263, 479);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.Size = new System.Drawing.Size(164, 134);
            this.lstPermisos.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Aplicaciones sistema:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Acceso al usuario:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Image = global::ContactCenterGUI.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(207, 517);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 30;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregar.Image = global::ContactCenterGUI.Properties.Resources.ic_menu_add;
            this.btnAgregar.Location = new System.Drawing.Point(204, 479);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(31, 31);
            this.btnAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAgregar.TabIndex = 25;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.Transparent;
            this.lblRol.Depth = 0;
            this.lblRol.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRol.Location = new System.Drawing.Point(15, 251);
            this.lblRol.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(35, 19);
            this.lblRol.TabIndex = 31;
            this.lblRol.Text = "Rol:";
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(162, 252);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(235, 21);
            this.cboRol.TabIndex = 5;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(19, 69);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 32;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstado.Location = new System.Drawing.Point(162, 289);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(235, 21);
            this.cboEstado.TabIndex = 33;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Depth = 0;
            this.lblEstado.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstado.Location = new System.Drawing.Point(15, 288);
            this.lblEstado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 19);
            this.lblEstado.TabIndex = 34;
            this.lblEstado.Text = "Estado:";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.White;
            this.txtLogin.Depth = 0;
            this.txtLogin.Hint = "";
            this.txtLogin.Location = new System.Drawing.Point(161, 405);
            this.txtLogin.MaxLength = 32767;
            this.txtLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.PasswordChar = '\0';
            this.txtLogin.SelectedText = "";
            this.txtLogin.SelectionLength = 0;
            this.txtLogin.SelectionStart = 0;
            this.txtLogin.Size = new System.Drawing.Size(235, 23);
            this.txtLogin.TabIndex = 35;
            this.txtLogin.TabStop = false;
            this.txtLogin.UseSystemPasswordChar = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Depth = 0;
            this.lblLogin.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLogin.Location = new System.Drawing.Point(15, 405);
            this.lblLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(50, 19);
            this.lblLogin.TabIndex = 36;
            this.lblLogin.Text = "Login:";
            // 
            // ManCreateUpdateUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 706);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPermisos);
            this.Controls.Add(this.lstAplicaciones);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.btnCreaUpdate);
            this.Controls.Add(this.txtRepiteContraseña);
            this.Controls.Add(this.lblRepiteContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txtApeMaterno);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtApePaterno);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManCreateUpdateUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManCreateUpdateUsuario";
            this.Load += new System.EventHandler(this.ManCreateUpdateUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombre;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtApePaterno;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtApeMaterno;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtContraseña;
        private MaterialSkin.Controls.MaterialLabel lblContraseña;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRepiteContraseña;
        private MaterialSkin.Controls.MaterialLabel lblRepiteContraseña;
        private MaterialSkin.Controls.MaterialRaisedButton btnCreaUpdate;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreo;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.PictureBox btnAgregar;
        private System.Windows.Forms.ListBox lstAplicaciones;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnDelete;
        private MaterialSkin.Controls.MaterialLabel lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ComboBox cboEstado;
        private MaterialSkin.Controls.MaterialLabel lblEstado;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtLogin;
        private MaterialSkin.Controls.MaterialLabel lblLogin;
    }
}