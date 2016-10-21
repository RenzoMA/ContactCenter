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

namespace ContactCenterGUI.Teatros.Mantenimientos.EmpresaMan
{
    public partial class ManEmpresaCreate : MaterialForm
    {
        private bool allowCortesia = false;

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
    }
}
