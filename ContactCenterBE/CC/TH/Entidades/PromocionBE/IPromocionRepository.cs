using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.PromocionBE
{
    public interface IPromocionRepository : IBaseRepository<Promocion>
    {
        List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromocion);
    }
}
