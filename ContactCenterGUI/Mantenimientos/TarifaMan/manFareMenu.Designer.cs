namespace ContactCenterGUI.Mantenimientos.TarifaMan
{
    partial class manFareMenu
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
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(174, 307);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(117, 32);
            this.materialRaisedButton1.TabIndex = 7;
            this.materialRaisedButton1.Text = "Aceptar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Elegir Mantenimiento",
            "Nueva Tarifa",
            "Buscar Tarifa"});
            this.metroComboBox1.Location = new System.Drawing.Point(38, 114);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(209, 29);
            this.metroComboBox1.TabIndex = 6;
            // 
            // manFareMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 379);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.metroComboBox1);
            this.Name = "manFareMenu";
            this.Text = "manFareMenu";
            this.Load += new System.EventHandler(this.manFareMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
    }
}