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
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.Util;

namespace ContactCenterGUI
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

        public void Limpiar()
        {
            ep1.Clear();
            lblMensaje.Text = "";
        }

        public void SetErrorIngreso()
        {
            lblMensaje.Text = "Contraseña incorrecta";
            lblMensaje.ForeColor = Color.Red;
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

        public void Ingresar()
        {
            Limpiar();
            CapturarDatos();
            if (validar(login, password))
            {
                using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
                {
                    Sesion.usuario = servicio.ValidarUsuario(login, password);
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
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        public bool validar(string login,string password)
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
            txtUser.Text = "rmaldonado";
            txtPassword.Text = "123";
        }
    }
}
