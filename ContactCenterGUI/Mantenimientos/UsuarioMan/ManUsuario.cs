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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterGUI.Mantenimientos.UsuarioMan
{
    public partial class ManUsuario : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private string userName;
        public ManUsuario()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }
        private void capturarDatos()
        {
            userName = txtNombre.Text.ToUpper().Trim();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            ManCreateUpdateUsuario createUsuario = new ManCreateUpdateUsuario(true);
            createUsuario.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            capturarDatos();
            dgvUsuarios.DataSource = servicio.SearchUsuarioByName(userName);
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Usuario usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                ManCreateUpdateUsuario createUsuario = new ManCreateUpdateUsuario(false, usuario);
                createUsuario.ShowDialog();
                dgvUsuarios.DataSource = servicio.SearchUsuarioByName(userName);
            }
        }
    }
}
