namespace ContactCenterGUI.Teatros.Reservas
{
    partial class ConfirmReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmReservation));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.txtApePat = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNombreEmpresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTelefono = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblTeatro = new MaterialSkin.Controls.MaterialLabel();
            this.lblObra = new MaterialSkin.Controls.MaterialLabel();
            this.lblFuncion = new MaterialSkin.Controls.MaterialLabel();
            this.btnReservar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtCorreo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPrecio = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.txtApeMat = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAplicarDescuento = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cboPromocion = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.cboTipoPromocion = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFecha = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvDetalleAsientos = new System.Windows.Forms.DataGridView();
            this.Zona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.timerConfirmacion = new System.Windows.Forms.Timer(this.components);
            this.btnRegresar = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscarEmpresa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegresar)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(17, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(66, 18);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Depth = 0;
            this.txtNombre.Hint = "";
            this.txtNombre.Location = new System.Drawing.Point(139, 95);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.Size = new System.Drawing.Size(266, 23);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TabStop = false;
            this.txtNombre.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(18, 152);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 18);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Apellido Pat:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(18, 34);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(70, 18);
            this.materialLabel4.TabIndex = 4;
            this.materialLabel4.Text = "Teléfono:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(18, 66);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(55, 18);
            this.materialLabel5.TabIndex = 5;
            this.materialLabel5.Text = "Teatro:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(19, 33);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(45, 18);
            this.materialLabel6.TabIndex = 6;
            this.materialLabel6.Text = "Obra:";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(19, 132);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(65, 18);
            this.materialLabel7.TabIndex = 7;
            this.materialLabel7.Text = "Función:";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(17, 333);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(72, 18);
            this.materialLabel9.TabIndex = 10;
            this.materialLabel9.Text = "Empresa:";
            // 
            // txtApePat
            // 
            this.txtApePat.Depth = 0;
            this.txtApePat.Hint = "";
            this.txtApePat.Location = new System.Drawing.Point(139, 152);
            this.txtApePat.MaxLength = 32767;
            this.txtApePat.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.PasswordChar = '\0';
            this.txtApePat.SelectedText = "";
            this.txtApePat.SelectionLength = 0;
            this.txtApePat.SelectionStart = 0;
            this.txtApePat.Size = new System.Drawing.Size(266, 23);
            this.txtApePat.TabIndex = 3;
            this.txtApePat.TabStop = false;
            this.txtApePat.UseSystemPasswordChar = false;
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Depth = 0;
            this.txtNombreEmpresa.Enabled = false;
            this.txtNombreEmpresa.Hint = "";
            this.txtNombreEmpresa.Location = new System.Drawing.Point(139, 333);
            this.txtNombreEmpresa.MaxLength = 10;
            this.txtNombreEmpresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.PasswordChar = '\0';
            this.txtNombreEmpresa.SelectedText = "";
            this.txtNombreEmpresa.SelectionLength = 0;
            this.txtNombreEmpresa.SelectionStart = 0;
            this.txtNombreEmpresa.Size = new System.Drawing.Size(266, 23);
            this.txtNombreEmpresa.TabIndex = 6;
            this.txtNombreEmpresa.TabStop = false;
            this.txtNombreEmpresa.UseSystemPasswordChar = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Depth = 0;
            this.txtTelefono.Hint = "";
            this.txtTelefono.Location = new System.Drawing.Point(139, 30);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.SelectionLength = 0;
            this.txtTelefono.SelectionStart = 0;
            this.txtTelefono.Size = new System.Drawing.Size(266, 23);
            this.txtTelefono.TabIndex = 1;
            this.txtTelefono.TabStop = false;
            this.txtTelefono.UseSystemPasswordChar = false;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblTeatro
            // 
            this.lblTeatro.AutoSize = true;
            this.lblTeatro.BackColor = System.Drawing.Color.Transparent;
            this.lblTeatro.Depth = 0;
            this.lblTeatro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTeatro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTeatro.Location = new System.Drawing.Point(126, 66);
            this.lblTeatro.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTeatro.Name = "lblTeatro";
            this.lblTeatro.Size = new System.Drawing.Size(125, 18);
            this.lblTeatro.TabIndex = 16;
            this.lblTeatro.Text = "Peruano Japonés";
            // 
            // lblObra
            // 
            this.lblObra.AutoSize = true;
            this.lblObra.BackColor = System.Drawing.Color.Transparent;
            this.lblObra.Depth = 0;
            this.lblObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblObra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblObra.Location = new System.Drawing.Point(127, 33);
            this.lblObra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblObra.Name = "lblObra";
            this.lblObra.Size = new System.Drawing.Size(54, 18);
            this.lblObra.TabIndex = 17;
            this.lblObra.Text = "Obra A";
            // 
            // lblFuncion
            // 
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.BackColor = System.Drawing.Color.Transparent;
            this.lblFuncion.Depth = 0;
            this.lblFuncion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblFuncion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFuncion.Location = new System.Drawing.Point(127, 132);
            this.lblFuncion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(119, 18);
            this.lblFuncion.TabIndex = 18;
            this.lblFuncion.Text = "5:00pm - 7:00pm";
            // 
            // btnReservar
            // 
            this.btnReservar.Depth = 0;
            this.btnReservar.Location = new System.Drawing.Point(277, 417);
            this.btnReservar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Primary = true;
            this.btnReservar.Size = new System.Drawing.Size(168, 40);
            this.btnReservar.TabIndex = 7;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Depth = 0;
            this.txtCorreo.Hint = "";
            this.txtCorreo.Location = new System.Drawing.Point(139, 275);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.Size = new System.Drawing.Size(266, 23);
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.TabStop = false;
            this.txtCorreo.UseSystemPasswordChar = false;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(18, 279);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(59, 18);
            this.materialLabel13.TabIndex = 22;
            this.materialLabel13.Text = "Correo:";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(19, 201);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(69, 18);
            this.materialLabel15.TabIndex = 23;
            this.materialLabel15.Text = "Asientos:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Depth = 0;
            this.lblPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPrecio.Location = new System.Drawing.Point(127, 169);
            this.lblPrecio.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(54, 18);
            this.lblPrecio.TabIndex = 26;
            this.lblPrecio.Text = "Obra A";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(19, 169);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(55, 18);
            this.materialLabel11.TabIndex = 25;
            this.materialLabel11.Text = "Precio:";
            // 
            // txtApeMat
            // 
            this.txtApeMat.Depth = 0;
            this.txtApeMat.Hint = "";
            this.txtApeMat.Location = new System.Drawing.Point(139, 217);
            this.txtApeMat.MaxLength = 32767;
            this.txtApeMat.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.PasswordChar = '\0';
            this.txtApeMat.SelectedText = "";
            this.txtApeMat.SelectionLength = 0;
            this.txtApeMat.SelectionStart = 0;
            this.txtApeMat.Size = new System.Drawing.Size(266, 23);
            this.txtApeMat.TabIndex = 4;
            this.txtApeMat.TabStop = false;
            this.txtApeMat.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(17, 217);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(92, 18);
            this.materialLabel8.TabIndex = 27;
            this.materialLabel8.Text = "Apellido Mat:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnBuscarEmpresa);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtApeMat);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.materialLabel8);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.materialLabel9);
            this.groupBox1.Controls.Add(this.materialLabel13);
            this.groupBox1.Controls.Add(this.txtApePat);
            this.groupBox1.Controls.Add(this.txtNombreEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 482);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Cliente";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAplicarDescuento);
            this.groupBox3.Controls.Add(this.materialLabel3);
            this.groupBox3.Controls.Add(this.cboPromocion);
            this.groupBox3.Controls.Add(this.materialLabel10);
            this.groupBox3.Controls.Add(this.cboTipoPromocion);
            this.groupBox3.Location = new System.Drawing.Point(6, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 114);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Promoción";
            // 
            // btnAplicarDescuento
            // 
            this.btnAplicarDescuento.Depth = 0;
            this.btnAplicarDescuento.Location = new System.Drawing.Point(436, 56);
            this.btnAplicarDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAplicarDescuento.Name = "btnAplicarDescuento";
            this.btnAplicarDescuento.Primary = true;
            this.btnAplicarDescuento.Size = new System.Drawing.Size(168, 40);
            this.btnAplicarDescuento.TabIndex = 36;
            this.btnAplicarDescuento.Text = "Aplicar";
            this.btnAplicarDescuento.UseVisualStyleBackColor = true;
            this.btnAplicarDescuento.Click += new System.EventHandler(this.btnAplicarDescuento_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(13, 77);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(57, 18);
            this.materialLabel3.TabIndex = 35;
            this.materialLabel3.Text = "Detalle:";
            // 
            // cboPromocion
            // 
            this.cboPromocion.FormattingEnabled = true;
            this.cboPromocion.ItemHeight = 23;
            this.cboPromocion.Location = new System.Drawing.Point(140, 67);
            this.cboPromocion.Name = "cboPromocion";
            this.cboPromocion.Size = new System.Drawing.Size(266, 29);
            this.cboPromocion.TabIndex = 34;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(13, 28);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(119, 18);
            this.materialLabel10.TabIndex = 33;
            this.materialLabel10.Text = "Tipo Promoción:";
            // 
            // cboTipoPromocion
            // 
            this.cboTipoPromocion.FormattingEnabled = true;
            this.cboTipoPromocion.ItemHeight = 23;
            this.cboTipoPromocion.Location = new System.Drawing.Point(140, 18);
            this.cboTipoPromocion.Name = "cboTipoPromocion";
            this.cboTipoPromocion.Size = new System.Drawing.Size(266, 29);
            this.cboTipoPromocion.TabIndex = 32;
            this.cboTipoPromocion.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPromocion_SelectionChangeCommitted_1);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblFecha);
            this.groupBox2.Controls.Add(this.materialLabel12);
            this.groupBox2.Controls.Add(this.dgvDetalleAsientos);
            this.groupBox2.Controls.Add(this.materialLabel6);
            this.groupBox2.Controls.Add(this.btnReservar);
            this.groupBox2.Controls.Add(this.lblObra);
            this.groupBox2.Controls.Add(this.lblTeatro);
            this.groupBox2.Controls.Add(this.materialLabel5);
            this.groupBox2.Controls.Add(this.lblPrecio);
            this.groupBox2.Controls.Add(this.materialLabel11);
            this.groupBox2.Controls.Add(this.materialLabel7);
            this.groupBox2.Controls.Add(this.materialLabel15);
            this.groupBox2.Controls.Add(this.lblFuncion);
            this.groupBox2.Location = new System.Drawing.Point(640, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 481);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Depth = 0;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFecha.Location = new System.Drawing.Point(127, 98);
            this.lblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(108, 18);
            this.lblFecha.TabIndex = 30;
            this.lblFecha.Text = "Fecha Reserva";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(18, 98);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(53, 18);
            this.materialLabel12.TabIndex = 29;
            this.materialLabel12.Text = "Fecha:";
            // 
            // dgvDetalleAsientos
            // 
            this.dgvDetalleAsientos.AllowUserToAddRows = false;
            this.dgvDetalleAsientos.AllowUserToDeleteRows = false;
            this.dgvDetalleAsientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleAsientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleAsientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Zona,
            this.Fila,
            this.Asiento});
            this.dgvDetalleAsientos.Location = new System.Drawing.Point(131, 201);
            this.dgvDetalleAsientos.Name = "dgvDetalleAsientos";
            this.dgvDetalleAsientos.ReadOnly = true;
            this.dgvDetalleAsientos.RowHeadersVisible = false;
            this.dgvDetalleAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleAsientos.Size = new System.Drawing.Size(314, 212);
            this.dgvDetalleAsientos.TabIndex = 28;
            // 
            // Zona
            // 
            this.Zona.HeaderText = "Zona";
            this.Zona.Name = "Zona";
            this.Zona.ReadOnly = true;
            this.Zona.Width = 205;
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            this.Fila.Width = 45;
            // 
            // Asiento
            // 
            this.Asiento.HeaderText = "Asiento";
            this.Asiento.Name = "Asiento";
            this.Asiento.ReadOnly = true;
            this.Asiento.Width = 50;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.White;
            this.lblTiempo.Location = new System.Drawing.Point(533, 32);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(0, 20);
            this.lblTiempo.TabIndex = 1914;
            // 
            // timerConfirmacion
            // 
            this.timerConfirmacion.Tick += new System.EventHandler(this.timerConfirmacion_Tick);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.btnRegresar.Location = new System.Drawing.Point(1099, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(16, 18);
            this.btnRegresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRegresar.TabIndex = 1918;
            this.btnRegresar.TabStop = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::ContactCenterGUI.Properties.Resources.eliminar;
            this.button1.Location = new System.Drawing.Point(441, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscarEmpresa
            // 
            this.btnBuscarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarEmpresa.Image = global::ContactCenterGUI.Properties.Resources.lup1a;
            this.btnBuscarEmpresa.Location = new System.Drawing.Point(411, 333);
            this.btnBuscarEmpresa.Name = "btnBuscarEmpresa";
            this.btnBuscarEmpresa.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarEmpresa.TabIndex = 29;
            this.btnBuscarEmpresa.UseVisualStyleBackColor = false;
            this.btnBuscarEmpresa.Click += new System.EventHandler(this.btnBuscarEmpresa_Click);
            // 
            // ConfirmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 607);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfirmReservation";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PerInfoTheater_FormClosing);
            this.Load += new System.EventHandler(this.PerInfoTheater_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegresar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombre;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtApePat;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreEmpresa;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTelefono;
        private MaterialSkin.Controls.MaterialLabel lblTeatro;
        private MaterialSkin.Controls.MaterialLabel lblObra;
        private MaterialSkin.Controls.MaterialLabel lblFuncion;
        private MaterialSkin.Controls.MaterialRaisedButton btnReservar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreo;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel lblPrecio;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtApeMat;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetalleAsientos;
        private MaterialSkin.Controls.MaterialLabel lblFecha;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Timer timerConfirmacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialRaisedButton btnAplicarDescuento;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MetroFramework.Controls.MetroComboBox cboPromocion;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MetroFramework.Controls.MetroComboBox cboTipoPromocion;
        private System.Windows.Forms.PictureBox btnRegresar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asiento;
        private System.Windows.Forms.Button btnBuscarEmpresa;
        private System.Windows.Forms.Button button1;
    }
}