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

namespace ContactCenterGUI.Mantenimientos.Funcion
{
    public partial class ManFunctionMenu : MaterialForm
    {
        public ManFunctionMenu()
        {
            InitializeComponent();
        }

        private void ManFunctionMenu_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {

                this.Hide();
                Mantenimientos.Funcion.ManFunctionCreate manfuncreate = new Mantenimientos.Funcion.ManFunctionCreate();
                manfuncreate.ShowDialog();

            }
        }
    }
}
