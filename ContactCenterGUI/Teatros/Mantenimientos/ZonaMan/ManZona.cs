using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.ZonaMan
{
    public partial class ManZona : MaterialForm
    {
        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        public ManZona()
        {
            InitializeComponent();
            dgvTarifa.AutoGenerateColumns = false;
        }
        private async void CargarTeatros()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    Animacion.ShowLoader(this);
                    listaTeatro = await servicio.ListarTeatrosAsync();
                    Animacion.HideLoader(this);
                    cboTeatro.DataSource = listaTeatro;
                    cboTeatro.DisplayMember = "Nombre";
                }
                CargarObras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarObras()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                    cboObra.DataSource = listaObra;
                    cboObra.DisplayMember = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            obra = cboObra.SelectedItem as Obra;
            if (obra.IdObra > 0)
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {

                    dgvTarifa.DataSource = servicio.ListZonaByObra(obra.IdObra);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una obra", "Aviso");
            }
        }

        private void ManZona_Load(object sender, EventArgs e)
        {
            CargarTeatros();
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarObras();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManZonaCreate zona = new ManZonaCreate();
            zona.ShowDialog();

        }

        private void dgvTarifa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Zona zona = (Zona)dgvTarifa.CurrentRow.DataBoundItem;
                ManZonaEdit manZonaEdit = new ManZonaEdit(zona);
                manZonaEdit.ShowDialog();
            }
        }
    }
}
