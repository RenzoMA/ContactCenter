using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ContactCenterServices.ServicioContactCenter;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterCommon;
using ContactCenterGUI.CC.Helpers;
using System.IO;
using ContactCenterServices;

namespace ContactCenterGUI.CC
{
    public partial class Main : MaterialForm
    {
        List<Aplicacion> listaAplicacion;
        int positionX;
        int positionY;
        int buttonHeight = 134;
        int buttonWidth = 194;
        MemoryStream ms;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopularPantalla();
        }

        private async void PopularPantalla()
        {
            try
            {
                Animacion.ShowLoader(this);
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                listaAplicacion = await servicio.ListarAplicacionUsuarioAsync(Sesion.usuario);
                GenerarMenu(listaAplicacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Aviso");
            }
            finally
            {
                Animacion.HideLoader(this);
            }
            
        }

        private void LimpiarXCoordenadas()
        {
            positionX = 45;
        }
        private void LimpiarYCoordenadas()
        {
            positionY = 120;
        }

        private void CoordSiguienteElemento(int x, int y)
        {
            int width = this.Width;
            int height = this.Height;
            int marginRight = 50;
            int marginBottom = 50;

            if ((x + marginRight + (buttonWidth * 2)) > width)
            {
                LimpiarXCoordenadas();
                positionY += marginBottom + buttonHeight;
            }
            else
            {
                positionX += marginRight + buttonWidth;
            }

        }

        private void GenerarMenu(List<Aplicacion> lAplicacion)
        {
            LimpiarXCoordenadas();
            LimpiarYCoordenadas();
            foreach (Aplicacion aplicacion in lAplicacion)
            {
                GenerarElemento(aplicacion);
            }
        }

        void elemento_Click(object sender, EventArgs e)
        {
            Button btnElemento = (Button)sender;
            Aplicacion aplicacion = (Aplicacion)btnElemento.Tag;
            setApplication(aplicacion);
            HelperForm.changeForm(aplicacion.FormInicio,aplicacion.Nombre, true,this);
        }

        void setApplication(Aplicacion aplicacion)
        {
            Sesion.aplicacion = aplicacion;
        }

        private void GenerarElemento(Aplicacion aplicacion)
        {
            Button btn = new Button();
            btn.Tag = aplicacion;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            
            if (aplicacion.Image != null)
            {
                ms = new MemoryStream(aplicacion.Image);
                btn.BackgroundImage = Image.FromStream(ms);
            }
            else
            {
                btn.BackgroundImage = global::ContactCenterGUI.Properties.Resources.teatro;
            }
            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Name = aplicacion.IdAplicacion.ToString();
            btn.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btn.UseVisualStyleBackColor = false;
            btn.Location = new System.Drawing.Point(positionX, positionY);
            btn.Click += elemento_Click;
            Label lbl = new Label();
            lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new System.Drawing.Point(positionX, positionY-30);
            lbl.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            lbl.Text = aplicacion.Nombre;
            lbl.BackColor = Color.Transparent;

            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            CoordSiguienteElemento(positionX, positionY);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                
            }
            else 
            {

            }
        }
    }
}
