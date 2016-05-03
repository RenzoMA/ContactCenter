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
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
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
        public Single precioTotal;
        public Cliente cliente;
        public int validaSalida = 0;
        private Boolean AplicoPromocion = false;


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

        private void PopularDatosReserva()
        {
            precioTotal = CalcularPrecio(listaAsientoPrecio);
            lblPrecio.Text = "S/. " + precioTotal.ToString();
            lblAsientos.Text = GenerarAsiento(listaAsientoPrecio);
            lblObra.Text = reserva.Obra.Nombre;
            lblFuncion.Text = reserva.Funcion.Horario;
            lblTeatro.Text = reserva.Obra.Teatro.Nombre;
            
        }
        private void PerInfoTheater_Load(object sender, EventArgs e)
        {
            SetEventos();
            PopularDatosReserva();
            AsociarEntidadesReserva();
            LoadCombos();
            
        }

        private void AsociarEntidadesReserva()
        {
            reserva.ListaDetalles = null;
            foreach (AsientoPrecio ap in listaAsientoPrecio)
            {
                detalle = new DetalleReserva();
                detalle.Asiento = ap;
                detalle.Precio = ap.Precio;
                listaDetalle.Add(detalle);
            }
            reserva.ListaDetalles = listaDetalle;
            reserva.PrecioTotal = precioTotal;
        }
        private void LoadCombos()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                cboTipoPromocion.DataSource = servicio.GetListaTipoPromocion();
                cboTipoPromocion.DisplayMember = "Descripcion";
            }
                
        }
        private void SetEventos()
        {
            txtNombre.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApeMat.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApePat.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtCorreo.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtTelefono.KeyPress += new KeyPressEventHandler(HelperControl.EditTextNumber);
            txtCorreo.Validating += new CancelEventHandler(HelperControl.ValidEmail);
        }

        private void PerInfoTheater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validaSalida == 0)
            {
                frmTeatro.Close();
                HelperTeatro.CancelarReservaAsiento();
            }
        }

        private bool ValidarCampos()
        {
            if (txtApeMat.Text.Trim().Equals(String.Empty))
                return false;
            if (txtApePat.Text.Trim().Equals(String.Empty))
                return false;
            if (txtCorreo.Text.Trim().Equals(String.Empty))
                return false;
            if (txtNombre.Text.Trim().Equals(String.Empty))
                return false;
            if (txtTelefono.Text.Trim().Equals(String.Empty))
                return false;

            return true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                AsociarClienteReserva();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso");
            }
            
        }
        public void AsociarClienteReserva()
        {
            cliente = new Cliente()
            {
                Apellidomaterno = txtApeMat.Text.ToUpper().Trim(),
                ApellidoPaterno = txtApePat.Text.ToUpper().Trim(),
                Correo = txtCorreo.Text.ToUpper().Trim(),
                Nombre = txtNombre.Text.ToUpper().Trim(),
                Telefono = txtTelefono.Text.ToUpper().Trim(),
                DNI = txtDNI.Text.ToUpper().Trim()
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
                    txtDNI.Text = cliente.DNI;
                }
                else
                {
                    txtApeMat.Text = "";
                    txtApePat.Text = "";
                    txtCorreo.Text = "";
                    txtNombre.Text = "";
                    txtDNI.Text = "";
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

        private void cboTipoPromocion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                TipoPromocion tipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
                cboPromocion.DataSource = servicio.ListPromocionByFuncionTipoPromo(reserva.Funcion.IdFuncion, tipoPromocion.IdTipoPromocion);
                cboPromocion.DisplayMember = "Descripcion";
            }
        }

        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            if (!AplicoPromocion)
            {
                Promocion promocion = cboPromocion.SelectedItem as Promocion;
                if (promocion != null)
                {
                    switch (promocion.TipoDescuento)
                    {
                        case "M":

                            foreach (AsientoPrecio ap in listaAsientoPrecio)
                            {
                                ap.Precio = promocion.Descuento * ap.Precio;
                            }
                            break;
                        case "R":
                            foreach (AsientoPrecio ap in listaAsientoPrecio)
                            {
                                ap.Precio = promocion.Descuento;
                            }
                            break;
                    }
                    PopularDatosReserva();
                    AsociarEntidadesReserva();
                    reserva.Promocion = promocion;
                    reserva.NombrePromocion = promocion.Descripcion;
                    AplicoPromocion = true;
                    MessageBox.Show("Descuento aplicado correctamente", "Aviso");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un descuento", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Ya aplico un descuento", "Aviso");
            }
        }
    }
}
