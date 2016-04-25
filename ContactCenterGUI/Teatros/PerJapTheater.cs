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
using ContactCenterGUI.Util;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterCommon;

namespace ContactCenterGUI.Teatros
{
    public partial class PerJapTheater : MaterialForm
    {
        public int idTeatro = 1;
        public int idFuncion = 1;
        public int idObra = 1;
        public DateTime fechaReserva = DateTime.Now.Date;

        public PerJapTheater()
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
            Helper.MostrarDisponibilidad(this, idObra, idFuncion, fechaReserva);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTheater newtheater = new NewTheater();
            newtheater.ShowDialog();
        }
    }
}
