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

        public bool Insert(Promocion datos)
        {
            return promocionRepository.Insert(datos);
        }

        public List<Promocion> ListarPromocionByFuncion(int idFuncion)
        {
            List<Promocion> listaPromocion = promocionRepository.ListarPromocionByFuncion(idFuncion);
            listaPromocion.ForEach(tx => {
                tx.TipoDescuento = tx.TipoDescuento == "M"? "Multiplica" : "Reemplaza";
                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaPromocion;
        }

        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromocion)
        {
            return promocionRepository.ListByFuncionTipoPromo(idFuncion, idTipoPromocion);
        }

        public bool Update(Promocion datos)
        {
            return promocionRepository.Update(datos);
        }
    }
}
