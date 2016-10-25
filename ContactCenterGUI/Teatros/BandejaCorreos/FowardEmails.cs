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
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using System.IO;
using System.Drawing.Imaging;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;


namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class FowardEmails : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private LogEmail logEmail;
        private string completeHtml;
        

        public FowardEmails(LogEmail logEmail)
        {
            this.logEmail = logEmail;
            completeHtml = logEmail.Mensaje;
            InitializeComponent();
        }

        private void FowardEmailcs_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtCorreoDestino.Text = logEmail.CorreoDestino;
            txtCorreoDestinoCC.Text = logEmail.CorreoDestinoCC;
            txtAsunto.Text = logEmail.Asunto;
            webBrowser1.DocumentText = logEmail.Mensaje;
        }
        private async void ReenviarCorreo()
        {
            try
            {
                Animacion.ShowLoader(this);
                IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
                bool resultado = await servicio.ReenviarCorreo(txtCorreoDestino.Text.Trim(), txtCorreoDestinoCC.Text.Trim(), completeHtml, txtAsunto.Text, logEmail);
                Animacion.HideLoader(this);
                if (resultado)
                {
                    MessageBox.Show("Correo reenviado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error enviando el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReenviar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                CapturarDatos();
                ReenviarCorreo();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidarDatos()
        {
            if (txtAsunto.Text.Trim().Equals(String.Empty))
                return false;
            if (txtCorreoDestino.Text.Trim().Equals(String.Empty))
                return false;
            if (txtCorreoDestinoCC.Text.Trim().Equals(String.Empty))
                return false;
            return true;
        }

        public void CapturarDatos()
        {
            logEmail.Asunto = txtAsunto.Text.ToUpper().Trim();
        }
        private string ReadImageInBase64()
        {
            byte[] imagen = servicio.GetObraImage(logEmail.IdObra);
            return Convert.ToBase64String(imagen);
        }

        private static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string pathImage = ReadImageInBase64();
            //byte[] imageArray = System.IO.File.ReadAllBytes(@"../../Resources/cabecera_correo2.jpg");
            Image imgCabe = ContactCenterGUI.Properties.Resources.cabecera_correo2;
            byte[] imageArray2 = Convertir_Imagen_Bytes(imgCabe);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray2);
            webBrowser1.Document.Images[1].OuterHtml = "<img style='width=100%;' src='data:image/png;base64," + pathImage + "'>";
            webBrowser1.Document.Images[0].OuterHtml = "<img style='width=100%;' src='data:image/jpeg;base64," + base64ImageRepresentation + "'>";
        }
    }
}
