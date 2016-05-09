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
        public TheaterPeruanoJapones()
        {
            InitializeComponent();
        }

        private void NewTheater2_Load(object sender, EventArgs e)
        {
            HelperTeatro.MostrarDisponibilidad(this, (Reserva)this.Tag);
        }

       
    }
}
