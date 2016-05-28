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
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WinForms;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Teatros.Reportes
{
    public partial class RptReservas : MaterialForm
    {
        private Teatro teatro;
        private DateTime fechaObra; 
        public RptReservas()
        {
            InitializeComponent();
        }
        private void PopulateCombobox()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                try
                {
                    cboTeatro.DataSource = servicio.ListarTeatros();
                    cboTeatro.DisplayMember = "Nombre";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                

        }
        private void rptReservas_Load(object sender, EventArgs e)
        {
            PopulateCombobox();
            this.reportViewer1.RefreshReport();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                fechaObra = dtpFechaObra.Value.Date;
                teatro = cboTeatro.SelectedItem as Teatro;
                List<Reserva> lista = new List<Reserva>();
                using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
                {
                    lista = servicio.ReporteReservas(teatro.IdTeatro, fechaObra);
                }

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("DataSetReserva", lista);

                reportViewer1.LocalReport.DataSources.Add(Reporte);

                //reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportPago.rdlc";

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("NombreTeatro", "" + teatro.Nombre));
                parametros.Add(new ReportParameter("FechaObra", "" + fechaObra));
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
    }
}
