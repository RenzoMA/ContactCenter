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

namespace ContactCenterGUI
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue800, MaterialSkin.Primary.LightBlue900, MaterialSkin.Primary.LightBlue500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                validar();
            }
            else
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();
                this.Close();

            }
        }

        public void validar()
        {

            if (txtUser.Text.Trim() == "")
            {

                ep1.SetError(txtUser, "Ingrese un usuario");
            }
            else
            {
                ep1.Clear();
            }
            if (txtPassword.Text.Trim() == "")
            {
                ep1.SetError(txtPassword, "Ingrese una contraseña");
            }
            else
            {
                ep1.Clear();
            }
        }
    }
}
