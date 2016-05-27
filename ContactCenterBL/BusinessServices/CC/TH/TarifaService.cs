using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository tarifaRepository;


        public TarifaService(ITarifaRepository _tarifaRepository)
        {
            tarifaRepository = _tarifaRepository;
        }
        public List<Tarifa> GetListaByTeatroObra(int IdObra)
        {
            List<Tarifa> listTarifa = tarifaRepository.GetListaByTeatroObra(IdObra);
            return listTarifa;
        }

        public bool Insert(Tarifa tarifa)
        {
            return tarifaRepository.Insert(tarifa);
        }

        public bool Update(Tarifa tarifa)
        {
            return tarifaRepository.Update(tarifa);
        }
    }
}
