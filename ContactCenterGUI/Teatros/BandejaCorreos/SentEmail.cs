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
using MaterialSkin.Controls;
using ContactCenterServices;
using ContactCenterGUI.CC.Helpers;
using Microsoft.Practices.Unity;
using System.IO;
using System.Drawing.Imaging;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterServices.ServicioTeatro;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class SentEmail : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        DateTime fechaInicio, fechaFin;
        List<LogEmail> listaCorreoFecha;
        bool proceso = true;

        public SentEmail()
        {
            InitializeComponent();
            fechaInicio = dtpFechaInicio.Value.Date;
            fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
        }

        private void SentEmail_Load(object sender, EventArgs e)
        {
            try
            {
                dgvEmail.AutoGenerateColumns = false;
                EnlazarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (proceso)
            {
                proceso = false;
                if (e.ColumnIndex == 7)
                {
                    LogEmail logEmail = (LogEmail)dgvEmail.CurrentRow.DataBoundItem;
                    FowardEmails fowardEmail = new FowardEmails(logEmail);
                    fowardEmail.ShowDialog();
                    EnlazarGrilla();
                }
                proceso = true;
            }
        }

        private void EnlazarGrilla()
        {
            listaCorreoFecha = servicio.ListaCorreoFechas(fechaInicio, fechaFin);
            dgvEmail.DataSource = listaCorreoFecha;
        }
        private void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            dgvEmail.DataSource = servicio.ListarEmail();
        }

        private void dgvEmail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle red = this.dgvEmail.DefaultCellStyle.Clone();
            red.ForeColor = Color.Red;
            red.Font = new Font(red.Font, FontStyle.Bold);
            red.Alignment = DataGridViewContentAlignment.MiddleLeft;

            foreach (DataGridViewRow dtr in dgvEmail.Rows)
            {
                LogEmail logEmail = (LogEmail)dtr.DataBoundItem;

                if (logEmail.Estado == "FALLO")
                {
                    dtr.DefaultCellStyle = red;
                    dtr.Cells["Mensaje"].Style = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fechaInicio = dtpFechaInicio.Value.Date;
            fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
            if(fechaInicio > fechaFin)
            {
                MessageBox.Show("Seleccionar una rango de fechas válidas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EnlazarGrilla();
            }
        }
    }
}
