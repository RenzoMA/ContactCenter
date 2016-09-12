using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using MaterialSkin.Controls;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using Microsoft.Reporting.WinForms;

namespace ContactCenterGUI.Teatros.Reportes
{
    public partial class RptRankingCliente : MaterialForm
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;

        public RptRankingCliente()
        {
            InitializeComponent();
        }

        private void RptRankingCliente_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            try
            {
                fechaInicio = dtpFechaInicio.Value.Date;
                fechaFin = dtpFechaFin.Value.Date;
                List<RankingCliente> listaRankingCliente;

                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaRankingCliente = servicio.ObtenerRankingCliente(fechaInicio, fechaFin);
                }

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("DataSet1", listaRankingCliente);

                reportViewer1.LocalReport.DataSources.Add(Reporte);

                //reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportPago.rdlc";

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("fechaInicio", "" + fechaInicio));
                parametros.Add(new ReportParameter("fechaFin", "" + fechaFin));
                //Añado parametros al reportviewer
                this.reportViewer1.LocalReport.SetParameters(parametros);
                reportViewer1.RefreshReport();

                reportViewer1.Focus();
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
    }
}
