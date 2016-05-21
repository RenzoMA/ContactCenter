using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;



namespace ContactCenterGUI.Mantenimientos.Tarifa
{
    public partial class manFareCreate : MaterialForm
    {
        private Teatro teatro = null;
        private List<Teatro> listaTeatro;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        private List<Zona> listaZona = null;
        private Zona zona = null;



        public manFareCreate()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

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
            CargarZona();
            CargarObras();
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

        private void CargarZona()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaZona = servicio.ListZonaByTeatro(teatro.IdTeatro);
                cboZona.DataSource = listaZona;
                cboZona.DisplayMember = "Nombre";
            }
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarTeatros();
        }
    }
}
