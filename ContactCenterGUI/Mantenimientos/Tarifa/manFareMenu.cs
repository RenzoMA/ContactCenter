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

namespace ContactCenterGUI.Mantenimientos.Tarifa
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
                Mantenimientos.Tarifa.manFareCreate manfarecreate = new Mantenimientos.Tarifa.manFareCreate();
                manfarecreate.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 2)
            {

                this.Hide();
                Mantenimientos.Tarifa.manFareFind manfarefind = new Mantenimientos.Tarifa.manFareFind();
                manfarefind.ShowDialog();
            }
        }
    }
}
