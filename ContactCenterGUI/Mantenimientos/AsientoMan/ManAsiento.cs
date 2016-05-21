using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using MaterialSkin.Controls;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

namespace ContactCenterGUI.Mantenimientos.AsientoMan
{
    public partial class ManAsiento : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Zona zona;
        public ManAsiento()
        {
            InitializeComponent();
        }

        private void ManAsiento_Load(object sender, EventArgs e)
        {
            dgvAsientos.AutoGenerateColumns = false;
            AsociarTeatro();
        }

        private void AsociarTeatro()
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            AsociarZona();
        }
        private void AsociarZona()
        {
            Teatro teatro = cboTeatro.SelectedItem as Teatro;
            cboZona.DataSource = servicio.ListZonaByTeatro(teatro.IdTeatro);
            cboZona.DisplayMember = "Nombre";
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AsociarZona();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboTeatro.SelectedIndex != 0)
            {
                EnlazarDataGrid();
            }
        }
        private void EnlazarDataGrid()
        {
            zona = cboZona.SelectedItem as Zona;
            dgvAsientos.DataSource = servicio.ListAsientoByZona(zona.IdZona);
        }

        private void dgvAsientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dgvAsientos.Rows[e.RowIndex].Cells[0].Value))
                {
                    dgvAsientos.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    dgvAsientos.Rows[e.RowIndex].Cells[0].Value = true;
                }
                
            }
        }
        private string CapturarSeleccionados()
        {
            string cadenaIds = "";
            foreach (DataGridViewRow row in dgvAsientos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    cadenaIds += row.Cells[1].Value.ToString() + ",";
                }
            }
            cadenaIds = cadenaIds.Substring(0, cadenaIds.Length-1);
            return cadenaIds;
        }
        private bool ValidarSeleccionado()
        {
            if (CapturarSeleccionados().Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar algun asiento", "Aviso");
                return false;
            }
            return true;
                
            
        }
        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado())
            {
                if (servicio.UpdateAsientoDisponible(CapturarSeleccionados(), "N"))
                {
                    MessageBox.Show("Proceso correcto");
                    EnlazarDataGrid();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado())
            {
                if (servicio.UpdateAsientoDisponible(CapturarSeleccionados(), "S"))
                {
                    MessageBox.Show("Proceso correcto");
                    EnlazarDataGrid();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
