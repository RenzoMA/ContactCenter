using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterServices.ServicioContactCenter;
using Microsoft.Practices.Unity;
using ContactCenterGUI.Teatros.Helpers;
using ContactCenterCommon;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;

namespace ContactCenterGUI.CC
{
    public partial class Login : MaterialForm
    {
        private string login;
        private string password;

        public void CapturarDatos()
        {
            login = txtUser.Text.Trim();
            password = txtPassword.Text.Trim();
        }

        public void LimpiarMensajesError()
        {
            ep1.Clear();
            //lblMensaje.Text = "";
        }

        public void SetErrorIngreso()
        {
            //lblMensaje.Text = "Contraseña incorrecta";
            //lblMensaje.ForeColor = Color.Red;
            MessageBox.Show("Contrasea incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Login()
        {
            InitializeComponent();
            SetDisplayConfiguration();
        }

        public void SetDisplayConfiguration()
        {
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue800, MaterialSkin.Primary.LightBlue900, MaterialSkin.Primary.LightBlue500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
        }

        public void IniciarSesion()
        {
            LimpiarMensajesError();
            CapturarDatos();
            if (ValidarCampos(login, password))
            {
                ObtenerUsuario();
            }
        }
        private void disableControls()
        {
            txtPassword.Enabled = false;
            txtUser.Enabled = false;
            btnLogin.Enabled = false;
        }
        private void enableControls()
        {
            txtPassword.Enabled = true;
            txtUser.Enabled = true;
            btnLogin.Enabled = true;
        }
        
        public async void ObtenerUsuario()
        {
            try
            {
                disableControls();
                Animacion.ShowLoader(this);
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                Sesion.usuario = await servicio.ValidarUsuarioAsync(login, password);
                if (Sesion.usuario != null)
                {
                    this.Hide();
                    Main main = new Main();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    SetErrorIngreso();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                Animacion.HideLoader(this);
                enableControls();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        public bool ValidarCampos(string login, string password)
        {
            if (login == "")
            {
                ep1.SetError(txtUser, "Ingrese un usuario");
                return false;
            }
            if (password == "")
            {
                ep1.SetError(txtPassword, "Ingrese una contraseña");
                return false;
            }
            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
