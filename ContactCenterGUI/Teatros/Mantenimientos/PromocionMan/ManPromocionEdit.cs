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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterServices.ServicioTeatro;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.CC.Helpers;
using System.Globalization;
using System.Threading;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocionEdit : MaterialForm
    {
        private IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        private Promocion promocion;
        private List<TipoPromocion> listTipoPromocion;
        private List<Zona> listZona;
        private List<Funcion> listFuncion;
        private List<PromocionFuncion> listaPromocionFuncion;
        private List<PromocionZona> listaPromocionZona;
        NumberFormatInfo nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;
        char decSeperator;

        public ManPromocionEdit(Promocion promocion)
        {
            InitializeComponent();
            this.promocion = promocion;
            decSeperator = nfi.CurrencyDecimalSeparator[0];
        }
        private void LoadData()
        {
            dgvZonas.AutoGenerateColumns = false;
            dgvFunciones.AutoGenerateColumns = false;
            txtObra.Text = promocion.PromocionZonas[0].Zona.Obra.Nombre;
            txtDescripcion.Text = promocion.Descripcion;
            listTipoPromocion = servicio.GetListaTipoPromocion();
            cboTipoPromocion.DataSource = listTipoPromocion;
            cboTipoPromocion.DisplayMember = "Descripcion";
            cboTipoPromocion.SelectedItem = listTipoPromocion.Where(tx => tx.IdTipoPromocion == promocion.TipoPromocion.IdTipoPromocion).FirstOrDefault();
            cboEstado.SelectedIndex = promocion.Estado == "Activo" ? 0 : 1;
            dtpFechaInicio.Value = promocion.FechaInicio;
            dtpFechaFin.Value = promocion.FechaFin;
            chkRequiereEmpresa.Checked = promocion.RequiereEmpresa;

            listZona = servicio.ListZonaByObra(promocion.PromocionZonas[0].Zona.Obra.IdObra);
            listFuncion = servicio.ListarFuncionByObraGrilla(promocion.PromocionZonas[0].Zona.Obra.IdObra);

            dgvFunciones.DataSource = listFuncion;
            dgvZonas.DataSource = listZona;

            foreach (DataGridViewRow row in dgvZonas.Rows)
            {
                Zona zona = row.DataBoundItem as Zona;
                PromocionZona prZona = promocion.PromocionZonas.Where(tx => tx.Zona.IdZona == zona.IdZona).FirstOrDefault();
                if (prZona != null)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Sel"];
                    chk.Value = true;
                    row.Cells["Precio"].Value = prZona.Precio;
                }
            }

            foreach (DataGridViewRow row in dgvFunciones.Rows)
            {
                Funcion funcion = row.DataBoundItem as Funcion;
                PromocionFuncion prFuncion = promocion.PromocionFunciones.Where(tx => tx.Funcion.IdFuncion == funcion.IdFuncion).FirstOrDefault();
                if (prFuncion != null)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["SelF"];
                    chk.Value = true;
                }
            }

        }

        private void ManPromocionEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void CapturarDatos()
        {
            promocion.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            promocion.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
            promocion.FechaFin = dtpFechaFin.Value.Date;
            promocion.FechaInicio = dtpFechaInicio.Value.Date;
            promocion.TipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion;
        }
        private bool ValidarDatos()
        {
            if (txtDescripcion.Text.ToUpper().Trim().Equals(string.Empty))
            {
                MessageBox.Show("Complete la descripción", "Aviso");
                return false;
            }

            listaPromocionZona = new List<PromocionZona>();
            listaPromocionFuncion = new List<PromocionFuncion>();
            foreach (DataGridViewRow dtr in dgvZonas.Rows)
            {
                if (Convert.ToBoolean(dtr.Cells["Sel"].Value) == true)
                {
                    if (Convert.ToString(dtr.Cells["Precio"].Value).Equals(String.Empty))
                    {
                        MessageBox.Show("Debe ingresar todos los precios", "Aviso");
                        return false;
                    }
                    else
                    {
                        PromocionZona pZona = new PromocionZona();
                        pZona.Zona = dtr.DataBoundItem as Zona;
                        pZona.Precio = Convert.ToSingle(dtr.Cells["Precio"].Value);
                        listaPromocionZona.Add(pZona);
                    }
                }
            }


            if (listaPromocionZona.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos una zona", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            foreach (DataGridViewRow dtr in dgvFunciones.Rows)
            {
                if (Convert.ToBoolean(dtr.Cells["SelF"].Value) == true)
                {
                    PromocionFuncion pFuncion = new PromocionFuncion();
                    pFuncion.Funcion = dtr.DataBoundItem as Funcion;
                    listaPromocionFuncion.Add(pFuncion);
                }
            }

            if (listaPromocionFuncion.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos una función", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                AsignarDatos();
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

        private void AsignarDatos()
        {
            promocion.Descripcion = txtDescripcion.Text.ToUpper().Trim();
            promocion.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
            promocion.FechaFin = dtpFechaFin.Value.Date;
            promocion.FechaInicio = dtpFechaInicio.Value.Date;
            promocion.TipoPromocion = cboTipoPromocion.SelectedValue as TipoPromocion;
            promocion.RequiereEmpresa = chkRequiereEmpresa.Checked;
            promocion.PromocionFunciones = listaPromocionFuncion;
            promocion.PromocionZonas = listaPromocionZona;
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void dgvZonas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvZonas.CurrentCell.ColumnIndex == dgvZonas.Columns["Precio"].Index) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
    }
}
