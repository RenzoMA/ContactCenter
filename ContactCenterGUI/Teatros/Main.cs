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
using ContactCenterGUI.Teatros.Reportes;

namespace ContactCenterGUI.Teatros
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewReservation newtheater = new NewReservation();
            newtheater.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            rptReservas rptRes = new rptReservas();
            rptRes.ShowDialog();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            FindReservation findReservation = new FindReservation();
            findReservation.ShowDialog();
        }
    }
}
