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
using ContactCenterGUI.CC.Mantenimientos.AplicacionMan;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManPlayMenu : MaterialForm
    {
        public ManPlayMenu()
        {
            InitializeComponent();
        }

        private void ManPlayMenu_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {

                this.Hide();
                ManPlayCreate manplaycreate = new ManPlayCreate();
                manplaycreate.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 2)
            {

                this.Hide();
                ManAppFind manappbuscar = new ManAppFind();
                manappbuscar.ShowDialog();
            }
        }
    }
}
