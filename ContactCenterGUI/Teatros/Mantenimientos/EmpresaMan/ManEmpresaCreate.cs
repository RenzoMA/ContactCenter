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
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using Microsoft.Practices.Unity;
using ContactCenterServices;
using ContactCenterServices.ServicioTeatro;

namespace ContactCenterGUI.Teatros.Mantenimientos.EmpresaMan
{
    public partial class ManEmpresaCreate : MaterialForm
    {
        private bool allowCortesia = false;
        private Empresa empresa;

        public ManEmpresaCreate()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            allowCortesia = chk.Checked;
            if (allowCortesia)
            {
                txtCortesias.Visible = true;
            }
            else
            {
                txtCortesias.Visible = false;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CapturarDatos();
            InsertarEmpresa();
        }

        private void InsertarEmpresa()
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                if (servicio.InsertEmpresa(empresa))
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

        private void CapturarDatos()
        {
            if (ValidarDatos())
            {
                empresa = new Empresa()
                {
                    Estado = "A",
                    CantidadCorteisas = Convert.ToInt16(txtCortesias.Text),
                    Cortesias = allowCortesia,
                    Nombre = txtNombreZona.Text.Trim()
                };
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Aviso");
            }
        }

        private bool ValidarDatos()
        {
            if (txtNombreZona.Text.Trim().Equals(string.Empty))
            {
                return false;
            }
            if (allowCortesia)
            {
                if (txtCortesias.Text.Trim().Equals(String.Empty))
                {
                    return false;
                }
            }
            else
            {
                txtCortesias.Text = "0";
            }
            return true;
        }
    }
}
