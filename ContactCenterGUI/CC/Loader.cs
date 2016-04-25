using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactCenterGUI.CC
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            //Test
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.ShowDialog();
            //this.Close();

            //Teatros.NewTheater teatro = new Teatros.NewTheater();
            //teatro.ShowDialog();
            //this.Close();

            Mantenimientos.ManForm manform = new Mantenimientos.ManForm();
            manform.ShowDialog();
            this.Close();

        }
    }
}
