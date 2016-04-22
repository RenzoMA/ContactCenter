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


namespace ContactCenterGUI
{
    public partial class NewTheater2 : MaterialForm
    {
        public NewTheater2()
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
        private Asiento GetAsiento(int IdAsiento,List<Asiento> lista)
        {
            
            foreach (Asiento asiento in lista)
            {
                if (asiento.IdAsiento == IdAsiento)
                {
                    return asiento;
                }
            }
            return null;
        }

        private void CruzarBotonData(List<Asiento> lAsiento)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                int IdAsiento;
                bool isNumber = int.TryParse(btn.Name, out IdAsiento);
                if (isNumber)
                {
                    btn.Tag = GetAsiento(IdAsiento, lAsiento);
                }
            }
        }
    }
}
