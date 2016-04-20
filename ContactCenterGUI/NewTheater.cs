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

namespace ContactCenterGUI
{
    public partial class NewTheater : MaterialForm
    {
        public NewTheater()
        {
            InitializeComponent();
        }

        private void NewTheater_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTheater2 newtheater2 = new NewTheater2();
            newtheater2.ShowDialog();
        }
    }
}
