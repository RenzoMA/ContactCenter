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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManObra : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManObra()
        {
            InitializeComponent();
        }


        private void btnNuevaObra_Click(object sender, EventArgs e)
        {
            ManPlayCreate manPlayCreate = new ManPlayCreate();
            manPlayCreate.ShowDialog();
        }

        private void ManObra_Load(object sender, EventArgs e)
        {
            CargarTeatros();
            ConfigurarGrilla();
        }

        private void CargarTeatros() {
            cboTeFilObra.DataSource = servicio.ListarTeatros();
            cboTeFilObra.DisplayMember = "Nombre";
            cboTeFilObra.SelectedIndex = 0;
        }

        private void ConfigurarGrilla() {
            dgvObras.AutoGenerateColumns = false;
        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {
            llenarGrilla();
        }

        private void llenarGrilla() {


        }
    }
}
