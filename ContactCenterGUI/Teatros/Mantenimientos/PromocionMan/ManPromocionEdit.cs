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
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;
using System.Globalization;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocionEdit : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();
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
            listaPromocion = servicio.GetListaTipoPromocion();
            cboTipoPromocion.DataSource = listaPromocion;
            cboTipoPromocion.DisplayMember = "Descripcion";
            cboTipoPromocion.SelectedItem = FindPromocion(promocion.TipoPromocion.IdTipoPromocion);
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

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
        private void CapturarDatos()
        {
            promocion.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            promocion.Descuento = Convert.ToSingle(txtDescuento.Text, new CultureInfo("en-US"));
            promocion.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
            promocion.FechaFin = dtpFechaFin.Value.Date;
            promocion.FechaInicio = dtpFechaInicio.Value.Date;
            promocion.TipoDescuento = cboTipoDescuento.SelectedIndex == 0 ? "M" : "R";
            promocion.TipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CapturarDatos();
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
    }
}
