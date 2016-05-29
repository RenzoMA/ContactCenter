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
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;


namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifaCreate : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();

        private Teatro teatro = null;
        private List<Teatro> listaTeatro;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        private List<Zona> listaZona = null;
        private Zona zona = null;


        public ManTarifaCreate()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                CrearTarifa();
            }
        }
        
        private bool Validar()
        {
            if(txtPrecio.Text.Trim().Equals(String.Empty) ||
            cboTeatro.SelectedIndex == 0 || cboObra.SelectedIndex == 0 || cboZona.SelectedIndex == 0)
            {
              MessageBox.Show("Complete los campos", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Error);  
              return false;
            }
            else
            {
                return true;
            }
        }
        public void CrearTarifa()
        {
            try
            {
                obra = cboObra.SelectedItem as Obra;
                zona = cboZona.SelectedItem as Zona;

                Tarifa tarifa = new Tarifa()
                {
                    Obra = obra,
                    Zona = zona,
                    Precio = Convert.ToSingle(txtPrecio.Text)
                };

                if (servicio.InsertarTarifa(tarifa))
                {
                    MessageBox.Show("Tarifa creada correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void manFareCreate_Load(object sender, EventArgs e)
        {
            CargarTeatros();
            SetEventos();
        }

        private async void CargarTeatros()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaTeatro = await servicio.ListarTeatrosAsync();
                    cboTeatro.DataSource = listaTeatro;
                    cboTeatro.DisplayMember = "Nombre";
                }
                CargarObras();
                CargarZonas();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarObras()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                    cboObra.DataSource = listaObra;
                    cboObra.DisplayMember = "Nombre";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarZonas()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaZona = servicio.ListZonaByTeatro(teatro.IdTeatro);
                    cboZona.DataSource = listaZona;
                    cboZona.DisplayMember = "Nombre";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
            CargarZonas();
        }
        
        private void SetEventos()
        {
            txtPrecio.KeyPress += HelperControl.EditTextDecimal;
        }
    }
}
