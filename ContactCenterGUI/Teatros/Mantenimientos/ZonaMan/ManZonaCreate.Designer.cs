namespace ContactCenterGUI.Teatros.Mantenimientos.ZonaMan
{
    partial class ManZonaCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManZonaCreate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPrecioZona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnElegirColor = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDisplayColor = new System.Windows.Forms.TextBox();
            this.txtDescripcionZona = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCrear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombreZona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.txtPrecioZona);
            this.groupBox1.Controls.Add(this.btnElegirColor);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.txtDisplayColor);
            this.groupBox1.Controls.Add(this.txtDescripcionZona);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.txtNombreZona);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.cboTeatro);
            this.groupBox1.Controls.Add(this.cboObra);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 374);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.White;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(35, 161);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(89, 19);
            this.materialLabel6.TabIndex = 28;
            this.materialLabel6.Text = "Precio (S/.):";
            // 
            // txtPrecioZona
            // 
            this.txtPrecioZona.Depth = 0;
            this.txtPrecioZona.Hint = "";
            this.txtPrecioZona.Location = new System.Drawing.Point(142, 157);
            this.txtPrecioZona.MaxLength = 40;
            this.txtPrecioZona.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioZona.Name = "txtPrecioZona";
            this.txtPrecioZona.PasswordChar = '\0';
            this.txtPrecioZona.SelectedText = "";
            this.txtPrecioZona.SelectionLength = 0;
            this.txtPrecioZona.SelectionStart = 0;
            this.txtPrecioZona.Size = new System.Drawing.Size(243, 23);
            this.txtPrecioZona.TabIndex = 4;
            this.txtPrecioZona.TabStop = false;
            this.txtPrecioZona.UseSystemPasswordChar = false;
            // 
            // btnElegirColor
            // 
            this.btnElegirColor.Depth = 0;
            this.btnElegirColor.Location = new System.Drawing.Point(248, 201);
            this.btnElegirColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnElegirColor.Name = "btnElegirColor";
            this.btnElegirColor.Primary = true;
            this.btnElegirColor.Size = new System.Drawing.Size(33, 20);
            this.btnElegirColor.TabIndex = 5;
            this.btnElegirColor.Text = "...";
            this.btnElegirColor.UseVisualStyleBackColor = true;
            this.btnElegirColor.Click += new System.EventHandler(this.btnElegirColor_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(35, 202);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(50, 19);
            this.materialLabel2.TabIndex = 25;
            this.materialLabel2.Text = "Color:";
            // 
            // txtDisplayColor
            // 
            this.txtDisplayColor.Location = new System.Drawing.Point(142, 201);
            this.txtDisplayColor.Name = "txtDisplayColor";
            this.txtDisplayColor.ReadOnly = true;
            this.txtDisplayColor.Size = new System.Drawing.Size(100, 20);
            this.txtDisplayColor.TabIndex = 24;
            // 
            // txtDescripcionZona
            // 
            this.txtDescripcionZona.Location = new System.Drawing.Point(142, 238);
            this.txtDescripcionZona.Multiline = true;
            this.txtDescripcionZona.Name = "txtDescripcionZona";
            this.txtDescripcionZona.Size = new System.Drawing.Size(243, 57);
            this.txtDescripcionZona.TabIndex = 6;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.White;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(35, 237);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(93, 19);
            this.materialLabel5.TabIndex = 22;
            this.materialLabel5.Text = "Descripcion:";
            // 
            // btnCrear
            // 
            this.btnCrear.Depth = 0;
            this.btnCrear.Location = new System.Drawing.Point(294, 313);
            this.btnCrear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Primary = true;
            this.btnCrear.Size = new System.Drawing.Size(168, 40);
            this.btnCrear.TabIndex = 7;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(35, 123);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(67, 19);
            this.materialLabel3.TabIndex = 19;
            this.materialLabel3.Text = "Nombre:";
            // 
            // txtNombreZona
            // 
            this.txtNombreZona.Depth = 0;
            this.txtNombreZona.Hint = "";
            this.txtNombreZona.Location = new System.Drawing.Point(142, 119);
            this.txtNombreZona.MaxLength = 40;
            this.txtNombreZona.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreZona.Name = "txtNombreZona";
            this.txtNombreZona.PasswordChar = '\0';
            this.txtNombreZona.SelectedText = "";
            this.txtNombreZona.SelectionLength = 0;
            this.txtNombreZona.SelectionStart = 0;
            this.txtNombreZona.Size = new System.Drawing.Size(243, 23);
            this.txtNombreZona.TabIndex = 3;
            this.txtNombreZona.TabStop = false;
            this.txtNombreZona.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(35, 36);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(57, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Teatro:";
            // 
            // cboTeatro
            // 
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 23;
            this.cboTeatro.Location = new System.Drawing.Point(142, 26);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(243, 29);
            this.cboTeatro.TabIndex = 1;
            this.cboTeatro.SelectionChangeCommitted += new System.EventHandler(this.cboTeatro_SelectionChangeCommitted);
            // 
            // cboObra
            // 
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 23;
            this.cboObra.Location = new System.Drawing.Point(142, 75);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(243, 29);
            this.cboObra.TabIndex = 2;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(35, 85);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(44, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Obra:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.pictureBox1.Image = global::ContactCenterGUI.Properties.Resources.left_arrow12;
            this.pictureBox1.Location = new System.Drawing.Point(443, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ManZonaCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 468);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManZonaCreate";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Zonas";
            this.Load += new System.EventHandler(this.ManZonaCreate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreZona;
        private MaterialSkin.Controls.MaterialRaisedButton btnCrear;
        private MaterialSkin.Controls.MaterialRaisedButton btnElegirColor;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox txtDisplayColor;
        private System.Windows.Forms.TextBox txtDescripcionZona;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioZona;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}