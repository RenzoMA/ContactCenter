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
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.Entidades.CLienteBE;
using ContactCenterGUI.Helpers;
using ContactCenterServices;
using Microsoft.Practices.Unity;

namespace ContactCenterGUI.Teatros
{
    public partial class PerInfoTheater : MaterialForm
    {
        private Form frmTeatro;
        private Reserva reserva;

        public List<AsientoPrecio> listaAsientoPrecio { get; set; }
        public List<DetalleReserva> listaDetalle = new List<DetalleReserva>();
        public DetalleReserva detalle;
        public Cliente cliente;
        public int validaSalida = 0;

        public PerInfoTheater()
        {
            InitializeComponent();
        }
        public PerInfoTheater(Form form,Reserva _reserva)
        {
            reserva = _reserva;
            frmTeatro = form;
            frmTeatro.Visible = false;
            InitializeComponent();
        }
        public Single CalcularPrecio(List<AsientoPrecio> lista)
        {
            Single single = 0;
            foreach (AsientoPrecio obj in lista)
            {
                single += obj.Precio;
            }
            return single;
        }
        public string GenerarAsiento(List<AsientoPrecio> lista)
        {
            int contador = 0;
            string result = "";
            foreach (AsientoPrecio obj in lista)
            {
                contador++;
                result += obj.Fila + obj.Descripcion + ", ";
                if (contador == 15)
                {
                    result += "\n";
                    contador = 0;
                }
            }
            return result;
        }

        private void PerInfoTheater_Load(object sender, EventArgs e)
        {
            lblPrecio.Text = "S/. "+CalcularPrecio(listaAsientoPrecio).ToString();
            lblAsientos.Text = GenerarAsiento(listaAsientoPrecio);
            lblObra.Text = reserva.Obra.Nombre;
            lblFuncion.Text = reserva.Funcion.Horario;
            lblTeatro.Text = reserva.Obra.Teatro.Nombre;

            foreach (AsientoPrecio ap in listaAsientoPrecio)
            {
                detalle = new DetalleReserva();
                detalle.Asiento = ap;
                detalle.Precio = ap.Precio;
                listaDetalle.Add(detalle);
            }
            reserva.ListaDetalles = listaDetalle;

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void PerInfoTheater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validaSalida == 0)
            {
                frmTeatro.Close();
                HelperTeatro.CancelarReservaAsiento();
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            cliente = new Cliente()
            {
                Apellidomaterno = txtApeMat.Text.ToUpper().Trim(),
                ApellidoPaterno = txtApePat.Text.ToUpper().Trim(),
                Correo = txtCorreo.Text.ToUpper().Trim(),
                Nombre = txtNombre.Text.ToUpper().Trim(),
                Telefono = txtTelefono.Text.ToUpper().Trim()
            };
            ProcesarReserva(cliente);
        }
        private async void ProcesarReserva(Cliente cliente)
        {
            Animacion.ShowLoader(this);
            IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
            bool resultado = await servicio.InsertarReservaAsync(reserva, cliente);
            Animacion.HideLoader(this);
            if (resultado)
            {
                MessageBox.Show("Reserva realizada correctamente", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se registro la reserva!!!", "Aviso");
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            ObtenerCliente();
        }
        private async void ObtenerCliente()
        {
            string telefono = txtTelefono.Text.ToUpper().Trim();
            if (telefono != "")
            {
                IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
                Animacion.ShowLoader(this);
                cliente = await servicio.GetClienteByTelefonoAsync(telefono);
                if (cliente != null)
                {
                    txtApeMat.Text = cliente.Apellidomaterno;
                    txtApePat.Text = cliente.ApellidoPaterno;
                    txtCorreo.Text = cliente.Correo;
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono;
                }
                else
                {
                    txtApeMat.Text = "";
                    txtApePat.Text = "";
                    txtCorreo.Text = "";
                    txtNombre.Text = "";
                }
                Animacion.HideLoader(this);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            validaSalida = 1;
            frmTeatro.Visible = true;
            this.Close();
        }
    }
}
