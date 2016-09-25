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
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocion : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private bool isProcessing = false;
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
            try { 
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            LoadComboObra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboObra()
        {
            Teatro teatro = cboTeatro.SelectedItem as Teatro;
            cboObra.DataSource = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DisplayMember = "Nombre";
        }
        private void ConfigurarGrilla()
        {
            dgvPromociones.AutoGenerateColumns = false;
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboObra();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!isProcessing)
            {
                EnlazarGrilla();
            }
        }
        private async void EnlazarGrilla()
        {
            isProcessing = true;
            Animacion.ShowLoader(this);
            try {
                Obra obra = cboObra.SelectedItem as Obra;
                dgvPromociones.DataSource = await servicio.ListPromocionByObraAsync(obra.IdObra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Animacion.HideLoader(this);
            isProcessing = false;
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManPromocionCreate create = new ManPromocionCreate();
            create.ShowDialog();
            EnlazarGrilla();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
