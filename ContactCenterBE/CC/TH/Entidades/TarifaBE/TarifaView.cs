using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.TarifaBE
{
    public class TarifaView:Tarifa
    {
        public String NombreZona
        {
            get
            {
                return Zona.Nombre;
            }
        }
    }
}
