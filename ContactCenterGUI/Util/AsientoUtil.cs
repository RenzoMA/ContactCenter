using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Windows.Forms;


namespace ContactCenterGUI.Util
{
    class AsientoUtil
    {
        private static Asiento GetAsiento(int IdAsiento, List<Asiento> lista)
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

        public static void CruzarBotonData(List<Asiento> lAsiento, Form form)
        {
            foreach (Button btn in form.Controls.OfType<Button>())
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
