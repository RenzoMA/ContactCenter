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

namespace ContactCenterGUI.Teatros
{
    public partial class NewTheater : MaterialForm
    {
        public NewTheater()
        {
            InitializeComponent();
        }

        private void NewTheater_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {
                this.Hide();
                PerJapTheater newtheater2 = new PerJapTheater();
                newtheater2.ShowDialog();
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {

                this.Hide();
                CallaoTheater callaoT = new CallaoTheater();
                callaoT.ShowDialog();
            }
            else if (metroComboBox1.SelectedIndex == 3) {

                this.Hide();
                PlazaNorteTheater plazaNT = new PlazaNorteTheater();
                plazaNT.ShowDialog();
            }
           
        }
    }
}
