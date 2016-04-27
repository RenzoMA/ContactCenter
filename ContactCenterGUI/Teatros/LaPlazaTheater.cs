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

        public LaPlazaTheater()
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

        private void button124_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTheater newtheater = new NewTheater();
            newtheater.ShowDialog();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teatros.PerInfoTheater info = new Teatros.PerInfoTheater();
            info.ShowDialog();
        }

        private void CallaoTheater_Load(object sender, EventArgs e)
        {
            reserva = (Reserva)this.Tag;
            HelperTeatro.MostrarDisponibilidad(this, reserva.Obra.IdObra, reserva.Funcion.IdFuncion, reserva.FechaReserva, reserva.Obra.Teatro.IdTeatro);
        }
    }
}
