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
using ContactCenterGUI.CC.Constantes;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Reportes
{
    public partial class RptRankingCliente : MaterialForm
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private bool isProcessing = false;

        public RptRankingCliente()
        {
            InitializeComponent();
            
        }
        private async void btnGenerar_Click_1(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                try
                {
                    
                    isProcessing = true;
                    fechaInicio = dtpFechaInicio.Value.Date;
                    fechaFin = dtpFechaFin.Value.Date;
                    List<RankingCliente> listaRankingCliente;

                    using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                    {
                        
                        listaRankingCliente = await servicio.ObtenerRankingClienteAsync(fechaInicio, fechaFin);
                    }
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource Reporte = new ReportDataSource("DataSet1", listaRankingCliente);
                    reportViewer1.LocalReport.DataSources.Add(Reporte);
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
            else
            {
                MessageBox.Show("Reporte en ejecución", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            isProcessing = false;
        }
    }
}
