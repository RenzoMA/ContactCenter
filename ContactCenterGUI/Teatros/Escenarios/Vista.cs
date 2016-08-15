using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactCenterGUI.Teatros.Escenarios
{
    public partial class Vista : Form
    {
        private Image _image;
        public Vista(Image img)
        {
            InitializeComponent();
            _image = img;
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            pop.Image = _image;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
