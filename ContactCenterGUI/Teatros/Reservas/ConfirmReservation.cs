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
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterServices.ServicioTeatro;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.Teatros.Helpers;
using Microsoft.Practices.Unity;
using ContactCenterServices;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class ConfirmReservation : MaterialForm
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
        private String asientos;
        private TimeSpan span;


        public ConfirmReservation()
        {
            InitializeComponent();
        }
        public ConfirmReservation(Form form,Reserva _reserva,TimeSpan timespan)
        {
            InitializeComponent();
            timerConfirmacion.Enabled = true;
            timerConfirmacion.Interval = 1000;
            span = timespan.Subtract(TimeSpan.Parse("00:00:01"));
            reserva = _reserva;
            frmTeatro = form;
            frmTeatro.Visible = false;
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
            dgvDetalleAsientos.Rows.Clear();
            int contador = 0;
            string result = "";
            foreach (AsientoPrecio obj in lista)
            {
                contador++;
                result += obj.Fila + " - " +obj.Descripcion + ", ";
                dgvDetalleAsientos.Rows.Add(obj.Zona.Descripcion, obj.Fila, obj.Descripcion);
                
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        private void PopularDatosReserva()
        {
            precioTotal = CalcularPrecio(listaAsientoPrecio);
            lblPrecio.Text = "S/. " + precioTotal.ToString();
            asientos = GenerarAsiento(listaAsientoPrecio);
            lblObra.Text = reserva.Obra.Nombre;
            lblFuncion.Text = reserva.Funcion.Horario;
            lblTeatro.Text = reserva.Obra.Teatro.Nombre;
            lblFecha.Text = reserva.FechaReserva.ToShortDateString();
            
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
            reserva.Asientos = asientos;
            reserva.ListaDetalles = listaDetalle;
            reserva.PrecioTotal = precioTotal;
        }
        private void LoadCombos()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    cboTipoPromocion.DataSource = servicio.GetListaTipoPromocion();
                    cboTipoPromocion.DisplayMember = "Descripcion";
                    EnlazarDetallePromocion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                Animacion.ShowLoader(this);
                IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
                bool resultado = await servicio.InsertarReservaAsync(reserva, cliente);
                Animacion.HideLoader(this);
                if (resultado)
                {
                    MessageBox.Show("Reserva realizada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTeatro.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se registro la reserva!!!", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            ObtenerCliente();
        }
        private async void ObtenerCliente()
        {
            try
            {
                string telefono = txtTelefono.Text.ToUpper().Trim();
                if (telefono != "")
                {
                    IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            validaSalida = 1;
            frmTeatro.Visible = true;
            this.Close();
        }
        private void EnlazarDetallePromocion()
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                TipoPromocion tipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
                cboPromocion.DataSource = servicio.ListPromocionByFuncionTipoPromo(reserva.Funcion.IdFuncion, tipoPromocion.IdTipoPromocion);
                cboPromocion.DisplayMember = "Descripcion";
            }
        }
        private void cboTipoPromocion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnlazarDetallePromocion();
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

        private void timerConfirmacion_Tick(object sender, EventArgs e)
        {
            span = span.Subtract(TimeSpan.Parse("00:00:01"));
            lblTiempo.Text = span.ToString();
            if (span.Hours == 0 && span.Minutes == 0 && span.Seconds == 0)
            {
                this.Close();
            }
        }
    }
}
