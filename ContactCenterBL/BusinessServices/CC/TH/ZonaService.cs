using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository zonaRepository;
        public ZonaService(IZonaRepository _zonaRepository)
        {
            zonaRepository = _zonaRepository;
        }
        public List<Zona> ListZonaByTeatro(int IdTeatro)
        {
            return zonaRepository.ListZonaByTeatro(IdTeatro);
        }
    }
}
