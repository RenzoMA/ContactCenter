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
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WinForms;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ObraBE;

namespace ContactCenterGUI.Teatros.Reportes
{
    public partial class RptReservasObra : MaterialForm
    {

        private DateTime fechaInicio;
        private DateTime fechaFin;
        
        public RptReservasObra()
        {
            InitializeComponent();
        }

        
        private void btnGenRep_Click(object sender, EventArgs e)
        {
            try
            {
                fechaInicio = dtpFechaReservaI.Value.Date;
                fechaFin = dtpFechaReservaF.Value.Date;
               
                List<ReservaObra> listaReservaObra;

                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaReservaObra = servicio.ReporteReservaObra(fechaInicio, fechaFin);
                }

                rptcro.ProcessingMode = ProcessingMode.Local;

                rptcro.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("DataSet1", listaReservaObra);

                rptcro.LocalReport.DataSources.Add(Reporte);

                //reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportPago.rdlc";

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("FechaIni", "" + fechaInicio));
                parametros.Add(new ReportParameter("FechaFin", "" + fechaFin));
                //Añado parametros al reportviewer
                this.rptcro.LocalReport.SetParameters(parametros);
                rptcro.RefreshReport();

                rptcro.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RptReservasObra_Load(object sender, EventArgs e)
        {
            this.rptcro.RefreshReport();
        }
    }
}
