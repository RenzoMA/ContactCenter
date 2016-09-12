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
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;
using System.Globalization;
using System.Threading;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocionEdit : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private Promocion promocion;
        private List<TipoPromocion> listaPromocion;
        public ManPromocionEdit(Promocion promocion)
        {
            this.promocion = promocion;
            InitializeComponent();
        }
        private void LoadData()
        {
            txtDescripcion.Text = promocion.Descripcion;
            txtDescuento.Text = promocion.Descuento.ToString();
            cboEstado.SelectedIndex = promocion.Estado == "Activo"? 0:1;
            cboTipoDescuento.SelectedIndex = promocion.TipoDescuento == "Multiplica" ? 0 : 1;
            dtpFechaFin.Value = promocion.FechaFin;
            dtpFechaInicio.Value = promocion.FechaInicio;
            try { 
            listaPromocion = servicio.GetListaTipoPromocion();
            cboTipoPromocion.DataSource = listaPromocion;
            cboTipoPromocion.DisplayMember = "Descripcion";
            cboTipoPromocion.SelectedItem = FindPromocion(promocion.TipoPromocion.IdTipoPromocion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetEventos()
        {
            txtDescuento.KeyPress += HelperControl.EditTextDecimal;
        }
        private TipoPromocion FindPromocion(int idTipoPromocion)
        {
            return listaPromocion.Where(tx => tx.IdTipoPromocion == idTipoPromocion).FirstOrDefault();
        }
        private void ManPromocionEdit_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEventos();
        }
        private void CapturarDatos()
        {
            promocion.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            promocion.Descuento = Convert.ToSingle(txtDescuento.Text);
            promocion.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
            promocion.FechaFin = dtpFechaFin.Value.Date;
            promocion.FechaInicio = dtpFechaInicio.Value.Date;
            promocion.TipoDescuento = cboTipoDescuento.SelectedIndex == 0 ? "M" : "R";
            promocion.TipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
        }
        private bool ValidarDatos()
        {
            if (txtDescripcion.Text.ToUpper().Trim().Equals(string.Empty))
                return false;
            if (txtDescuento.Text.ToUpper().Trim().Equals(String.Empty))
                return false;

            return true;

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            if (ValidarDatos())
            {
                try { 
                if (servicio.UpdatePromocion(promocion))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Aviso");
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Completar todos los campos", "Aviso");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
