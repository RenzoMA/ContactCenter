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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;

namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifaCreate : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        private Teatro teatro = null;
        private List<Teatro> listaTeatro;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        private List<Zona> listaZona = null;
        private Zona zona = null;

        private Single precio = 0;

        public ManTarifaCreate()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        public void CrearTarifa()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            obra = cboObra.SelectedItem as Obra;

            Tarifa tarifa = new Tarifa()
            {
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

        private void manFareCreate_Load(object sender, EventArgs e)
        {
            CargarTeatros();
        }

        private async void CargarTeatros()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaTeatro = await servicio.ListarTeatrosAsync();
                cboTeatro.DataSource = listaTeatro;
                cboTeatro.DisplayMember = "Nombre";
            }
            CargarObras();
            CargarZonas();
        }

        private void CargarObras()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                cboObra.DataSource = listaObra;
                cboObra.DisplayMember = "Nombre";
            }
        }

        private void CargarZonas()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaZona = servicio.ListZonaByTeatro(teatro.IdTeatro);
                cboZona.DataSource = listaZona;
                cboZona.DisplayMember = "Nombre";
            }
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
            CargarZonas();
        }
    }
}
