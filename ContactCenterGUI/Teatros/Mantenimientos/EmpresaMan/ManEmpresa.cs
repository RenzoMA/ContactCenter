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
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.EmpresaMan
{
    public partial class ManEmpresa : MaterialForm
    {
        public ManEmpresa()
        {
            InitializeComponent();
            dgvEmpresa.AutoGenerateColumns = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManEmpresaCreate manCreate = new ManEmpresaCreate();
            manCreate.ShowDialog();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                dgvEmpresa.DataSource = await servicio.ListEmpresa(txtNombreEmpresa.Text);
            }
        }

        private void dgvEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Empresa empresa = (Empresa)dgvEmpresa.CurrentRow.DataBoundItem;
                ManEmpresaEdit manEmpresaEdit = new ManEmpresaEdit(empresa);
                manEmpresaEdit.ShowDialog();
            }
        }
    }
}
