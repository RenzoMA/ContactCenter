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

namespace ContactCenterGUI.Mantenimientos.Obra
{
    public partial class ManPlayCreate : MaterialForm
    {
        public ManPlayCreate()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimientos.Obra.ManPlayMenu manplaymenu = new Mantenimientos.Obra.ManPlayMenu();
            manplaymenu.ShowDialog();
        }
    }
}
