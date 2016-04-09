using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterServices;

namespace ContactCenterGUI
{
    public partial class Form1 : Form
    {
        IServiceContactCenter servicio;
        public Form1()
        {
            InitializeComponent();
            servicio = new ServiceContactCenter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(servicio.prueba());
        }
    }
}
