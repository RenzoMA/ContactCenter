namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    partial class ManAplicacionEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManAplicacionEditar));
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtAplicacion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCorreo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCorreoNotificacion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPasswordCorreo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(286, 402);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(168, 40);
            this.materialRaisedButton1.TabIndex = 10;
            this.materialRaisedButton1.Text = "Editar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // txtAplicacion
            // 
            this.txtAplicacion.BackColor = System.Drawing.Color.White;
            this.txtAplicacion.Depth = 0;
            this.txtAplicacion.Hint = "";
            this.txtAplicacion.Location = new System.Drawing.Point(164, 88);
            this.txtAplicacion.MaxLength = 32767;
            this.txtAplicacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAplicacion.Name = "txtAplicacion";
            this.txtAplicacion.PasswordChar = '\0';
            this.txtAplicacion.SelectedText = "";
            this.txtAplicacion.SelectionLength = 0;
            this.txtAplicacion.SelectionStart = 0;
            this.txtAplicacion.Size = new System.Drawing.Size(235, 23);
            this.txtAplicacion.TabIndex = 56;
            this.txtAplicacion.TabStop = false;
            this.txtAplicacion.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(17, 88);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(84, 19);
            this.materialLabel1.TabIndex = 57;
            this.materialLabel1.Text = "Aplicacion:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.Depth = 0;
            this.txtCorreo.Hint = "";
            this.txtCorreo.Location = new System.Drawing.Point(164, 122);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.Size = new System.Drawing.Size(235, 23);
            this.txtCorreo.TabIndex = 58;
            this.txtCorreo.TabStop = false;
            this.txtCorreo.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(17, 122);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(59, 19);
            this.materialLabel2.TabIndex = 59;
            this.materialLabel2.Text = "Correo:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(17, 216);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(62, 19);
            this.materialLabel3.TabIndex = 60;
            this.materialLabel3.Text = "Imagen:";
            // 
            // pcbImagen
            // 
            this.pcbImagen.Location = new System.Drawing.Point(164, 216);
            this.pcbImagen.Name = "pcbImagen";
            this.pcbImagen.Size = new System.Drawing.Size(235, 151);
            this.pcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagen.TabIndex = 61;
            this.pcbImagen.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(374, 373);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(25, 23);
            this.btnCargarImagen.TabIndex = 62;
            this.btnCargarImagen.Text = "...";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(393, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtCorreoNotificacion
            // 
            this.txtCorreoNotificacion.BackColor = System.Drawing.Color.White;
            this.txtCorreoNotificacion.Depth = 0;
            this.txtCorreoNotificacion.Hint = "";
            this.txtCorreoNotificacion.Location = new System.Drawing.Point(164, 151);
            this.txtCorreoNotificacion.MaxLength = 32767;
            this.txtCorreoNotificacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreoNotificacion.Name = "txtCorreoNotificacion";
            this.txtCorreoNotificacion.PasswordChar = '\0';
            this.txtCorreoNotificacion.SelectedText = "";
            this.txtCorreoNotificacion.SelectionLength = 0;
            this.txtCorreoNotificacion.SelectionStart = 0;
            this.txtCorreoNotificacion.Size = new System.Drawing.Size(235, 23);
            this.txtCorreoNotificacion.TabIndex = 64;
            this.txtCorreoNotificacion.TabStop = false;
            this.txtCorreoNotificacion.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(17, 151);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(146, 19);
            this.materialLabel4.TabIndex = 65;
            this.materialLabel4.Text = "Correo Notificacion:";
            // 
            // txtPasswordCorreo
            // 
            this.txtPasswordCorreo.BackColor = System.Drawing.Color.White;
            this.txtPasswordCorreo.Depth = 0;
            this.txtPasswordCorreo.Hint = "";
            this.txtPasswordCorreo.Location = new System.Drawing.Point(164, 180);
            this.txtPasswordCorreo.MaxLength = 32767;
            this.txtPasswordCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPasswordCorreo.Name = "txtPasswordCorreo";
            this.txtPasswordCorreo.PasswordChar = '\0';
            this.txtPasswordCorreo.SelectedText = "";
            this.txtPasswordCorreo.SelectionLength = 0;
            this.txtPasswordCorreo.SelectionStart = 0;
            this.txtPasswordCorreo.Size = new System.Drawing.Size(235, 23);
            this.txtPasswordCorreo.TabIndex = 66;
            this.txtPasswordCorreo.TabStop = false;
            this.txtPasswordCorreo.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(17, 180);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(129, 19);
            this.materialLabel5.TabIndex = 67;
            this.materialLabel5.Text = "Password Correo:";
            // 
            // ManAplicacionEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 459);
            this.Controls.Add(this.txtPasswordCorreo);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txtCorreoNotificacion);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.pcbImagen);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtAplicacion);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManAplicacionEditar";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar aplicación";
            this.Load += new System.EventHandler(this.ManAplicacionEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAplicacion;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.PictureBox pcbImagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreoNotificacion;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPasswordCorreo;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}