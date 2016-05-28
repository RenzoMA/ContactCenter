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
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManObraEditar : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Obra obra;
        private List<Teatro> listaTeatro;

        public ManObraEditar(Obra obra)
        {
            this.obra = obra;
            InitializeComponent();
        }

        private void ManObraEditar_Load(object sender, EventArgs e)
        {
            cargarData();
        }

        private void cargarData() {

            lblObraNom.Text = obra.Nombre;
            dtpFecIniObra.Value = obra.FechaInicio;
            dtpFecFinObra.Value = obra.FechaFin;
            cboEstadoObra.SelectedIndex = obra.Estado == "Activo" ? 0 : 1;
            listaTeatro = servicio.ListarTeatros();
            cboTeatroObra.DataSource = listaTeatro;
            cboTeatroObra.DisplayMember = "Nombre";
            cboTeatroObra.SelectedItem = FindTeatro(obra.Teatro.IdTeatro);
            txtDescripcionObra.Text = obra.Descripcion;
        }

        private Teatro FindTeatro(int idTeatro)
        {
            return listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
        }

        private void CapturarDatos()
        {
            obra.Nombre = lblObraNom.Text;
            obra.FechaInicio = dtpFecIniObra.Value.Date;
            obra.FechaFin = dtpFecFinObra.Value.Date;
            obra.Descripcion = txtDescripcionObra.Text;
            obra.Estado = cboEstadoObra.SelectedIndex == 0 ? "A" : "I";
            obra.Teatro = cboTeatroObra.SelectedItem as Teatro;
            
        }

        private bool ValidarDatos()
        {
            if (txtDescripcionObra.Text.ToUpper().Trim().Equals(string.Empty))
                return false;
            
            return true;

        }
        private void btnAceptarObra_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            if (ValidarDatos())
            {
                if (servicio.ActualizarObra(obra))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Completar todos los campos", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
