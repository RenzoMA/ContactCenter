namespace ContactCenterGUI.Teatros.Mantenimientos.EmpresaMan
{
    partial class ManEmpresaCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManEmpresaCreate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCortesias = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnCrear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombreZona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtCortesias);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.txtNombreZona);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 186);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(39, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 21);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Cortesias:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCrear
            // 
            this.btnCrear.Depth = 0;
            this.btnCrear.Location = new System.Drawing.Point(157, 116);
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
            this.materialLabel3.Location = new System.Drawing.Point(35, 35);
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
            this.txtNombreZona.Location = new System.Drawing.Point(142, 31);
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
            // ManEmpresaCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 274);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManEmpresaCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Empresa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCortesias;
        private System.Windows.Forms.CheckBox checkBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCrear;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreZona;
    }
}