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
using ContactCenterServices.ServicioTeatro;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.Teatros.Helpers;
using Microsoft.Practices.Unity;
using ContactCenterServices;
using System.IO;
using OfficeOpenXml;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewReservation newtheater = new NewReservation();
            newtheater.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportesTeatro rptTeatro = new ReportesTeatro();
            rptTeatro.ShowDialog();
            this.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindReservation findReservation = new FindReservation();
            findReservation.ShowDialog();
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

        private void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xlsx;";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                RealizarCargaMasiva(file);
            }
        }
        private async void RealizarCargaMasiva(String path)
        {
            try
            {
                Animacion.ShowLoader(this);
                IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
                bool resultado = await servicio.CargaMasivaAsync(path);
                Animacion.HideLoader(this);
                if (resultado)
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El proceso no se realizo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error importando el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Animacion.HideLoader(this);
            }
        }

        private void btnGenerarFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Formato.xlsx";
            saveFileDialog1.Filter = "Excel Files|*.xlsx;";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {


                FileInfo newFile = new FileInfo(saveFileDialog1.FileName);

                ExcelPackage pck = new ExcelPackage(newFile);
                int hojas = pck.Workbook.Worksheets.Where(x => x.Name == "Formato").ToList().Count;
                if (hojas > 0)
                {
                    pck.Workbook.Worksheets.Delete("Formato");
                }
                var ws = pck.Workbook.Worksheets.Add("Formato");
                ws.Cells["A1"].Value = "TEATRO";
                ws.Cells["B1"].Value = "OBRA";
                ws.Cells["C1"].Value = "FECHA RESERVA";
                ws.Cells["D1"].Value = "FUNCION";
                ws.Cells["E1"].Value = "ZONA";
                ws.Cells["F1"].Value = "FILA";
                ws.Cells["G1"].Value = "ASIENTO";
                ws.Cells["H1"].Value = "PROMOCION";
                ws.Cells["I1"].Value = "PRECIO";
                ws.Cells["J1"].Value = "TELEFONO";
                ws.Cells["K1"].Value = "NOMBRE";
                ws.Cells["L1"].Value = "APELLIDOS";
                ws.Cells["M1"].Value = "CORREO";
                ws.Cells["N1"].Value = "USUARIO REGISTRO";
                ws.Cells["A1:N1"].Style.Font.Bold = true;
                pck.Save();
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
