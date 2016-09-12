using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using System.IO;
using ContactCenterGUI.CC.Helpers;
using System.Drawing.Imaging;
using ContactCenterServices.ServicioContactCenter;
using ContactCenterServices;
using Microsoft.Practices.Unity;

namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    public partial class ManAplicacionEditar : MaterialForm
    {
        private Aplicacion aplicacion;
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManAplicacionEditar(Aplicacion aplicacion)
        {
            InitializeComponent();
            this.aplicacion = aplicacion;
        }

        private void PopularCampos()
        {
            txtAplicacion.Text = aplicacion.Nombre;
            txtAplicacion.Enabled = false;
            txtCorreo.Text = aplicacion.Correo;
            if (aplicacion.Image != null)
            {
                MemoryStream ms = new MemoryStream(aplicacion.Image);
                pcbImagen.Image = Image.FromStream(ms);
            }
        }

        private void ManAplicacionEditar_Load(object sender, EventArgs e)
        {
            PopularCampos();
            SetEventos();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pcbImagen.Image = HelperForm.ResizeImage(Image.FromFile(openFileDialog1.FileName),134,194);
            }
        }

        private void SetEventos()
        {
            txtCorreo.Validating += HelperControl.ValidEmail;
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            aplicacion.Correo = txtCorreo.Text.ToUpper().Trim();
            if (pcbImagen.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pcbImagen.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                aplicacion.Image = photo_aray;
            }
            try { 
            if (servicio.UpdateAplicacion(aplicacion))
            {
                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error", "verifique");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
