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
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices.ServicioTeatro;
using System.Threading;
using System.Globalization;
using ContactCenterServices;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocionCreate : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        public ManPromocionCreate()
        {
            InitializeComponent();
        }
        private void LoadComboTeatro()
        {
            try { 
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";
            LoadComboObra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboTipoPromocion()
        {
            cboTipoPromocion.DataSource = servicio.GetListaTipoPromocion();
            cboTipoPromocion.DisplayMember = "Descripcion";
        }
        private void LoadComboObra()
        {
            Teatro teatro = cboTeatro.SelectedItem as Teatro;
            cboObra.DataSource = servicio.ListarObraTeatro(teatro.IdTeatro);
            cboObra.DisplayMember = "Nombre";
            LoadComboFuncion();
        }
        private void LoadComboFuncion()
        {
            Obra obra = cboObra.SelectedItem as Obra;
            cboFuncion.DataSource = servicio.ListarFuncionByObra(obra.IdObra);
            cboFuncion.DisplayMember = "Horario";
        }
        private void SetEventos()
        {
            txtDescuento.KeyPress += HelperControl.EditTextDecimal;
        }
        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboObra();
        }

        private void cboObra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboFuncion();
        }

        private void ManPromocionCreate_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void LoadComboTipoDescuento()
        {
            cboTipoDescuento.SelectedIndex = 0;
        }
        private bool ValidarCampos()
        {
            if (txtDescripcion.Text.ToUpper().Trim().Equals(String.Empty))
                return false;
            if (txtDescuento.Text.ToUpper().Trim().Equals(String.Empty))
                return false;
            if (cboFuncion.SelectedIndex == 0)
                return false;
            return true;
        }
        private void Init()
        {
            LoadComboTeatro();
            LoadComboTipoPromocion();
            LoadComboTipoDescuento();
            SetEventos();
            SetValoresDefecto();
        }
        private void SetValoresDefecto()
        {
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Promocion promocion = new Promocion()
                {
                    Descripcion = txtDescripcion.Text.ToUpper().Trim(),
                    Descuento = Convert.ToSingle(txtDescuento.Text.ToUpper().Trim()),
                    FechaFin = dtpFechaFin.Value.Date,
                    FechaInicio = dtpFechaInicio.Value.Date,
                    Funcion = cboFuncion.SelectedItem as Funcion,
                    TipoDescuento = cboTipoDescuento.SelectedIndex == 0 ? "M" : "R",
                    TipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion
                };
                try { 
                if (servicio.InsertPromocion(promocion))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Aviso");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
