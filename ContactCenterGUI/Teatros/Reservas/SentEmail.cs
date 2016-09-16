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

        public SentEmail()
        {
            InitializeComponent();
            
        }

        private void SentEmail_Load(object sender, EventArgs e)
        {
            try
            {
                dgvEmail.AutoGenerateColumns = false;
                dgvEmail.DataSource = servicio.ListarEmail();
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
            if(e.ColumnIndex == 6)
            {
                LogEmail logEmail = (LogEmail)dgvEmail.CurrentRow.DataBoundItem;
                FowardEmails fowardEmail = new FowardEmails(logEmail);
                fowardEmail.ShowDialog();
            }
        }

        private void dgvEmail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            LogEmail logEmail = (LogEmail)dgvEmail.Rows[e.RowIndex].DataBoundItem;
            //MessageBox.Show(reserva.IdReserva.ToString());
            if (logEmail.Estado == "FALLO")
            {
                dgvEmail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Red, BackColor = Color.White };
            }
        }
    }
}
