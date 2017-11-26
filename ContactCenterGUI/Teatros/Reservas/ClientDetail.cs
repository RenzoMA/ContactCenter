using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using ContactCenterServices.ServicioTeatro;
using MaterialSkin.Controls;
using Microsoft.Practices.Unity;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class ClientDetail : MaterialForm
    {
        Reserva reserva = new Reserva();
        public ClientDetail()
        {
            InitializeComponent();
            setEventos();
            ConfirmReservation.previousForms.RemoveAll(x => true);
            ConfirmReservation.previousForms.Add(this);
        }

        public ClientDetail(string telefono)
        {
            InitializeComponent();
            setEventos();
            ConfirmReservation.previousForms.RemoveAll(x => true);
            ConfirmReservation.previousForms.Add(this);
            txtTelefono.Text = telefono.ToUpper().Trim();
            ObtenerCliente();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                reserva.Cliente = CapturarDataCliente();
                NewReservation newReservation = new NewReservation(reserva);
                this.Hide();
                newReservation.ShowDialog();
                this.Show();


            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso");
            }

        }
        private bool isValid()
        {
            if (txtApeMat.Text.Trim().Equals(String.Empty))
                return false;
            if (txtApePat.Text.Trim().Equals(String.Empty))
                return false;
            if (txtNombre.Text.Trim().Equals(String.Empty))
                return false;
            if (txtTelefono.Text.Trim().Equals(String.Empty))
                return false;
            return true;
        }
        public Cliente CapturarDataCliente()
        {
            Cliente cliente = new Cliente()
            {
                Apellidomaterno = txtApeMat.Text.ToUpper().Trim(),
                ApellidoPaterno = txtApePat.Text.ToUpper().Trim(),
                Nombre = txtNombre.Text.ToUpper().Trim(),
                Correo = ConfirmReservation.Correo,
                Telefono = txtTelefono.Text.ToUpper().Trim()
            };
            return cliente;
        }

        /// <summary>
        /// Get client from database
        /// </summary>
        private async void ObtenerCliente()
        {
            Animacion.ShowLoader(this);
            try
            {
                string telefono = txtTelefono.Text.ToUpper().Trim();
                if (telefono != "")
                {
                    IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();

                    Cliente cliente = await servicio.GetClienteByTelefonoAsync(telefono);
                    if (cliente != null)
                    {
                        txtApeMat.Text = cliente.Apellidomaterno;
                        txtApePat.Text = cliente.ApellidoPaterno;
                        txtNombre.Text = cliente.Nombre;
                        txtTelefono.Text = cliente.Telefono;
                        ConfirmReservation.Correo = cliente.Correo;
                    }
                    else
                    {
                        ClearFields();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Animacion.HideLoader(this);
        }

        void setEventos()
        {
            txtNombre.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApeMat.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtApePat.KeyPress += new KeyPressEventHandler(HelperControl.EditTextToUpper);
            txtTelefono.KeyPress += new KeyPressEventHandler(HelperControl.EditTextNumber);
        }

        /// <summary>
        /// Clear fields
        /// </summary>
        private void ClearFields()
        {
            txtApeMat.Text = "";
            txtApePat.Text = "";
            txtNombre.Text = "";
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ObtenerCliente();
            }
        }
    }
}
