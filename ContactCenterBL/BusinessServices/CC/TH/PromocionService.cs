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
                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaPromocion;
        }

        public List<Promocion> ListByFuncionTipoPromo(int idFuncion, int idTipoPromocion, string zonas)
        {
            List<Promocion> listaPromocion = promocionRepository.ListByFuncionTipoPromo(idFuncion, idTipoPromocion, zonas);
            List<PromocionZona> listaPromocionZona = promocionRepository.ListPromocionZonaByFuncionZona(idFuncion, zonas);
            foreach (Promocion pr in listaPromocion)
            {
                pr.PromocionZonas = listaPromocionZona.Where(tx => tx.Promocion.IdPromocion == pr.IdPromocion).ToList();
            }
            return listaPromocion;
        }


        public List<Promocion> ListPromocionByObra(int idObra)
        {
            List<Promocion> listaPromocion = promocionRepository.ListPromocionByObra(idObra);
            listaPromocion.ForEach(tx => {
                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaPromocion;
        }

        public bool Update(Promocion datos)
        {
            return promocionRepository.Update(datos);
        }
    }
}
