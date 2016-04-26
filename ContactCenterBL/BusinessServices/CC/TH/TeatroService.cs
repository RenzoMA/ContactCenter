using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;


namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class TeatroService : ITeatroService
    {

        private readonly ITeatroRepository teatroRepository;

        public TeatroService(ITeatroRepository _teatroRepository)
        {
            teatroRepository = _teatroRepository;
        }
        public List<Teatro> Listar()
        {
            List<Teatro> listaTeatro = teatroRepository.GetLista().ToList();
            Teatro obj = new Teatro()
            {
                IdTeatro = 0,
                Nombre = "Seleccione Teatro"
            };
            listaTeatro.Insert(0, obj);
            return listaTeatro;
        }
    }
}
