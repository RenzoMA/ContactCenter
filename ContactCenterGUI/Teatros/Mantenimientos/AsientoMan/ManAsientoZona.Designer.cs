namespace ContactCenterGUI.Teatros.Mantenimientos.AsientoMan
{
    partial class ManAsientoZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManAsientoZona));
            this.lstAsientos = new System.Windows.Forms.ListBox();
            this.btnAgregar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.lblObra = new System.Windows.Forms.Label();
            this.lblTeatro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstAsientos
            // 
            this.lstAsientos.FormattingEnabled = true;
            this.lstAsientos.Location = new System.Drawing.Point(12, 148);
            this.lstAsientos.Name = "lstAsientos";
            this.lstAsientos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAsientos.Size = new System.Drawing.Size(143, 316);
            this.lstAsientos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Depth = 0;
            this.btnAgregar.Location = new System.Drawing.Point(161, 148);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Primary = true;
            this.btnAgregar.Size = new System.Drawing.Size(168, 40);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teatro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Obra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Zona:";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.BackColor = System.Drawing.Color.White;
            this.lblZona.Location = new System.Drawing.Point(60, 123);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(0, 13);
            this.lblZona.TabIndex = 21;
            // 
            // lblObra
            // 
            this.lblObra.AutoSize = true;
            this.lblObra.BackColor = System.Drawing.Color.White;
            this.lblObra.Location = new System.Drawing.Point(60, 101);
            this.lblObra.Name = "lblObra";
            this.lblObra.Size = new System.Drawing.Size(0, 13);
            this.lblObra.TabIndex = 20;
            // 
            // lblTeatro
            // 
            this.lblTeatro.AutoSize = true;
            this.lblTeatro.BackColor = System.Drawing.Color.White;
            this.lblTeatro.Location = new System.Drawing.Point(60, 77);
            this.lblTeatro.Name = "lblTeatro";
            this.lblTeatro.Size = new System.Drawing.Size(0, 13);
            this.lblTeatro.TabIndex = 19;
            // 
            // ManAsientoZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 470);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.lblObra);
            this.Controls.Add(this.lblTeatro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lstAsientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManAsientoZona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASIGNAR ASIENTOS POR ZONA";
            this.Load += new System.EventHandler(this.ManAsientoZona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAsientos;
        private MaterialSkin.Controls.MaterialRaisedButton btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.Label lblTeatro;
    }
}