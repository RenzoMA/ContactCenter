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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterGUI.CC.Helpers;
using ContactCenterGUI.CC.Constantes;

namespace ContactCenterGUI.Teatros.Mantenimientos.ZonaMan
{
    public partial class ManZonaEdit : MaterialForm
    {
        private Zona zona;
        public ManZonaEdit(Zona zona)
        {
            InitializeComponent();
            this.zona = zona;
            SetEvents();
            FillData();
            

        }
        public void SetEvents()
        {
            txtPrecioZona.KeyPress += HelperControl.EditTextDecimal;
        }
        public void FillData()
        {
            txtDescripcionZona.Text = zona.Descripcion;
            txtNombreZona.Text = zona.Nombre;
            txtPrecioZona.Text = zona.Precio.ToString();
            cboEstado.SelectedIndex = zona.Estado == "Activo" ? 0 : 1;
            txtDisplayColor.BackColor = Color.FromArgb(zona.R, zona.G, zona.B);
            colorDialog1.Color = Color.FromArgb(zona.R, zona.G, zona.B);
        }

        private void btnElegirColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                this.zona.R = colorDialog1.Color.R;
                this.zona.G = colorDialog1.Color.G;
                this.zona.B = colorDialog1.Color.B;
                txtDisplayColor.BackColor = colorDialog1.Color;
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
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
                {

                    zona.Nombre = txtNombreZona.Text.ToUpper().Trim();
                    zona.Descripcion = txtDescripcionZona.Text.ToUpper().Trim();
                    zona.Estado = cboEstado.SelectedIndex == 0 ? "A" : "I";
                    zona.Precio = Convert.ToSingle(txtPrecioZona.Text);

                    if (servicio.ActualizarZona(zona))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
