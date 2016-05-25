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
    public partial class ManPlayCreate : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        public ManPlayCreate()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            

                Obra obra = new Obra();
                obra.Nombre = txtNomObra.Text;
                obra.FechaInicio = dtpFecIniObra.Value.Date;
                obra.FechaFin = dtpFecFinObra.Value.Date;
                obra.Descripcion = txtDescripcionObra.Text;
                obra.Estado = cboEstadoObra.SelectedIndex == 0?"A":"I";
                obra.Teatro = cboTeatroObra.SelectedItem as Teatro;
            if(servicio.InsertarObra(obra) == true) {

                MessageBox.Show("Obra registrada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {

                MessageBox.Show("Error al registrar la reserva. Intentelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }

        private void ManPlayCreate_Load(object sender, EventArgs e)
        {
            cboTeatroObra.DataSource = servicio.ListarTeatros();
            cboTeatroObra.DisplayMember = "Nombre";
            cboEstadoObra.SelectedIndex = 0;
        }

    }
}
