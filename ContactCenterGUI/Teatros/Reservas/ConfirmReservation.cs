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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterServices.ServicioTeatro;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.Teatros.Helpers;
using Microsoft.Practices.Unity;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;
using System.IO;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class ConfirmReservation : MaterialForm
    {
        private Form frmTeatro;
        private Reserva reserva;
        private Empresa empresa;

        public List<AsientoZona> listaAsientoPrecio { get; set; }
        public List<AsientoZona> listaAsientoPrecioTemp;
        public List<DetalleReserva> listaDetalle;
        public DetalleReserva detalle;
        public Single precioTotal;
        public int validaSalida = 0;
        private String asientos;
        private TimeSpan span;
        private List<int> idZonas;
        private string promociones = "";
        private bool aplicoPromocionGeneral = false;
        private bool aplico2x1 = false;
        public static string Correo = "";
        public static List<Form> previousForms = new List<Form>();

        private static List<AsientoZona> Clonar(List<AsientoZona> lista)
        {
            List<AsientoZona> listaClonar = new List<AsientoZona>();
            foreach (AsientoZona asiento in lista)
            {
                listaClonar.Add(new AsientoZona(asiento));
            }
            return listaClonar;
        }

        public ConfirmReservation(Form form,Reserva _reserva,TimeSpan timespan)
        {
            InitializeComponent();
            InitTimer(timespan);
            SetStyles();
            LoadData(form, _reserva);
        }

        public void InitTimer(TimeSpan timeSpan)
        {
            timerConfirmacion.Enabled = true;
            timerConfirmacion.Interval = 1000;
            span = timeSpan.Subtract(TimeSpan.Parse("00:00:01"));
        }
        public void SetStyles()
        {
            btnRegresar.BackColor = ConstanteColor.GetPrimaryColor();
        }
        public void LoadData(Form form, Reserva _reserva)
        {
            idZonas = new List<int>();
            reserva = _reserva;
            frmTeatro = form;
            frmTeatro.Visible = false;
            lblTelefono.Text = reserva.Cliente.Telefono;
            lblNombre.Text = reserva.Cliente.Nombre;
            txtCorreo.Text = reserva.Cliente.Correo;
            lblApellidoPat.Text = reserva.Cliente.ApellidoPaterno;
            lblApellidoMat.Text = reserva.Cliente.Apellidomaterno;
        }


        public Single CalcularPrecio()
        {
            Single single = 0;
            foreach (AsientoZona obj in listaAsientoPrecioTemp)
            {
                single += obj.Zona.Precio;
            }
            return single;
        }

        /// <summary>
        /// Fill seats data
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public string GenerarAsiento()
        {
            dgvDetalleAsientos.Rows.Clear();
            string result = "";
            foreach (AsientoZona obj in listaAsientoPrecioTemp)
            {
                result += obj.Zona.Nombre+" / "+obj.Asiento.Fila + " / " +obj.Asiento.Descripcion + "\n";
                dgvDetalleAsientos.Rows.Add(obj.Zona.Nombre, obj.Asiento.Fila, obj.Asiento.Descripcion, obj.Zona.Precio);
            }
            int index = result.LastIndexOf('\n');
            result = result.Substring(0, index);
            return result;
            
        }

        /// <summary>
        /// String represents each sector
        /// </summary>
        /// <returns></returns>
        public string GenerarZona()
        {
            string result = "";
            foreach (AsientoZona obj in listaAsientoPrecioTemp)
            {
                result += obj.Zona.IdZona + ",";
            }
            int index = result.LastIndexOf(',');
            result = result.Substring(0, index);
            return result;
        }

        /// <summary>
        /// Fill data 
        /// </summary>
        private void PopularDatosReserva()
        {
            precioTotal = CalcularPrecio();
            lblPrecio.Text = "S/. " + precioTotal.ToString();
            asientos = GenerarAsiento();
            lblObra.Text = reserva.Obra.Nombre;
            lblFuncion.Text = reserva.Funcion.Horario;
            lblTeatro.Text = reserva.Obra.Teatro.Nombre;
            lblFecha.Text = reserva.FechaReserva.ToShortDateString();
            
        }


        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerInfoTheater_Load(object sender, EventArgs e)
        {

            listaAsientoPrecioTemp = Clonar(listaAsientoPrecio);
            SetEventos();
            PopularDatosReserva();
            AsociarEntidadesReserva();
            LoadCombos();
            
        }

        /// <summary>
        /// Set reservation details
        /// </summary>
        private void AsociarEntidadesReserva()
        {
            listaDetalle = new List<DetalleReserva>();
            reserva.ListaDetalles = null;
            foreach (AsientoZona ap in listaAsientoPrecioTemp)
            {
                detalle = new DetalleReserva();
                detalle.Asiento = ap.Asiento;
                detalle.Precio = ap.Zona.Precio;
                detalle.NombreZona = ap.Zona.Nombre;
                detalle.NombreFila = ap.Asiento.Fila;
                detalle.NombreAsiento = ap.Asiento.Descripcion;
                detalle.NombrePromocion = ap.NombrePromocion;
                listaDetalle.Add(detalle);
            }
            reserva.Asientos = asientos;
            reserva.ListaDetalles = listaDetalle;
            reserva.PrecioTotal = precioTotal;
        }

        /// <summary>
        /// fill data por tipopromocion
        /// </summary>
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
      
        /// <summary>
        /// Close and cancel reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerInfoTheater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validaSalida == 0)
            {
                frmTeatro.Close();
                HelperTeatro.CancelarReservaAsiento();
            }
        }


        /// <summary>
        /// Validate fields
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            if (txtCorreo.Text.Trim().Equals(String.Empty))
                return false;
            return true;
        }



        /// <summary>
        /// fires reservations events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReservar_Click(object sender, EventArgs e)
        {
            AsignarDatosReserva();
            if(ValidarPromocionEmpresa())
            {
                if (ValidarCampos())
                {
                    Cliente cliente = CapturarDataCliente();
                    ProcesarReserva(cliente);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Aviso");
                }
            }
            

        }

        private bool ValidarPromocionEmpresa()
        {
            if (empresa != null && !aplicoPromocionGeneral)
            {
                MessageBox.Show("Al seleccionar una empresa tambien debe seleccionar una promoción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void AsignarDatosReserva()
        {
            if (promociones.IndexOf(',') != -1)
            {
                int index = promociones.LastIndexOf(',');
                promociones = promociones.Substring(0, index);
            }
            reserva.NombrePromocion = promociones;
            if (empresa != null)
            {
                reserva.Empresa = empresa.Nombre;
                reserva.IdEmpresa = empresa.IdEmpresa;
            }
            else
            {
                reserva.Empresa = "";
            }
        }


        /// <summary>
        /// Sets Data for the client
        /// </summary>
        /// <returns></returns>
        public Cliente CapturarDataCliente()
        {
            reserva.Cliente.Correo = txtCorreo.Text.ToUpper().Trim();
            return reserva.Cliente;
        }


        /// <summary>
        /// Enable controls
        /// </summary>
        private void EnableControls()
        {
            btnReservar.Enabled = true;
        }

        /// <summary>
        /// Disable controls
        /// </summary>
        private void DisableControls()
        {
            btnReservar.Enabled = false;
        }

        /// <summary>
        /// Save Reservation to database
        /// </summary>
        /// <param name="cliente"></param>
        private async void ProcesarReserva(Cliente cliente)
        {
            DisableControls();
            Animacion.ShowLoader(this);
            try
            {
                
                IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
                bool resultado = await servicio.InsertarReservaAsync(reserva, cliente);
                
                if (resultado)
                {
                    MessageBox.Show("Reserva realizada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTeatro.Close();
                    previousForms.ForEach(x=>x.Close());
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
            EnableControls();
            Animacion.HideLoader(this);
        }

        /// <summary>
        /// Get Discounts
        /// </summary>
        private async void EnlazarDetallePromocion()
        {
            Animacion.ShowLoader(this);
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    TipoPromocion tipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
                    List<Promocion> listaPromocion = await servicio.ListPromocionByFuncionTipoPromoAsync(reserva.Funcion.IdFuncion, tipoPromocion.IdTipoPromocion, GenerarZona());
                    if(tipoPromocion.IdTipoPromocion == 3) //Tipo Empresa
                    {
                        listaPromocion.Add(new Promocion()
                        {
                            IdPromocion = -1,
                            Descripcion = "CORTESIA",
                            RequiereEmpresa = true
                        });
                    }
                    cboPromocion.DataSource = listaPromocion;

                    cboPromocion.DisplayMember = "Descripcion";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Animacion.HideLoader(this);
        }

        /// <summary>
        /// Timer for reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerConfirmacion_Tick(object sender, EventArgs e)
        {
            span = span.Subtract(TimeSpan.Parse("00:00:01"));
            lblTiempo.Text = span.ToString();
            if (span.Hours == 0 && span.Minutes == 0 && span.Seconds <= 0)
            {
                this.Close();
            }
        }


        /// <summary>
        /// Apply discount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            Promocion promocion = cboPromocion.SelectedItem as Promocion;
            string tipoPromo = cboTipoPromocion.Text;
            
            if (promocion != null)
            {

                if (promocion.RequiereEmpresa && empresa == null)
                {
                    MessageBox.Show("Debe seleccionar una empresa para aplicar este descuento", "Aviso");
                    return;
                }
                else if (!promocion.RequiereEmpresa && empresa != null)
                {
                    MessageBox.Show("No debe seleccionar una empresa para esta promoción", "Aviso");
                    return;
                }


                bool aplicoPromocion = false;
                int cantidad2x1Aplicado = 0;
                int idZonaOrigen = 0;


                foreach (AsientoZona az in listaAsientoPrecioTemp.OrderBy(tx=>tx.Zona.IdZona).ToList())
                {
                    if (!az.PromocionAplicada)
                    {
                        if (promocion.IdPromocion == -1)
                        {
                            if (empresa.Cortesias)
                            {
                                aplicoPromocion = true;
                                az.Zona.Precio = 0;
                                az.PromocionAplicada = true;
                                az.NombrePromocion = promocion.Descripcion;
                                //Filtrar zonas con promocion para cadena en cabecera reserva
                                if (idZonas.IndexOf(az.Zona.IdZona) == -1)
                                {
                                    idZonas.Add(az.Zona.IdZona);
                                    promociones += promocion.Descripcion + ",";
                                }
                                aplicoPromocionGeneral = true;
                            }
                            else
                            {
                                MessageBox.Show("La empresa seleccionada no acepta cortesias", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else if (tipoPromo == "2 X 1")
                        {
                            if (!aplico2x1)
                            {
                                PromocionZona pzona = promocion.PromocionZonas.Where(tx => tx.Zona.IdZona == az.Zona.IdZona).FirstOrDefault();
                                if (pzona != null)
                                {
                                    if (idZonaOrigen == 0)
                                    {
                                        idZonaOrigen = az.Zona.IdZona;
                                    }
                                    else
                                    {
                                        if(idZonaOrigen != az.Zona.IdZona)
                                        {
                                            cantidad2x1Aplicado = 0;
                                            idZonaOrigen = az.Zona.IdZona;
                                        }
                                    }
                                    int cantidadAsientosZona = listaAsientoPrecioTemp.Where(tx => tx.Zona.IdZona == az.Zona.IdZona).Count();
                                    double cantidadMaxima = cantidadAsientosZona / 2;

                                    if (cantidadMaxima >= 1 && cantidad2x1Aplicado < cantidadMaxima * 2)
                                    {
                                        cantidad2x1Aplicado++;
                                        aplicoPromocion = true;
                                        az.Zona.Precio = pzona.Precio;
                                        az.PromocionAplicada = true;
                                        az.NombrePromocion = promocion.Descripcion;
                                        //Filtrar zonas con promocion para cadena en cabecera reserva
                                        if (idZonas.IndexOf(az.Zona.IdZona) == -1)
                                        {
                                            idZonas.Add(az.Zona.IdZona);
                                            promociones += promocion.Descripcion + ",";
                                        }
                                        aplicoPromocionGeneral = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            PromocionZona pzona = promocion.PromocionZonas.Where(tx => tx.Zona.IdZona == az.Zona.IdZona).FirstOrDefault();
                            if (pzona != null)
                            {

                                aplicoPromocion = true;
                                az.Zona.Precio = pzona.Precio;
                                az.PromocionAplicada = true;
                                az.NombrePromocion = promocion.Descripcion;
                                //Filtrar zonas con promocion para cadena en cabecera reserva
                                if (idZonas.IndexOf(az.Zona.IdZona) == -1)
                                {
                                    idZonas.Add(az.Zona.IdZona);
                                    promociones += promocion.Descripcion + ",";
                                }
                                aplicoPromocionGeneral = true;
                            }
                        }
                    }
                }
                

                
                if (aplicoPromocion)
                {
                    if (tipoPromo == "2 X 1")
                    {
                        aplico2x1 = true;
                    }
                    PopularDatosReserva();
                    AsociarEntidadesReserva();
                    MessageBox.Show("Descuento aplicado correctamente", "Aviso");
                }
                else
                {
                    MessageBox.Show("No se encontraron mas descuentos que aplicar", "Aviso");
                }
            }

            else
            {
                MessageBox.Show("Debe seleccionar un descuento", "Aviso");
            }
        }

        /// <summary>
        /// Save static data
        /// </summary>
        private void SetData()
        {
            Correo = txtCorreo.Text.ToUpper().Trim();
        }

        /// <summary>
        /// Shows teather form
        /// </summary>
        private void ShowTeatro()
        {
            frmTeatro.Visible = true;
        }

        /// <summary>
        /// Back to teather screen
        /// </summary>
        /// <param name="sender">Control</param>
        /// <param name="e">Event</param>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            validaSalida = 1;
            SetData();
            ShowTeatro();
            this.Close();
        }

        /// <summary>
        /// Fires when element is selected
        /// </summary>
        /// <param name="sender">Control</param>
        /// <param name="e">Event</param>
        private void cboTipoPromocion_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            EnlazarDetallePromocion();
        }


        /// <summary>
        /// Control events
        /// </summary>
        private void SetEventos()
        {
            txtCorreo.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtCorreo.Validating += new CancelEventHandler(HelperControl.ValidEmail);
            txtNombreEmpresa.KeyPress += new KeyPressEventHandler(HelperControl.EditTextNumber);
        }

        private void btnBuscarEmpresa_Click(object sender, EventArgs e)
        {
            FindEmpresa frmFindEmpresa = new FindEmpresa();
            frmFindEmpresa.ShowDialog();
            empresa = FindEmpresa.empresa;
            if (empresa != null)
            {
                txtNombreEmpresa.Text = empresa.Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!aplicoPromocionGeneral)
            {
                empresa = null;
                txtNombreEmpresa.Text = "";
            }
            else
            {
                MessageBox.Show("No puede eliminar la empresa luego de aplicar una promoción", "Aviso");
            }
        }
    }
}
