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
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManObra : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        public ManObra()
        {
            InitializeComponent();
            
        }


        private void btnNuevaObra_Click(object sender, EventArgs e)
        {
            ManObraCrear manPlayCreate = new ManObraCrear();
            manPlayCreate.ShowDialog();
            llenarGrilla();
        }

        private void ManObra_Load(object sender, EventArgs e)
        {
            CargarTeatros();
            ConfigurarGrilla();
        }

        private void CargarTeatros() {
            try
            {
                cboTeFilObra.DataSource = servicio.ListarTeatros();
                cboTeFilObra.DisplayMember = "Nombre";
                //cboTeFilObra.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla() {
            dgvObras.AutoGenerateColumns = false;
        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {
            llenarGrilla();
        }

        private void llenarGrilla() {
            try { 
            Teatro Teatro = cboTeFilObra.SelectedItem as Teatro;
            dgvObras.DataSource = servicio.ListarObraByTeatro(Teatro.IdTeatro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvObras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Obra obra = (Obra)dgvObras.CurrentRow.DataBoundItem;
                ManObraEditar manObraEditar = new ManObraEditar(obra);
                manObraEditar.ShowDialog();
                llenarGrilla();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
