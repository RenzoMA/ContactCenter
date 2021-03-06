﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Microsoft.Practices.Unity;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class FindReservation : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private string filtro;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        public FindReservation()
        {
            InitializeComponent();
            dgvResult.AutoGenerateColumns = false;
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value <= dtpFechaFin.Value)
            {
                filtro = txtTelefono.Text.ToUpper().Trim();
                fechaInicio = dtpFechaInicio.Value.Date;
                fechaFin = dtpFechaFin.Value.Date;
                Enlazar();
            }
            else
            {
                MessageBox.Show("Ingrese correctamente las fechas", "Aviso");
            }
        }

        private void Enlazar()
        {
            try
            {
                dgvResult.DataSource = servicio.BuscarByNamePhoneDate(filtro, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Reserva reserva = (Reserva)dgvResult.CurrentRow.DataBoundItem;
                if (reserva.EstadoReserva.IdEstadoReserva == 2)
                {
                    MessageBox.Show("La reserva ya se encuentra anulada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (reserva.EstadoReserva.IdEstadoReserva == 1)
                {
                    DialogResult dialog = MessageBox.Show("¿Seguro de cancelar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        try
                        {
                            if (servicio.CancelarReserva(reserva.IdReserva))
                            {
                                MessageBox.Show("Reserva cancelada correctamente", "Aviso");
                                Enlazar();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle red = this.dgvResult.DefaultCellStyle.Clone();
            red.ForeColor = Color.Red;
            red.Font = new Font(red.Font, FontStyle.Bold);
            red.Alignment = DataGridViewContentAlignment.MiddleLeft;

            foreach (DataGridViewRow dtr in dgvResult.Rows)
            {
                Reserva reservaXs = (Reserva)dtr.DataBoundItem;

                if (reservaXs.EstadoReserva.IdEstadoReserva == 2)
                {
                    dtr.DefaultCellStyle = red;
                    dtr.Cells["Cancelar"].Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
                }

            }
        }
    }
}
