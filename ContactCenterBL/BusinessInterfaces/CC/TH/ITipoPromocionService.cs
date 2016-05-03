using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface ITipoPromocionService
    {
        List<TipoPromocion> GetLista();
    }
}
