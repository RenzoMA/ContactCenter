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
using MaterialSkin.Animations;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterGUI.Mantenimientos.Funcion
{
    public partial class ManFunctionCreate : MaterialForm
    {
        IServiceContactCenter servicio = Contenedor.current.Resolve<IServiceContactCenter>();

        public ManFunctionCreate()
        {
            InitializeComponent();
        }

        private void ManFunctionCreate_Load(object sender, EventArgs e)
        {
            cboTeatro.DataSource = servicio.ListarTeatros();
            cboTeatro.DisplayMember = "Nombre";

            cboObra.DataSource = servicio.ListarObras();
            cboObra.DisplayMember = "Nombre";
        }
    }
}
