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
using ContactCenterBE.CC.TH.Entidades.AsientoBE;


namespace ContactCenterGUI.Teatros
{
    public partial class PerJapTheater : MaterialForm
    {
        public PerJapTheater()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTheater newtheater = new NewTheater();
            newtheater.ShowDialog();
        }
    }
}
