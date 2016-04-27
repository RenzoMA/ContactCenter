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
    public partial class PerInfoTheater : MaterialForm
    {
        Form frmTeatro;
        public PerInfoTheater()
        {
            InitializeComponent();
        }
        public PerInfoTheater(Form form)
        {
            frmTeatro = form;
            frmTeatro.Visible = false;
            InitializeComponent();
        }

        private void PerInfoTheater_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTeatro.Visible = true;
        }
    }
}
