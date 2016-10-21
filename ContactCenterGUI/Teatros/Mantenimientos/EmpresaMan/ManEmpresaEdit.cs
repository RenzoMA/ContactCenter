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
    public partial class ManEmpresaEdit : MaterialForm
    {
        Empresa empresa;
        bool cortesia = false;


        public ManEmpresaEdit(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
        }

        private void ManEmpresaEdit_Load(object sender, EventArgs e)
        {
            txtNombreEmpresa.Text = empresa.Nombre;
            cortesia = empresa.Cortesias;
            txtCortesias.Text = empresa.CantidadCorteisas.ToString();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (IServiceTeatro servicio = Contenedor.current.Resolve<IServiceTeatro>())
            {
                empresa.Nombre = txtNombreEmpresa.Text.Trim();
                empresa.Cortesias = cortesia;
                empresa.CantidadCorteisas = Convert.ToInt16(txtCortesias.Text);

                if (servicio.UpdateEmpresa(empresa))
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

        private void chkCortesia_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                cortesia = true;
                txtCortesias.Visible = true;
            }
            else
            {
                cortesia = false;
                txtCortesias.Visible = false;
            }
        }
    }
}
