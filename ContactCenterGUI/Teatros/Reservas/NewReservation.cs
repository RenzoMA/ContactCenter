﻿using System;
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
using ContactCenterCommon;
using MaterialSkin.Controls;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using System.Globalization;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class NewReservation : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        private int diaFuncion;
        private DateTime FechaFuncion;

        private List<Funcion> listaFuncion = null;
        private Funcion funcion = null;

        private Reserva reserva;

        public NewReservation(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
        }

        private void NewTheater_Load(object sender, EventArgs e)
        {
            InicializarVariables();
            CargarTeatros();
            ConfirmReservation.previousForms.Add(this);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (FechaFuncion >= obra.FechaInicio && FechaFuncion <= obra.FechaFin)
            {
                funcion = metroComboBox3.SelectedValue as Funcion;
                if (funcion.IdFuncion != 0)
                {
                    reserva.Horario = funcion.Horario;
                    reserva.FechaReserva = FechaFuncion;
                    reserva.Obra = obra;
                    reserva.Funcion = funcion;
                    reserva.Usuario = Sesion.usuario;
                    try
                    {
                        servicio.EliminarAsientoTemporalAntiguo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ConfirmReservation.Correo = "";
                    HelperForm.changeForm(funcion.Obra.Teatro.frmTeatro, "Teatros", true, this, reserva);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los datos");
                }
            }
            else
            {
                MessageBox.Show("La obra solo es valida desde el " + obra.FechaInicio.ToShortDateString() + " hasta el " + obra.FechaFin.ToShortDateString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private void metroComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarObras();
        }
        
        private void metroComboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarFuncion();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarFuncion();
        }

        private void InicializarVariables()
        {
            dateTimePicker1.MinDate = DateTime.Today;
            diaFuncion = Util.DayOfWeekHelper(dateTimePicker1.Value.Date.DayOfWeek);
            FechaFuncion = dateTimePicker1.Value.Date;
        }
        private async void CargarTeatros()
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                Animacion.ShowLoader(this);
                try
                {
                    listaTeatro = await servicio.ListarTeatrosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Animacion.HideLoader(this);
                metroComboBox1.DataSource = listaTeatro;
                metroComboBox1.DisplayMember = "Nombre";
            }
            CargarObras();
        }
        private void CargarFuncion()
        {

            txtFecha.Text = dateTimePicker1.Value.ToShortDateString();
            obra = metroComboBox2.SelectedItem as Obra;
            diaFuncion = Util.DayOfWeekHelper(dateTimePicker1.Value.Date.DayOfWeek);
            FechaFuncion = dateTimePicker1.Value.Date;
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                try
                {
                    listaFuncion = servicio.ListarFuncionDiaObra(diaFuncion, obra.IdObra);
                    metroComboBox3.DataSource = listaFuncion;
                    metroComboBox3.DisplayMember = "Horario";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
        private void CargarObras()
        {
            teatro = metroComboBox1.SelectedItem as Teatro;
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                try
                {
                    listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                    metroComboBox2.DataSource = listaObra;
                    metroComboBox2.DisplayMember = "Nombre";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            CargarFuncion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCorreo_MouseClick(object sender, MouseEventArgs e)
        {
            dateTimePicker1.Select();
            SendKeys.Send("%{DOWN}");
        }
    }
}
