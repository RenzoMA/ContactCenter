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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterGUI.CC.Helpers;


namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    public partial class ManFuncionCreate : MaterialForm
    {
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        private Teatro teatro = null;
        private List<Teatro> listaTeatro;

        private List<Obra> listaObra = null;
        private Obra obra = null;


        public ManFuncionCreate()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearTarifa();
        }

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtHoarario.Text) ||
            cboTeatro.SelectedIndex == 0 || cboObra.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, ingrese los datos correctamente", "Aviso");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void CargarTeatros()
        {
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaTeatro = await servicio.ListarTeatrosAsync();
                cboTeatro.DataSource = listaTeatro;
                cboTeatro.DisplayMember = "Nombre";
            }
            CargarObras();
        }

        private void CargarObras()
        {
            teatro = cboTeatro.SelectedItem as Teatro;
            using (IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>())
            {
                listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                cboObra.DataSource = listaObra;
                cboObra.DisplayMember = "Nombre";
            }
        }

        public void CrearTarifa()
        {

            obra = cboObra.SelectedItem as Obra;

            Funcion funcion = new Funcion()
            {
                Dia = Convert.ToInt32(cboDia.SelectedIndex),
                Horario = txtHoarario.Text,
                Obra = obra,
                Estado = "A"
            };

            if (servicio.InsertarFuncion(funcion))
            {
                MessageBox.Show("Función creada correctamente", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManFuncionCreate_Load(object sender, EventArgs e)
        {
            CargarTeatros();
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
        }
    }
}
