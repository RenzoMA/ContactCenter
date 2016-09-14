namespace ContactCenterGUI.Teatros.Reservas
{
    partial class FowardEmails
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
            this.txtCorreoDestino = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCorreoDestinoCC = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnReenviar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txtCorreoDestino
            // 
            this.txtCorreoDestino.BackColor = System.Drawing.Color.White;
            this.txtCorreoDestino.Depth = 0;
            this.txtCorreoDestino.Hint = "";
            this.txtCorreoDestino.Location = new System.Drawing.Point(84, 81);
            this.txtCorreoDestino.MaxLength = 32767;
            this.txtCorreoDestino.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreoDestino.Name = "txtCorreoDestino";
            this.txtCorreoDestino.PasswordChar = '\0';
            this.txtCorreoDestino.SelectedText = "";
            this.txtCorreoDestino.SelectionLength = 0;
            this.txtCorreoDestino.SelectionStart = 0;
            this.txtCorreoDestino.Size = new System.Drawing.Size(600, 23);
            this.txtCorreoDestino.TabIndex = 2;
            this.txtCorreoDestino.TabStop = false;
            this.txtCorreoDestino.UseSystemPasswordChar = false;
            // 
            // txtCorreoDestinoCC
            // 
            this.txtCorreoDestinoCC.BackColor = System.Drawing.Color.White;
            this.txtCorreoDestinoCC.Depth = 0;
            this.txtCorreoDestinoCC.Hint = "";
            this.txtCorreoDestinoCC.Location = new System.Drawing.Point(84, 122);
            this.txtCorreoDestinoCC.MaxLength = 32767;
            this.txtCorreoDestinoCC.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCorreoDestinoCC.Name = "txtCorreoDestinoCC";
            this.txtCorreoDestinoCC.PasswordChar = '\0';
            this.txtCorreoDestinoCC.SelectedText = "";
            this.txtCorreoDestinoCC.SelectionLength = 0;
            this.txtCorreoDestinoCC.SelectionStart = 0;
            this.txtCorreoDestinoCC.Size = new System.Drawing.Size(600, 23);
            this.txtCorreoDestinoCC.TabIndex = 3;
            this.txtCorreoDestinoCC.TabStop = false;
            this.txtCorreoDestinoCC.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(22, 85);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(43, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Para:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(22, 126);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(33, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "CC:";
            // 
            // btnReenviar
            // 
            this.btnReenviar.Depth = 0;
            this.btnReenviar.Location = new System.Drawing.Point(703, 81);
            this.btnReenviar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Primary = true;
            this.btnReenviar.Size = new System.Drawing.Size(95, 64);
            this.btnReenviar.TabIndex = 20;
            this.btnReenviar.Text = "Reenviar";
            this.btnReenviar.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(26, 163);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(772, 458);
            this.webBrowser1.TabIndex = 21;
            // 
            // FowardEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 633);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnReenviar);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtCorreoDestinoCC);
            this.Controls.Add(this.txtCorreoDestino);
            this.Name = "FowardEmails";
            this.Text = "Mensaje";
            this.Load += new System.EventHandler(this.FowardEmailcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreoDestino;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCorreoDestinoCC;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnReenviar;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}