using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using MaterialSkin.Controls;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using ContactCenterGUI.CC.Helpers;

namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    public partial class ManFuncionEdit : MaterialForm
    {
        Funcion funcion = null;
        private IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
        private Teatro teatro = null;
        private List<Teatro> listaTeatro;
        private Obra obra = null;
        private List<Obra> listaObra;

        public ManFuncionEdit(Funcion funcion)
        {
            this.funcion = funcion;
            InitializeComponent();
        }

        private void ManFuncionEdit_Load(object sender, EventArgs e)
        {
            InicializarControles();
            LoadData();
        }

        private void InicializarControles()
        {
            cboObra.Enabled = false;
            cboTeatro.Enabled = false;
            cboDia.Enabled = false;
        }

        private void LoadData()
        {
            listaTeatro = servicio.ListarTeatros();
            cboTeatro.DataSource = listaTeatro;
            cboTeatro.DisplayMember = "Nombre";
            cboTeatro.SelectedItem = FindTeatro(funcion.Obra.Teatro.IdTeatro);

            teatro = cboTeatro.SelectedItem as Teatro;
            listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DataSource = listaObra;
            cboObra.SelectedItem = FindObra(funcion.Obra.IdObra);

            cboDia.SelectedItem = funcion.Dia;

            txtHoarario.Text = funcion.Horario;
            }

        private Teatro FindTeatro(int idTeatro)
        {
            return listaTeatro.Where(tx => tx.IdTeatro == idTeatro).FirstOrDefault();
        }

        private Obra FindObra(int idObra)
        {
            return listaObra.Where(tx => tx.IdObra == idObra).FirstOrDefault();
        }

        private void CapturarDatos()
        {
            obra = cboObra.SelectedItem as Obra;

            funcion.Obra = obra;
            funcion.Dia = Convert.ToInt32(cboDia.SelectedValue);
            funcion.Horario = txtHoarario.Text;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            if (servicio.ActualizarFuncion(funcion))
            {
                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error", "Aviso");
            }
        }
    }
}
