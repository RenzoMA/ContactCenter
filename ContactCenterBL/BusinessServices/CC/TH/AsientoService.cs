using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterDA.Repositories.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class AsientoService : IAsientoService
    {
        #region fields
        private readonly IAsientoRepository asientoRepository;
        #endregion

        #region Constructor
        public AsientoService(IAsientoRepository _asientoRepository)
        {
            asientoRepository = _asientoRepository;
        }
        #endregion

        #region metodos
        
        #endregion
    }
}
