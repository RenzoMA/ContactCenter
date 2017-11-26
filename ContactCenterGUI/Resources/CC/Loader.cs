using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ContactCenterGUI.CC.Helpers;


namespace ContactCenterGUI.CC
{
    public partial class Loader : Form
    {
        private Form MainForm;
        private int intentos = 0;

        public Loader()
        {
            InitializeComponent();
            MainForm = this;
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            StartLoader(); 
        }
        public async void StartLoader()
        {
            if (intentos < 3)
            {
                lblMensajeConexion.Text = "Iniciando...";
                await Task.Delay(1500);
                if (HelperConexion.PingHost(ConfigurationManager.AppSettings["ServerAccess"]))
                {
                    lblMensajeConexion.Text = "Conexión exitosa..";
                    await Task.Delay(1000);
                    this.Hide();
                    MainForm.BeginInvoke((Action)delegate {
                        Login login = new Login();
                        login.ShowDialog();
                        this.Close();
                    });
                }
                else
                {
                    lblMensajeConexion.Text = "Error en la conexión..";
                    await Task.Delay(1000);
                    intentos++;
                    lblMensajeConexion.Text = "Reintentando..";
                    await Task.Delay(1000);
                    StartLoader();
                }
            }
            else
            {
                MessageBox.Show("No hay conexion con el servidor, cerrando aplicación");
                this.Close();
            }
        }
    }
}
