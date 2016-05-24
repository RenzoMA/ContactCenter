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
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterServices;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocion : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManPromocion()
        {
            InitializeComponent();
        }

        private void ManFuncion_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            LoadComboTeatro();
        }
        private void LoadComboTeatro()
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            LoadComboObra();
        }
        private void LoadComboObra()
        {
            Teatro teatro = cboTeatro.SelectedItem as Teatro;
            cboObra.DataSource = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DisplayMember = "Nombre";
            LoadComboFuncion();
        }
        private void ConfigurarGrilla()
        {
            dgvPromociones.AutoGenerateColumns = false;
        }
        private void LoadComboFuncion()
        {
            Obra obra = cboObra.SelectedItem as Obra;
            cboFuncion.DataSource = servicio.ListarFuncionByObra(obra.IdObra);
            cboFuncion.DisplayMember = "Horario";
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboObra();
        }

        private void cboObra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboFuncion();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EnlazarGrilla();
        }
        private void EnlazarGrilla()
        {
            Funcion funcion = cboFuncion.SelectedItem as Funcion;
            dgvPromociones.DataSource = servicio.ListarPromocionByFuncion(funcion.IdFuncion);
        }

        private void dgvPromociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Promocion promocion = (Promocion)dgvPromociones.CurrentRow.DataBoundItem;
                ManPromocionEdit promocionEdit = new ManPromocionEdit(promocion);
                promocionEdit.ShowDialog();
                EnlazarGrilla();
            }
        }
    }
}
