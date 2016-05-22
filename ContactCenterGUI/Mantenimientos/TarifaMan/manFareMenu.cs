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
using ContactCenterGUI.Mantenimientos.AplicacionMan;
using ContactCenterGUI.Mantenimientos.AsientoMan;
using ContactCenterGUI.Mantenimientos.FuncionMan;
using ContactCenterGUI.Mantenimientos.ObraMan;
using ContactCenterGUI.Mantenimientos.PromocionMan;
using ContactCenterGUI.Mantenimientos.TarifaMan;
using ContactCenterGUI.Mantenimientos.UsuarioMan;

namespace ContactCenterGUI.Mantenimientos.TarifaMan
{
    public partial class manFareMenu : MaterialForm
    {
        public manFareMenu()
        {
            InitializeComponent();
        }

        private void manFareMenu_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedItem = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {
                this.Hide();
                manFareCreate manfarecreate = new manFareCreate();
                manfarecreate.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 2)
            {

                this.Hide();
                manFareFind manfarefind = new manFareFind();
                manfarefind.ShowDialog();
            }
        }
    }
}
