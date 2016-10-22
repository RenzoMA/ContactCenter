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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterServices.ServicioTeatro;
using System.Threading;
using System.Globalization;
using ContactCenterServices;
using ContactCenterGUI.CC.Constantes;


namespace ContactCenterGUI.Teatros.Mantenimientos.PromocionMan
{
    public partial class ManPromocionCreate : MaterialForm
    {
        IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>();
        NumberFormatInfo nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;
        char decSeperator;
        
        public ManPromocionCreate()
        {
            InitializeComponent();
            decSeperator = nfi.CurrencyDecimalSeparator[0];
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
        }
        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadComboObra();
        }


        private void ManPromocionCreate_Load(object sender, EventArgs e)
        {
            Init();
        }
        private bool ValidarCampos()
        {
            if (txtDescripcion.Text.ToUpper().Trim().Equals(String.Empty))
                return false;
            return true;
        }
        private void Init()
        {
            LoadComboTeatro();
            LoadComboTipoPromocion();
            SetValoresDefecto();
            SetGrillas();
        }
        private void SetGrillas()
        {
            dgvZonas.AutoGenerateColumns = false;
            dgvFunciones.AutoGenerateColumns = false;
        }
        private void SetValoresDefecto()
        {
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

                List<PromocionZona> listaPromocionZona = new List<PromocionZona>();
                bool isValid = true;
                foreach (DataGridViewRow dtr in dgvZonas.Rows)
                {
                    if (Convert.ToBoolean(dtr.Cells["Sel"].Value) == true)
                    {
                        if (Convert.ToString(dtr.Cells["Precio"].Value).Equals(String.Empty))
                        {
                            isValid = false;
                            break;
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

                if (!isValid)
                {
                    MessageBox.Show("Debe ingresar el precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (listaPromocionZona.Count < 1)
                {
                    MessageBox.Show("Debe seleccionar al menos una zona", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                List<PromocionFuncion> listaPromocionFuncion = new List<PromocionFuncion>();

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
                    return;
                }


                Promocion promocion = new Promocion()
                {
                    Descripcion = txtDescripcion.Text.ToUpper().Trim(),
                    FechaFin = dtpFechaFin.Value.Date,
                    FechaInicio = dtpFechaInicio.Value.Date,
                    TipoPromocion = cboTipoPromocion.SelectedItem as TipoPromocion,
                    RequiereEmpresa = chkRequiereEmpresa.Checked,
                    PromocionFunciones = listaPromocionFuncion,
                    PromocionZonas = listaPromocionZona
                };
                try
                {
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
        private void EnlazarGrillasByObra()
        {
            Obra obra = cboObra.SelectedItem as Obra;
            dgvZonas.DataSource = servicio.ListZonaByObra(obra.IdObra);
            dgvFunciones.DataSource = servicio.ListarFuncionByObraGrilla(obra.IdObra);
        }
        private void cboObra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EnlazarGrillasByObra();
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
    }
}
