using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class PromocionService : IPromocionService
    {
        private readonly IPromocionRepository promocionRepository;
        public PromocionService(IPromocionRepository _promocionRepository)
        {
            promocionRepository = _promocionRepository;
        }

        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromocion)
        {
            return promocionRepository.ListByFuncionTipoPromo(idFuncion, idTipoPromocion);
        }
    }
}
