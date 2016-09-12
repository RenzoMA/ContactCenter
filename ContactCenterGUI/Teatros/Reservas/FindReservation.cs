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
using Microsoft.Practices.Unity;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;

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
                int codigoReserva = Convert.ToInt16(dgvResult.Rows[e.RowIndex].Cells["IdReserva"].Value.ToString());
                DialogResult dialog = MessageBox.Show("¿Seguro de cancelar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        if (servicio.CancelarReserva(codigoReserva))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
