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
using MaterialSkin.Animations;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Mantenimientos.Funcion
{
    public partial class ManFunctionCreate : MaterialForm
    {
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        public ManFunctionCreate()
        {
            InitializeComponent();
        }

        private void ManFunctionCreate_Load(object sender, EventArgs e)
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";

        }

        private void CargarObras()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                cboObra.DataSource = listaObra;
                cboObra.DisplayMember = "Nombre";
            };
        }

        private void cboObra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CargarObras();
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
        }
    }
}