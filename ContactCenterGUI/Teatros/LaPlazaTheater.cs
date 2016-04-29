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
    public partial class LaPlazaTheater : MaterialForm
    {
        private Reserva reserva;
        private string token;

        public LaPlazaTheater()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HelperTeatro.EliminarSeparadas(token);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button124_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            HelperTeatro.EliminarSeparadas(token);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            HelperTeatro.ConfirmarReserva();
        }

        private void CallaoTheater_Load(object sender, EventArgs e)
        {
            reserva = (Reserva)this.Tag;
            token = HelperTeatro.GenerarToken();
            HelperTeatro.MostrarDisponibilidad(this, reserva,token);
        }
    }
}
