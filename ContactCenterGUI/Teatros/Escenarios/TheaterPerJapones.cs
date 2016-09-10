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
        private bool mouseDown;
        private Point lastLocation;

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

        private void popup_Click(object sender, EventArgs e)
        {

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            vistaPlatea();
        }

        private void vistaPlatea() {
            Image i = ContactCenterGUI.Properties.Resources.PJ_PLATEA;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void vistaMezzanine()
        {
            Image i = ContactCenterGUI.Properties.Resources.PJ_MEZZANINE;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void vpb_Click(object sender, EventArgs e)
        {
            vistaPlatea();
        }

        private void vma_Click(object sender, EventArgs e)
        {
            vistaMezzanine();
        }

        private void vmb_Click(object sender, EventArgs e)
        {
            vistaMezzanine();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
