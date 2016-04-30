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

namespace ContactCenterGUI.Mantenimientos
{
    public partial class ManForm : MaterialForm
    {
        public ManForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue800, MaterialSkin.Primary.LightBlue900, MaterialSkin.Primary.LightBlue500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
        }

        private void ManForm_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {

                MessageBox.Show("Seleccione un mantenimiento", "ERROR");
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {

                this.Hide();
                Mantenimientos.Aplicacion.ManAppMenu manappmenu = new Mantenimientos.Aplicacion.ManAppMenu();
                manappmenu.ShowDialog();

            }
            else if (metroComboBox1.SelectedIndex == 8) {

                this.Hide();
                Mantenimientos.ObraC.ManPlayMenu manaplaymenu = new Mantenimientos.ObraC.ManPlayMenu();
                manaplaymenu.ShowDialog();
            }
        }
    }
}
