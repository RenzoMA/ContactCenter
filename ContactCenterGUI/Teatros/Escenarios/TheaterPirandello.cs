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
    public partial class TheaterPirandello : MaterialForm
    {
        private bool mouseDown;
        private Point lastLocation;
        public TheaterPirandello()
        {
            InitializeComponent();
        }

        private void TheaterPirandello_Load(object sender, EventArgs e)
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

        private void button221_Click(object sender, EventArgs e)
        {

        }

        private void pvpa_Click(object sender, EventArgs e)
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_PLATEA_1;
            vistaPlatea(i);
        }

        private void vistaPlatea(Image img)
        {
            Image i = img;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void vistaMezzanine(Image img)
        {
            Image i = img;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void pvpb_Click(object sender, EventArgs e)
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_PLATEA_2;
            vistaPlatea(i);
        }

        private void pvma_Click(object sender, EventArgs e)
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_MEZZANINE_1;
            vistaMezzanine(i);
        }

        private void pvmb_Click(object sender, EventArgs e)
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_MEZZANINE_2;
            vistaMezzanine(i);
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
