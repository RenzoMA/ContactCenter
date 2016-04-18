using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterDA.Repositories.CC
{
    class Access
    {
        public String GetCnx()
        {
            string ruta = System.IO.Directory.GetCurrentDirectory().Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA\\");
            //cambiar la direccion en que tienen guardado el archivo de la bd
            string strCnx =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="+ruta+"ContactCentar.accdb";

            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
    }
}
