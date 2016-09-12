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
using ContactCenterServices.ServicioContactCenter;
using ContactCenterServices;
using MaterialSkin.Animations;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.AplicacionBE;


namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    public partial class ManAplicacion : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        public ManAplicacion()
        {
            InitializeComponent();
            dgbAplicacion.AutoGenerateColumns = false;
        }

        private void EnlazarGrilla()
        {
            try
            {
                dgbAplicacion.DataSource = servicio.ListarAplicaciones();
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgbAplicacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Aplicacion aplicacion = (Aplicacion)dgbAplicacion.CurrentRow.DataBoundItem;
                ManAplicacionEditar editarAplicacion = new ManAplicacionEditar(aplicacion);
                editarAplicacion.ShowDialog();
                EnlazarGrilla();
            }
        }

        private void ManAplicacion_Load(object sender, EventArgs e)
        {
            EnlazarGrilla();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
