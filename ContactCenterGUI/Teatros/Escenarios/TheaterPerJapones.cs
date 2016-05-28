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
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.Teatros.Helpers;

namespace ContactCenterGUI.Teatros.Escenarios
{
    public partial class TheaterPerJapones : MaterialForm
    {
        public TheaterPerJapones()
        {
            InitializeComponent();
        }

        private void TheaterPerJapones_Load(object sender, EventArgs e)
        {
            try
            {
                HelperTeatro.MostrarDisponibilidad(this, (Reserva)this.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void A1534_Click(object sender, EventArgs e)
        {

        }

        private void A3176_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void A3102_Click(object sender, EventArgs e)
        {

        }

        private void A2204_Click(object sender, EventArgs e)
        {

        }

        private void A3119_Click(object sender, EventArgs e)
        {

        }

        private void A2220_Click(object sender, EventArgs e)
        {

        }

        private void A2228_Click(object sender, EventArgs e)
        {

        }

        private void A2306_Click(object sender, EventArgs e)
        {

        }

        private void A2320_Click(object sender, EventArgs e)
        {

        }

        private void button864_Click(object sender, EventArgs e)
        {

        }

        private void A2412_Click(object sender, EventArgs e)
        {

        }

        private void A2419_Click(object sender, EventArgs e)
        {

        }

        private void button744_Click(object sender, EventArgs e)
        {

        }

        private void A2481_Click(object sender, EventArgs e)
        {

        }
    }
}
