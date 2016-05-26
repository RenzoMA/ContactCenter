using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
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
        private Obra obra =  null;
        private List<Obra> listaObra;
        private List<Zona> listaZona;

        public ManTarifaEdit(Tarifa tarifa)
        {
            this.tarifa = tarifa;
            InitializeComponent();
        }

        private void InicializarControles()
        {
            cboObra.Enabled = false;
            cboTeatro.Enabled = false;
            cboZona.Enabled = false;
        }
        private void LoadData()
        {
            cboTeatro.SelectedItem = tarifa.Obra.Teatro.Nombre;
            cboObra.SelectedItem = tarifa.Obra.Nombre;
            cboZona.SelectedItem = tarifa.Zona.Nombre;
            txtPrecio.Text = tarifa.Precio.ToString();
        }
        private void SetEventos()
        {
            txtPrecio.KeyPress += HelperControl.EditTextDecimal;
        }

        private void ManTarifaEdit_Load(object sender, EventArgs e)
        {
            //LoadData();
            InicializarControles();
            SetEventos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
