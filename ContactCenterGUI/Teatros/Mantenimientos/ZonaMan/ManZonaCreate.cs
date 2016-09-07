using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterServices.ServicioTeatro;
using Microsoft.Practices.Unity;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterServices;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterGUI.CC.Helpers;


namespace ContactCenterGUI.Teatros.Mantenimientos.ZonaMan
{
    public partial class ManZonaCreate : MaterialForm
    {
        private List<Teatro> listaTeatro = null;
        private Teatro teatro = null;

        private List<Obra> listaObra = null;
        private Obra obra = null;

        int r = 180;
        int g = 254;
        int b = 254;
        public ManZonaCreate()
        {
            InitializeComponent();
            Color color = Color.FromArgb(r, g, b);
            txtDisplayColor.BackColor = color;
            txtPrecioZona.KeyPress += HelperControl.EditTextDecimal;
        }
        private async void CargarTeatros()
        {
            try
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    Animacion.ShowLoader(this);
                    listaTeatro = await servicio.ListarTeatrosAsync();
                    Animacion.HideLoader(this);
                    cboTeatro.DataSource = listaTeatro;
                    cboTeatro.DisplayMember = "Nombre";
                }
                CargarObras();
            }
            catch (Exception ex)
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
                    listaObra = servicio.ListarObraTeatro(teatro.IdTeatro);
                    cboObra.DataSource = listaObra;
                    cboObra.DisplayMember = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTeatro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarObras();
        }

        private void ManZonaCreate_Load(object sender, EventArgs e)
        {
            CargarTeatros();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    obra = cboObra.SelectedItem as Obra;
                    Zona zona = new Zona();
                    zona.Nombre = txtNombreZona.Text.ToUpper().Trim();
                    zona.Descripcion = txtDescripcionZona.Text.ToUpper().Trim();
                    zona.Estado = "A";
                    zona.Precio = Convert.ToSingle(txtPrecioZona.Text);
                    zona.R = r;
                    zona.G = g;
                    zona.B = b;
                    zona.Obra = obra;
                    InsertarZona(zona);
                    //if (servicio.InsertarZona(zona))
                    //{
                    //    MessageBox.Show("Proceso realizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
        }

        private bool ValidarCampos()
        {
            if (txtNombreZona.Text.ToUpper().Equals(String.Empty))
            {
                MessageBox.Show("El nombre de zona es obligatorio", "Aviso");
                return false;
            }

            if (txtPrecioZona.Text.ToUpper().Trim().Equals(String.Empty))
            {
                MessageBox.Show("El precio de zona es obligatorio", "Aviso");
                return false;
            }
            if (txtDescripcionZona.Text.ToUpper().Trim().Equals(String.Empty))
            {
                MessageBox.Show("La descripción de zona es obligatorio", "Aviso");
                return false;
            }
            return true;
        }

        private void btnElegirColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                this.r = colorDialog1.Color.R;
                this.g = colorDialog1.Color.G;
                this.b = colorDialog1.Color.B;
                txtDisplayColor.BackColor = colorDialog1.Color;
            }
        }
        private async void InsertarZona(Zona zona)
        {
            try
            {
                bool exito = false;
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {
                    Animacion.ShowLoader(this);
                    exito = await servicio.InsertarZonaAsync(zona);
                    Animacion.HideLoader(this);
                    if (exito)
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
