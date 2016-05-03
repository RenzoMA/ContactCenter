using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class TipoPromocionService : ITipoPromocionService
    {
        private readonly ITipoPromocionRepository tipoPromocionRepository;
        public TipoPromocionService(ITipoPromocionRepository _tipoPromocionRepository)
        {
            tipoPromocionRepository = _tipoPromocionRepository;
        }

        public List<TipoPromocion> GetLista()
        {
            List<TipoPromocion> lista = tipoPromocionRepository.GetLista().ToList();

            TipoPromocion tipoPromocion = new TipoPromocion()
            {
                Descripcion = "[--NINGUNO--]",
                IdTipoPromocion = 0
            };
            lista.Insert(0, tipoPromocion);
            return lista;
        }
    }
}
