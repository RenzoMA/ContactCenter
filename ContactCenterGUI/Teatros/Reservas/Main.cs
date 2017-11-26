using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using System.Globalization;
using System.Net.Sockets;
using System.Threading;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class Main : MaterialForm
    {
        bool proceso = true;
        private Thread avayaThread;
        private TcpListener avayaListener;

        public Main()
        {
            InitializeComponent();
            CargarHilo();
        }
        public void CargarHilo()
        {
            avayaListener = new TcpListener(System.Net.IPAddress.Any,
                Convert.ToInt32(ConfigurationManager.AppSettings["PuertoServer"]));
            avayaListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress,true); //a testear
            avayaThread = new Thread(() => EscucharConexion(avayaListener)); // Modificado tambien
            avayaThread.Start();
        }
        public void EscucharConexion(TcpListener listener)
        {
            try
            {
                //avayaListener = new TcpListener(System.Net.IPAddress.Any,
                //    Convert.ToInt32(ConfigurationManager.AppSettings["PuertoServer"]));
                avayaListener.Start();
                while (true)
                {
                    // Using test
                    using (var clientTcp = avayaListener.AcceptTcpClient())
                    {
                        var client = new ConexionAvaya(clientTcp);
                        client.LineReceived += ProcesarMensaje;
                    }
                    //var client = new ConexionAvaya(avayaListener.AcceptTcpClient());
                    //client.LineReceived += ProcesarMensaje;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcesarMensaje(ConexionAvaya conexionAvaya, string mensaje)
        {
            string[] arrayMessage = mensaje.Trim().Split((char)(45));
            string telefonoCliente = arrayMessage[0];
            string telefonoMarca = arrayMessage[1];
            this.Hide();
            ClientDetail newtheater = new ClientDetail(telefonoCliente);
            newtheater.ShowDialog();
            this.Show();
        }
        public void CargarHilo()
        {
            avayaThread = new Thread(new ThreadStart(EscucharConexion));
            avayaThread.Start();
        }
        public void EscucharConexion()
        {
            try
            {
                avayaListener = new TcpListener(System.Net.IPAddress.Any,
                    Convert.ToInt32(ConfigurationManager.AppSettings["PuertoServer"]));
                avayaListener.Start();
                do
                {
                    var client = new ConexionAvaya(avayaListener.AcceptTcpClient());
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientDetail newtheater = new ClientDetail();
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
            if (proceso)
            {
                proceso = false;
                openFileDialog1.Dispose();
                openFileDialog1.Filter = "Excel Files|*.xlsx;";
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;
                    RealizarCargaMasiva(file);
                }
                proceso = true;
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
                ws.Cells["I1"].Value = "EMPRESA";
                ws.Cells["J1"].Value = "PRECIO";
                ws.Cells["K1"].Value = "TELEFONO";
                ws.Cells["L1"].Value = "NOMBRE";
                ws.Cells["M1"].Value = "APELLIDOS";
                ws.Cells["N1"].Value = "CORREO";
                ws.Cells["O1"].Value = "USUARIO REGISTRO";
                ws.Cells["A1:O1"].Style.Font.Bold = true;
                ws.Cells["A1:A100"].Style.Numberformat.Format = "@";
                ws.Cells["B1:B100"].Style.Numberformat.Format = "@";
                ws.Cells["C1:C100"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                ws.Cells["D1:D100"].Style.Numberformat.Format = "@";
                ws.Cells["E1:E100"].Style.Numberformat.Format = "@";
                ws.Cells["F1:F100"].Style.Numberformat.Format = "@";
                ws.Cells["G1:G100"].Style.Numberformat.Format = "@";
                ws.Cells["H1:H100"].Style.Numberformat.Format = "@";
                ws.Cells["I1:I100"].Style.Numberformat.Format = "@";
                ws.Cells["J1:J100"].Style.Numberformat.Format = "@";
                ws.Cells["K1:K100"].Style.Numberformat.Format = "@";
                ws.Cells["L1:L100"].Style.Numberformat.Format = "@";
                ws.Cells["M1:M100"].Style.Numberformat.Format = "@";
                ws.Cells["N1:N100"].Style.Numberformat.Format = "@";
                ws.Cells["O1:O100"].Style.Numberformat.Format = "@";

                pck.Save();
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnBandejaSalida_Click(object sender, EventArgs e)
        {
            this.Hide();
            SentEmail frmSentEmail = new SentEmail();
            frmSentEmail.ShowDialog();
            this.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private async void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //avayaListener.Stop();
            //avayaThread.Join();
        }
    }
}
