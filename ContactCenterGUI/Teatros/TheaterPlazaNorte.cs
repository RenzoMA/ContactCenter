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
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using MaterialSkin.Controls;
using ContactCenterGUI.Helpers;

namespace ContactCenterGUI.Teatros
{
    public partial class TheaterPlazaNorte : MaterialForm
    {
        public TheaterPlazaNorte()
        {
            InitializeComponent();
        }

        private void PlazaNorteTheater_Load(object sender, EventArgs e)
        {
            HelperTeatro.MostrarDisponibilidad(this, (Reserva)this.Tag);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se perderan todos los cambios realizados hasta el momento. ¿ seguro de regresar ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                NewReservation newtheater = new NewReservation();
                newtheater.ShowDialog();
                this.Show();
            }
        }

        private void btnMiminizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
