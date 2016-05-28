namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    partial class ManFuncionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManFuncionEdit));
            this.btnActualizar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtHoarario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cboDia = new MetroFramework.Controls.MetroComboBox();
            this.Día = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cboTeatro = new MetroFramework.Controls.MetroComboBox();
            this.cboObra = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cboEstado = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Depth = 0;
            this.btnActualizar.Location = new System.Drawing.Point(94, 338);
            this.btnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Primary = true;
            this.btnActualizar.Size = new System.Drawing.Size(168, 40);
            this.btnActualizar.TabIndex = 32;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtHoarario
            // 
            this.txtHoarario.Depth = 0;
            this.txtHoarario.Hint = "";
            this.txtHoarario.Location = new System.Drawing.Point(131, 238);
            this.txtHoarario.MaxLength = 32767;
            this.txtHoarario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtHoarario.Name = "txtHoarario";
            this.txtHoarario.PasswordChar = '\0';
            this.txtHoarario.SelectedText = "";
            this.txtHoarario.SelectionLength = 0;
            this.txtHoarario.SelectionStart = 0;
            this.txtHoarario.Size = new System.Drawing.Size(177, 23);
            this.txtHoarario.TabIndex = 31;
            this.txtHoarario.TabStop = false;
            this.txtHoarario.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(38, 242);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(60, 19);
            this.materialLabel3.TabIndex = 30;
            this.materialLabel3.Text = "Horario";
            // 
            // cboDia
            // 
            this.cboDia.FormattingEnabled = true;
            this.cboDia.ItemHeight = 23;
            this.cboDia.Items.AddRange(new object[] {
            "Seleccione día",
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.cboDia.Location = new System.Drawing.Point(131, 186);
            this.cboDia.Name = "cboDia";
            this.cboDia.Size = new System.Drawing.Size(177, 29);
            this.cboDia.TabIndex = 29;
            // 
            // Día
            // 
            this.Día.AutoSize = true;
            this.Día.BackColor = System.Drawing.Color.White;
            this.Día.Depth = 0;
            this.Día.Font = new System.Drawing.Font("Roboto", 11F);
            this.Día.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Día.Location = new System.Drawing.Point(38, 196);
            this.Día.MouseState = MaterialSkin.MouseState.HOVER;
            this.Día.Name = "Día";
            this.Día.Size = new System.Drawing.Size(31, 19);
            this.Día.TabIndex = 28;
            this.Día.Text = "Día";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(38, 99);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(53, 19);
            this.materialLabel4.TabIndex = 27;
            this.materialLabel4.Text = "Teatro";
            // 
            // cboTeatro
            // 
            this.cboTeatro.FormattingEnabled = true;
            this.cboTeatro.ItemHeight = 23;
            this.cboTeatro.Location = new System.Drawing.Point(131, 89);
            this.cboTeatro.Name = "cboTeatro";
            this.cboTeatro.Size = new System.Drawing.Size(177, 29);
            this.cboTeatro.TabIndex = 26;
            // 
            // cboObra
            // 
            this.cboObra.FormattingEnabled = true;
            this.cboObra.ItemHeight = 23;
            this.cboObra.Location = new System.Drawing.Point(131, 138);
            this.cboObra.Name = "cboObra";
            this.cboObra.Size = new System.Drawing.Size(177, 29);
            this.cboObra.TabIndex = 25;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(38, 148);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(40, 19);
            this.materialLabel1.TabIndex = 24;
            this.materialLabel1.Text = "Obra";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(38, 291);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(56, 19);
            this.materialLabel2.TabIndex = 33;
            this.materialLabel2.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.ItemHeight = 23;
            this.cboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstado.Location = new System.Drawing.Point(131, 281);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(177, 29);
            this.cboEstado.TabIndex = 34;
            // 
            // ManFuncionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 406);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtHoarario);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.cboDia);
            this.Controls.Add(this.Día);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.cboTeatro);
            this.Controls.Add(this.cboObra);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManFuncionEdit";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar función";
            this.Load += new System.EventHandler(this.ManFuncionEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnActualizar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtHoarario;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MetroFramework.Controls.MetroComboBox cboDia;
        private MaterialSkin.Controls.MaterialLabel Día;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MetroFramework.Controls.MetroComboBox cboTeatro;
        private MetroFramework.Controls.MetroComboBox cboObra;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MetroFramework.Controls.MetroComboBox cboEstado;
    }
}