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
        

        public FowardEmails(LogEmail logEmail)
        {
            this.logEmail = logEmail;
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
            webBrowser1.DocumentText = logEmail.Mensaje;
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            servicio.ReenviarCorreo(txtCorreoDestino.Text.Trim(),txtCorreoDestinoCC.Text.Trim(),webBrowser1.DocumentText,txtAsunto.Text, logEmail);
        }
    }
}
