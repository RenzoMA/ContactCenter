using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterGUI.Helpers;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterCommon;

namespace ContactCenterGUI.Teatros
{
    public partial class TheaterPeruanoJapones : MaterialForm
    {
        public int idTeatro = 1;
        public int idFuncion = 1;
        public int idObra = 1;

        private Reserva reserva;

        public TheaterPeruanoJapones()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void NewTheater2_Load(object sender, EventArgs e)
        {
            reserva = (Reserva)this.Tag;
            HelperTeatro.MostrarDisponibilidad(this, reserva);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se perderan todos los cambios realizados hasta el momento. ¿ seguro de regresar ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                NewReservation newtheater = new NewReservation();
                newtheater.ShowDialog();
                this.Show();
            }
        }
    }
}
