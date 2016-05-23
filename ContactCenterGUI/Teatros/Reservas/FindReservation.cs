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
using ContactCenterServices;

namespace ContactCenterGUI.Teatros
{
    public partial class FindReservation : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private string filtro;
        private DateTime fechaObra;
        public FindReservation()
        {
            InitializeComponent();
            dgvResult.AutoGenerateColumns = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtro = txtTelefono.Text.ToUpper().Trim();
            fechaObra = dateTimePicker1.Value.Date;
            Enlazar();
        }

        private void Enlazar()
        {
            dgvResult.DataSource = servicio.BuscarByNamePhoneDate(filtro, fechaObra);
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigoReserva = Convert.ToInt16(dgvResult.Rows[e.RowIndex].Cells["IdReserva"].Value.ToString());
                DialogResult dialog = MessageBox.Show("¿Seguro de cancelar la reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
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
            }
        }
    }
}
