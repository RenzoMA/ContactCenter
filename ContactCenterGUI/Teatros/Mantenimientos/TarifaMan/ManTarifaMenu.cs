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
using ContactCenterGUI.CC.Mantenimientos.AplicacionMan;
using ContactCenterGUI.Teatros.Mantenimientos.AsientoMan;
using ContactCenterGUI.Teatros.Mantenimientos.FuncionMan;
using ContactCenterGUI.Teatros.Mantenimientos.ObraMan;
using ContactCenterGUI.Teatros.Mantenimientos.PromocionMan;
using ContactCenterGUI.Teatros.Mantenimientos.TarifaMan;
using ContactCenterGUI.CC.Mantenimientos.UsuarioMan;

namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifaMenu : MaterialForm
    {
        public ManTarifaMenu()
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
                ManTarifaCreate manfarecreate = new ManTarifaCreate();
                manfarecreate.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 2)
            {

                this.Hide();
                ManTarifaFind manfarefind = new ManTarifaFind();
                manfarefind.ShowDialog();
            }
        }
    }
}
