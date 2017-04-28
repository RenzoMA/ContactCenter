using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ContactCenterGUI.CC.Constantes
{
    public class ConstanteColor
    {
        public static int PrimaryR = 3;
        public static int PrimaryG = 88;
        public static int PrimaryB = 155;

        public static int SecondaryR = 0;
        public static int SecondaryG = 120;
        public static int SecondaryB = 197;

        public static Color GetPrimaryColor()
        {
            return Color.FromArgb(PrimaryR, PrimaryG, PrimaryB);
        }

        public static Color GetSecundaryColor()
        {
            return Color.FromArgb(SecondaryR, SecondaryG, SecondaryB);
        }
    }
}
