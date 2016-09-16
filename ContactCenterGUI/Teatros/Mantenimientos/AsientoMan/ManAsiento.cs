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
using ContactCenterServices.ServicioTeatro;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.AsientoMan
{
    public partial class ManAsiento : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private Zona zona;
        private Teatro teatro;
        private Obra obra;

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
            AsociarObra();
        }
        private void AsociarZona()
        {
            obra = cboObra.SelectedItem as Obra;
            cboZona.DataSource = servicio.ComboListZonaByObra(obra.IdObra).Where(x => x.Estado == "Activo").ToList();
            cboZona.DisplayMember = "Nombre";
            zona = cboZona.SelectedItem as Zona;

        }
        private void AsociarObra()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                cboObra.DataSource = servicio.ComboListarObraByTeatro(teatro.IdTeatro);
                cboObra.DisplayMember = "Nombre";
                AsociarZona();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AsociarObra();
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
            try
            {
                zona = cboZona.SelectedItem as Zona;
                dgvAsientos.DataSource = servicio.ListAsientoByZona(zona.IdZona);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!cadenaIds.Equals(String.Empty))
            {
                cadenaIds = cadenaIds.Substring(0, cadenaIds.Length - 1);
            }
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
            try
            {
                if (ValidarSeleccionado())
                {
                    if (servicio.UpdateAsientoDisponible(CapturarSeleccionados(), "N", zona.IdZona))
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
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado())
            {
                if (servicio.UpdateAsientoDisponible(CapturarSeleccionados(), "S", zona.IdZona))
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

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAsientos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = (chk.Value == null ? true : Convert.ToBoolean(chk.Value) == false ? true : false);
            }
        }

        private void cboObra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AsociarZona();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (ValidarSeleccionado())
            {
                if (servicio.EliminarAsientoDisponible(CapturarSeleccionados(), zona.IdZona))
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (zona.IdZona != 0 & teatro.IdTeatro != 0 && obra.IdObra != 0)
            {
                ManAsientoZona manAsientoZona = new ManAsientoZona(teatro, obra, zona);
                manAsientoZona.ShowDialog();
                EnlazarDataGrid();
            }
            else
            {
                MessageBox.Show("Seleccione todos los campos", "Aviso");
            }
        }

        private void cboZona_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnlazarDataGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
