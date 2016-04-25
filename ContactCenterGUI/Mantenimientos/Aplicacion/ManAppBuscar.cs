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

namespace ContactCenterGUI.Mantenimientos.Aplicacion
{
    public partial class ManAppBuscar : MaterialForm
    {
        public ManAppBuscar()
        {
            InitializeComponent();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimientos.Aplicacion.ManAppMenu manappmenu = new Mantenimientos.Aplicacion.ManAppMenu();
            manappmenu.ShowDialog();
            //pruena
            
        }
    }
}
