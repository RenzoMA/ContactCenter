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
            //cambiar la direccion en que tienen guardado el archivo de la bd
            string strCnx =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\\Users\\AtoVader\\Documents\\KriegerLab\\ContactCenter-master\\ContactCenter-master\\ContactCenterDA\\ContactCentar.accdb";

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
