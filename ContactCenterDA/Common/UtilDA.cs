using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ContactCenterDA.Common
{
   static  class UtilDA
    {
        public static String GetCnx(this OleDbConnection con)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory().Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA\\");

            string strCnx =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + ruta + "ContactCentar.accdb";

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
