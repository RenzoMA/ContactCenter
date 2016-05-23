using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactCenterGUI.CC.Helpers
{
    class HelperForm
    {
        public static void changeForm(string formName, string aplicacion, bool hide,Form form, object parametro = null)
        {
            Type CAType = Type.GetType("ContactCenterGUI." + formName);
            if (CAType != null)
            {
                if (hide) form.Hide();
                Form nextForm2 = (Form)Activator.CreateInstance(CAType);
                nextForm2.Tag = parametro;
                nextForm2.ShowDialog();
                if (hide) form.Show();
            }
            else
            {
                MessageBox.Show("Formulario no encontrado");
            }
        }
    }
}
