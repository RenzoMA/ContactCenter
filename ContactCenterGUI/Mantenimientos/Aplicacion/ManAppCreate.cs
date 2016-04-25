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

namespace ContactCenterGUI.Mantenimientos
{
    public partial class ManAppCreate : MaterialForm
    {
        public ManAppCreate()
        {
            InitializeComponent();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimientos.Aplicacion.ManAppMenu manappmenu = new Mantenimientos.Aplicacion.ManAppMenu();
            manappmenu.ShowDialog();
            
        }
    }
}
