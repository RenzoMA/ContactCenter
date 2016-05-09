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
    public partial class TheaterPirandello : MaterialForm
    {
        public TheaterPirandello()
        {
            InitializeComponent();
        }

        private void lbltpatras_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Se perderan todos los cambios realizados hasta el momento. ¿ seguro de regresar ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                NewReservation newtheater = new NewReservation();
                newtheater.ShowDialog();
                this.Show();
            }
        }

        private void lbltpmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbltpcer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
