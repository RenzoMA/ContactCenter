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
    public partial class TheaterApp : MaterialForm
    {
        public TheaterApp()
        {
            InitializeComponent();
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTheater newtheater = new NewTheater();
            newtheater.ShowDialog();
        }
    }
}
