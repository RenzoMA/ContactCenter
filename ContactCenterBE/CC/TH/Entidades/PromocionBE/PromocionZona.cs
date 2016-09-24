using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

namespace ContactCenterBE.CC.TH.Entidades.PromocionBE
{
    public class PromocionZona
    {
        public Promocion Promocion { get; set; }
        public Zona Zona { get; set; }
        public Single Precio { get; set; }
    }
}
