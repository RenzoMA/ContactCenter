using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    

    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository _zonaRepository;

        public ZonaService(IZonaRepository zonaRepository)
        {
            _zonaRepository = zonaRepository;
        }

        public List<Zona> ListaZonaTeatro(int id)
        {
            List<Zona> listaZona = _zonaRepository.GetZonaTeatro(id);
            Zona obj = new Zona()
            {
                IdZona = 0,
                Nombre = "Seleccione Zona"
            };
            listaZona.Insert(0, obj);
            return listaZona;
        }
    }
}
