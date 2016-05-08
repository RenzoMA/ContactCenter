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
using ContactCenterGUI.Helpers;

namespace ContactCenterGUI.Teatros
{
    public partial class TheaterLaPlaza : MaterialForm
    {
        private Reserva reserva;

        public TheaterLaPlaza()
        {
            InitializeComponent();
        }

        private void CallaoTheater_Load(object sender, EventArgs e)
        {
            materialLabel1.ForeColor = Color.White;
            reserva = (Reserva)this.Tag;
            HelperTeatro.MostrarDisponibilidad(this, reserva);
        }

        private void btnAtras_Click(object sender, EventArgs e)
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

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
