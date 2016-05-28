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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Teatros.Mantenimientos.ObraMan
{
    public partial class ManObraCrear : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        public ManObraCrear()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                Obra obra = new Obra();
                obra.Nombre = txtNomObra.Text;
                obra.FechaInicio = dtpFecIniObra.Value.Date;
                obra.FechaFin = dtpFecFinObra.Value.Date;
                obra.Descripcion = txtDescripcionObra.Text;
                obra.Estado = cboEstadoObra.SelectedIndex == 0 ? "A" : "I";
                obra.Teatro = cboTeatroObra.SelectedItem as Teatro;
                if (servicio.InsertarObra(obra) == true)
                {

                    MessageBox.Show("Proceso realizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else
            {
                MessageBox.Show("Completar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

       

        private bool ValidarDatos()
        {
            if (txtNomObra.Text.ToUpper().Trim().Equals(string.Empty))
                return false;
            if (txtDescripcionObra.Text.ToUpper().Trim().Equals(string.Empty))
                return false;
            if (cboEstadoObra.SelectedIndex == 0)
                return false;
            if (cboTeatroObra.SelectedIndex == 0)
                return false;

            return true;

        }
        private void ManPlayCreate_Load(object sender, EventArgs e)
        {
            cboTeatroObra.DataSource = servicio.ListarTeatros();
            cboTeatroObra.DisplayMember = "Nombre";
            cboEstadoObra.SelectedIndex = 0;
        }

    }
}
