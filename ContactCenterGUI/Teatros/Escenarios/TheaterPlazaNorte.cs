﻿using System;
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
using ContactCenterGUI.Teatros.Helpers;

namespace ContactCenterGUI.Teatros.Escenarios
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

       
    }
}
