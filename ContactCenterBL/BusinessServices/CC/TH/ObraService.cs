using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;
        public ObraService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }
        public List<Obra> ListarObraTeatro(int idTeatro)
        {
            List<Obra> listaObra = _obraRepository.GetListaTeatro(idTeatro);
            Obra obra = new Obra()
            {
                IdObra = 0,
                Nombre = "Seleccione obra"
            };
            listaObra.Insert(0, obra);
            return listaObra;
        }
    }
}
