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

namespace ContactCenterGUI.Mantenimientos.ObraC
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
                obra.Nombre = txtObra.Text;
                obra.FechaInicio = dtpInicio.Value.Date;
                obra.FechaFin = dtpFin.Value.Date;
                obra.Descripcion = txtDescripcion.Text;
                obra.Estado = cboEstado.SelectedIndex == 0?"A":"I";
                obra.Teatro = cboTeatro.SelectedItem as Teatro;
            if(servicio.InsertarObra(obra) == true) {

                MessageBox.Show("Obra registrada correctamente");
                this.Close();
            } else {

                MessageBox.Show("ERROR", "ERROR");
            }


            
        }

        private void ManPlayCreate_Load(object sender, EventArgs e)
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            cboEstado.SelectedIndex = 0;
        }

    }
}
