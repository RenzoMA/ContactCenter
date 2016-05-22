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


namespace ContactCenterGUI.Mantenimientos.ObraMan
{
    public partial class ManPlayFind : MaterialForm
    {

        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManPlayFind()
        {
            InitializeComponent();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            Obra obra = servicio.BuscarObraPorNombre(txt.Text);

            if (obra == null)
            {
                MessageBox.Show("La obra ingresada no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dtpInicio.Text = obra.FechaInicio.ToShortDateString();
                dtpFin.Text = obra.FechaFin.ToShortDateString();
                txtDescripcion.Text = obra.Descripcion.ToString();
                cboTeatro.Text = obra.Teatro.Nombre.ToString();
                cboEstado.Text = obra.Estado.ToString();
            }
        }

        private void ManPlayFind_Load(object sender, EventArgs e)
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            cboEstado.SelectedIndex = 0;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Obra obraa  = new Obra();
            obraa.FechaInicio = dtpInicio.Value.Date;
            obraa.FechaFin = dtpFin.Value.Date;
            obraa.Descripcion = txtDescripcion.Text;
            obraa.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
            obraa.Teatro = cboTeatro.SelectedItem as Teatro;

            if (servicio.ActualizarObra(obraa) == true)
            {

                MessageBox.Show("Obra registrada correctamente");
                this.Close();
            }
            else
            {

                MessageBox.Show("ERROR", "ERROR");
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Obra obrae = servicio.BuscarObraPorNombre(txt.Text);

            if (servicio.EliminarObra(obrae.IdObra) == true) {
                MessageBox.Show("Obra eliminada correctamente");
                this.Close();
            }
            else
            {

                MessageBox.Show("ERROR", "ERROR");
            }
        }
    }
}
