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
using ContactCenterGUI.Teatros.Reportes;

using Microsoft.Practices.Unity;
using ContactCenterGUI.Teatros.Helpers;
using ContactCenterCommon;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class ReportesTeatro : MaterialForm
    {
        public ReportesTeatro()
        {
            InitializeComponent();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            RptReservas rptRes = new RptReservas();
            rptRes.ShowDialog();
            this.Show();
        }

        private void btnReporteCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            RptRankingCliente rptRankingCliente = new RptRankingCliente();
            rptRankingCliente.ShowDialog();
            this.Show();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RptReservasObra rptReservaObra = new RptReservasObra();
            rptReservaObra.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
