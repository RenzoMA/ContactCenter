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

        public bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            return asientoRepository.EliminarAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
        }

        public bool EliminarAsientoTemporalTotal(string token)
        {
            return asientoRepository.EliminarAsientoTemporalTotal(token);
        }

        public bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            return asientoRepository.InserAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
        }

        public List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime fecha,string token)
        {
            return asientoRepository.ListarAsientoDisponible(idObra, idFuncion, fecha.Date, token);
        }

        public List<AsientoPrecio> ListarAsientoTeatro(int idObra)
        {
            return asientoRepository.ListarTeatroAsiento(idObra);
        }
        #endregion
    }
}
