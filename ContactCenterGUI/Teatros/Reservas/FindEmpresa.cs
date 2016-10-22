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
using Microsoft.Practices.Unity;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;

namespace ContactCenterGUI.Teatros.Reservas
{
    public partial class FindEmpresa : MaterialForm
    {
        public static Empresa empresa;
        public FindEmpresa()
        {
            InitializeComponent();
        }

        private async void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                List<Empresa> listaEmpresa = await servicio.ListEmpresa(txtNombreEmpresa.Text);
                lstEmpresas.DataSource = listaEmpresa.Where(tx => tx.Estado == "A").ToList();
                lstEmpresas.DisplayMember = "Nombre";
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            if (lstEmpresas.SelectedItems.Count > 0)
            {
                empresa = lstEmpresas.SelectedItem as Empresa;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una empresa", "Aviso");
            }
        }
    }
}
