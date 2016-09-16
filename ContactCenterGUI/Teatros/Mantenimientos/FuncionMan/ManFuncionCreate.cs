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
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.FuncionMan
{
    public partial class ManFuncionCreate : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();

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
            if (Validar())
            {
                CrearTarifa();
            }
        }

        private bool Validar()
        {
            if (txtHoarario.Text.Trim().Equals(String.Empty) ||
            cboTeatro.SelectedIndex == 0 || cboObra.SelectedIndex == 0
            || cboDia.SelectedIndex == 0)
            {
                MessageBox.Show("Complete los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetEventos()
        {
            txtHoarario.KeyPress += HelperControl.EditTextDecimal;
        }

        private async void CargarTeatros()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaTeatro = await servicio.ListarTeatrosAsync();
                    cboTeatro.DataSource = listaTeatro;
                    cboTeatro.DisplayMember = "Nombre";
                }
                CargarObras();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarObras()
        {
            try
            {
                teatro = cboTeatro.SelectedItem as Teatro;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    listaObra = servicio.ComboManGetListaTeatro(teatro.IdTeatro);
                    cboObra.DataSource = listaObra;
                    cboObra.DisplayMember = "Nombre";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CrearTarifa()
        {
            try
            {
                obra = cboObra.SelectedItem as Obra;

                Funcion funcion = new Funcion()
                {
                    Dia = Convert.ToInt32(cboDia.SelectedIndex) - 1,
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
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManFuncionCreate_Load(object sender, EventArgs e)
        {
            CargarTeatros();
            SetTextCboDia();
           // SetEventos();
        }

        private void cboTeatro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarObras();
        }

        private void SetTextCboDia()
        {
            cboDia.DropDownStyle = ComboBoxStyle.DropDown;
            cboDia.Text = "Seleccione día";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
