using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterGUI.Helpers;


namespace ContactCenterGUI.CC
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            if (HelperConexion.PingHost("localhost"))
            {

                Login login = new Login();
                login.ShowDialog();
                this.Close();
                //Teatros.NewTheater teatro = new Teatros.NewTheater();
                //teatro.ShowDialog();
                //this.Close();

            }
            else
            {
                MessageBox.Show("No hay conexión con el servidor");
            }
        }
    }
}
