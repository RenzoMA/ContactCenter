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
            vistaPlatea();
        }

        private void vistaPlatea()
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_PLATEA;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void vistaMezzanine()
        {
            Image i = ContactCenterGUI.Properties.Resources.PIRANDELLO_MEZZANINE;
            Vista frm = new Vista(i);
            frm.Show();
        }

        private void pvpb_Click(object sender, EventArgs e)
        {
            vistaPlatea();
        }

        private void pvma_Click(object sender, EventArgs e)
        {
            vistaMezzanine();
        }

        private void pvmb_Click(object sender, EventArgs e)
        {
            vistaMezzanine();
        }
    }
}
