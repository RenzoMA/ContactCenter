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

namespace ContactCenterGUI.CC.Mantenimientos.AplicacionMan
{
    public partial class ManAppFind : MaterialForm
    {
        public ManAppFind()
        {
            InitializeComponent();


            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue800, MaterialSkin.Primary.LightBlue900, MaterialSkin.Primary.LightBlue500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimientos.AplicacionMan.ManAppMenu manappmenu = new Mantenimientos.AplicacionMan.ManAppMenu();
            manappmenu.ShowDialog();
            
            
        }
    }
}
