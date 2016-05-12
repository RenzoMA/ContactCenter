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
using ContactCenterGUI.Helpers;

namespace ContactCenterGUI.Teatros
{
    public partial class TheaterPerJapones : MaterialForm
    {
        public TheaterPerJapones()
        {
            InitializeComponent();
        }

        private void TheaterPerJapones_Load(object sender, EventArgs e)
        {
            HelperTeatro.MostrarDisponibilidad(this, (Reserva)this.Tag);
        }
    }
}
