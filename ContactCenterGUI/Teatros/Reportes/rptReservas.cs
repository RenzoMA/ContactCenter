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
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Reportes
{
    public partial class RptReservas : MaterialForm
    {
        private Teatro teatro;
        private DateTime fechaObra;
        private DateTime fechaObraFin;
        private bool isProcessing = false;
        public RptReservas()
        {
            InitializeComponent();
            
        }
        private void PopulateCombobox()
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                try
                {
                    cboTeatro2.DataSource = servicio.ListarTeatros();
                    cboTeatro2.DisplayMember = "Nombre";
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
            //this.reportViewer1.RefreshReport();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
         
        }
        
        private async void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                try
                {
                    isProcessing = true;
                    fechaObra = dtpFechaObra.Value.Date;
                    fechaObraFin = dtpFechaObraFin.Value.Date;
                    teatro = cboTeatro2.SelectedItem as Teatro;
                    List<DetalleReserva> lista = new List<DetalleReserva>();
                    using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                    {
                        lista = await servicio.ReporteReservasAsync(teatro.IdTeatro, fechaObra, fechaObraFin.AddDays(1).AddSeconds(-1));
                    }

                    reportViewer1.ProcessingMode = ProcessingMode.Local;

                    reportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource Reporte = new ReportDataSource("DataSetDetalleReserva", lista);

                    reportViewer1.LocalReport.DataSources.Add(Reporte);

                    //reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportPago.rdlc";

                    List<ReportParameter> parametros = new List<ReportParameter>();
                    parametros.Add(new ReportParameter("NombreTeatro", "" + teatro.Nombre));
                    parametros.Add(new ReportParameter("FechaObra", "" + fechaObra));
                    parametros.Add(new ReportParameter("FechaFin", "" + fechaObraFin));
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
                MessageBox.Show("El reporte se esta ejecutando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            isProcessing = false;
        }
    }
}
