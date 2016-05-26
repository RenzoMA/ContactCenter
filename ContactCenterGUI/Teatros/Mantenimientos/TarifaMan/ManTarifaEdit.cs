using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.TarifaMan
{
    public partial class ManTarifaEdit : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Tarifa tarifa = null;
        private List<Tarifa> listaTarifa;
        private Teatro teatro = null;
        private List<Teatro> listaTeatro;
        private Obra obra = null;
        private Zona zona = null;
        private List<Obra> listaObra;
        private List<Zona> listaZona;

        public ManTarifaEdit(Tarifa tarifa)
        {
            this.tarifa = tarifa;
            InitializeComponent();
        }

        private void ManTarifaEdit_Load(object sender, EventArgs e)
        {
            InicializarControles();
            SetEventos();
            LoadData();
        }

        private void InicializarControles()
        {
            cboObra.Enabled = false;
            cboTeatro.Enabled = false;
            cboZona.Enabled = false;
        }
        private void LoadData()
        {
            cboTeatro.SelectedIndex = tarifa.Obra.Teatro.IdTeatro;
            cboTeatro.DisplayMember = "Nombre";
            cboObra.SelectedItem = tarifa.Obra.Nombre;
            cboZona.SelectedItem = tarifa.Zona.Nombre;
            txtPrecio.Text = tarifa.Precio.ToString();
        }

        private void CapturarDatos()
        {
            obra = cboObra.SelectedItem as Obra;
            zona = cboZona.SelectedItem as Zona;

            Tarifa tarifa = new Tarifa()
            {
                Obra = obra,
                Zona = zona,
                Precio = Convert.ToSingle(txtPrecio.Text)
            };
        }
        private void SetEventos()
        {
            txtPrecio.KeyPress += HelperControl.EditTextDecimal;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            servicio.Uptade(tarifa);
        }
    }
}
