using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;

namespace ContactCenterGUI.Mantenimientos.Aplicacion
{
    public partial class ManAppMenu : MaterialForm
    {
        public ManAppMenu()
        {
            InitializeComponent();
        }

        private void ManAppMenu_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {

                this.Hide();
                Mantenimientos.ManAppCreate manappcreate = new Mantenimientos.ManAppCreate();
                manappcreate.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 2) {

                this.Hide();
                Mantenimientos.Aplicacion.ManAppBuscar manappbuscar = new Mantenimientos.Aplicacion.ManAppBuscar();
                manappbuscar.ShowDialog();
            }
        }
    }
}
